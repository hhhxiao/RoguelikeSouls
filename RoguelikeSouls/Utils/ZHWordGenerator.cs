using JiebaNet.Segmenter;
using JiebaNet.Segmenter.PosSeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeSouls.Utils
{
    public class ZHWordGenerator
    {
        List<String> Pool;


        public ZHWordGenerator(List<String> dict)
        {
            this.Pool = new List<string>();
            JiebaSegmenter segmenter = new JiebaSegmenter();
            foreach (var word in dict)
            {
                var sp = segmenter.Cut(word.Trim());
                foreach (var token in sp)
                {
                    Pool.Add(token);
                }
            }
        }

        public string RandomWord(Random random, int min = 3, int max = 10)
        {
            StringBuilder builder = new StringBuilder();
            int ApproLen = random.Next(min, max + 1);
            int attempts = 0;
            while (builder.Length < ApproLen)
            {
                attempts++;
                if (attempts > 10) break;
                builder.Append(this.Pool[random.Next(Pool.Count)]);
            }

            return builder.ToString();
        }
    }

    public class ZHParagraphGenerator
    {
        List<List<String>> SentenceTypePool;
        Dictionary<String, List<String>> WordPool;

        public ZHParagraphGenerator(List<String> dict)
        {
            this.SentenceTypePool = new List<List<string>>();
            this.WordPool = new Dictionary<string, List<string>>();
            PosSegmenter posSegmenter = new PosSegmenter();
            foreach (var sentence in dict)
            {
                List<String> st = new List<string>();
                var s = sentence.Trim();
                var tokens = posSegmenter.Cut(s);
                foreach (var token in tokens)
                {
                    st.Add(token.Flag);
                    if (this.WordPool.ContainsKey(token.Flag))
                    {
                        this.WordPool[token.Flag].Add(token.Word);
                    }
                    else
                    {
                        this.WordPool.Add(token.Flag, new List<String> { token.Flag });
                    }
                }

                this.SentenceTypePool.Add(st);
            }
        }

        private String Preprocess(String sentence)
        {
            //     c[i] >= 0x4e00 && c[i] <= 0x9fbb

            bool lastIsZH = false;
            int hans = 0;
            StringBuilder builder = new StringBuilder();
            foreach (var ch in sentence)
            {
                if (ch == '。' || ch == '，')
                {
                    if (lastIsZH)
                    {
                        builder.Append(ch);
                    }

                    lastIsZH = false;
                }
                else if ((int)ch >= 0x4e00 && (int)ch <= 0x9fbb) //汉字
                {
                    builder.Append(ch);
                    lastIsZH = true;
                    hans++;
                }
                else //标准ascii 或者其他标点
                {
                }
            }

            if (hans == 0) return "";

            var res = builder.ToString();
            return res.Last() == '，' || res.Last() == '。' ? res.Substring(0, res.Length - 1) + "。" : res + "。";
        }

        public string RandomSentence(Random random)
        {
            var st = this.SentenceTypePool[random.Next(this.SentenceTypePool.Count)];
            var builder = new StringBuilder();
            foreach (var flag in st)
            {
                if (!this.WordPool.ContainsKey(flag))
                {
                    continue;
                }
                else
                {
                    var Len = this.WordPool[flag].Count;
                    var word = this.WordPool[flag][random.Next(Len)];

                    builder.Append(word);
                }
            }

            return Preprocess(builder.ToString());
        }


        public string RandomParagraph(Random random, int min, int max)
        {
            StringBuilder builder = new StringBuilder();
            int Len = random.Next(min, max + 1);
            int attempts = 0;
            while (builder.Length < Len)
            {
                builder.Append(this.RandomSentence(random));
                attempts++;
            }

            var res = builder.ToString();
            StringBuilder resBuilder = new StringBuilder();
            int curretLen = 0;
            foreach (var ch in res)
            {
                resBuilder.Append(ch);
                if (ch == '，' || ch == '。')
                {
                    if (curretLen >= 10)
                    {
                        resBuilder.Append('\n');
                        curretLen = 0;
                    }
                }
                else
                {
                    curretLen++;
                }
            }

            // Console.WriteLine($"{resBuilder.ToString()}");
            return resBuilder.ToString();
        }
    }
}