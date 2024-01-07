using JiebaNet.Segmenter;
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
}
