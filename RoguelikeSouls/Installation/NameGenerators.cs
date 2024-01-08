using System;
using System.Collections.Generic;
using System.Linq;
using Markov;
using RoguelikeSouls.Extensions;
using RoguelikeSouls.Utils;
using WeaponNameOptionDict =
    System.Collections.Generic.Dictionary<string, (System.Collections.Generic.List<string> common,
        System.Collections.Generic.List<string> legendary)>;
using ArmorNameOptionDict =
    System.Collections.Generic.Dictionary<string, (System.Collections.Generic.List<string> light,
        System.Collections.Generic.List<string> heavy)>;
using JiebaNet.Segmenter;
using System.IO;
using System.IO.Pipes;
using System.Security.Permissions;
using System.Text;

namespace RoguelikeSouls.Installation
{
    class WeaponNameGenerator
    {
        public static readonly WeaponNameOptionDict ClassOptions = new WeaponNameOptionDict()
        {
            {
                "Melee", (new List<string>() { "近战" }, new List<string>() { "近战" })
            },
            {
                "Dagger", (
                    // new List<string>() { "Dagger", "Knife", "Tracer", "Dirk", "Quickblade" },

                    // new List<string>() { "Stiletto", "Bloodknife", "Heartpiercer", "Razor" }
                    new List<string>() { "匕首", "刀", "追踪者", "短剑", "快刀" },
                    new List<string>() { "短剑", "血刀", "穿心刺", "锋刃" }
                )
            },
            {
                "StraightSword", (
                    // new List<string>() { "Straight Sword", "Sword", "Blade", "Brand", "Edge" },
                    // new List<string>() { "Soulbrand", "Blacksword", "Crusader" }
                    new List<string>() { "直剑", "剑", "刀刃", "刻印", "边缘之刃" },
                    new List<string>() { "灵魂刻印", "黑剑", "十字军" }
                )
            },
            {
                "Greatsword", (
//                new List<string>() { "Greatsword", "Ironblade", "Claymore" },
                    //              new List<string>() { "Bonehewer", "Breaker" }
                    new List<string>() { "大剑", "铁刃", "大剑" },
                    new List<string>() { "碎骨者", "破坏者" }
                )
            },
            {
                "UltraGreatsword", (
                    // new List<string>() { "Greatsword", "Giantsword" },
                    //new List<string>() { "Stoneblade", "Vastblade", "Skullduster" }
                    new List<string>() { "大剑", "巨剑" },
                    new List<string>() { "石刃", "浩瀚之剑", "碎颅者" }
                )
            },
            {
                "ThrustingSword", (
                    // new List<string>() { "Rapier", "Estoc", "Sabre", "Foil", "Epee" },
                    // new List<string>() { "Impaler", "Reaver", "Etcher" }
                    new List<string>() { "薄剑", "穿刺剑", "军刀", "花剑", "重剑" },
                    new List<string>() { "刺客剑", "掠夺者", "蚀刻剑" }
                )
            },
            {
                "CurvedSword", (
                    //  new List<string>() { "Scimitar", "Cutlass", "Falchion", "Machete", "Backsword" },
                    // new List<string>() { "Shamshir", "Kilij", "Shotel", "Bird-Talon" }
                    new List<string>() { "弯刀", "短弯刀", "弯刃剑", "马刀", "背剑" },
                    new List<string>() { "波斯弯刀", "土耳其弯刀", "钩剑", "鸟钩爪" }
                )
            },
            {
                "CurvedGreatsword", (
                    //new List<string>() { "Arcblade", "Giant Machete" },
                    //new List<string>() { "Skincarver", "Rukh-Talon" }
                    new List<string>() { "弧刃", "巨型马刀" },
                    new List<string>() { "剥皮者", "鲁克钩爪" }
                )
            },
            {
                "Katana", (
                    // new List<string>() { "Katana", "Iaito", "Uchigatana", "Shinken"},
                    // new List<string>() { "Tsurugi", "Tachi", "Odachi" }
                    new List<string>() { "刀", "居合刀", "打刀", "武士刀" },
                    new List<string>() { "剑", "太刀", "小太刀" }
                )
            },
            {
                "Axe", (
                    // new List<string>() { "Axe", "Hatchet", "Chopper", "Battleaxe" },
                    // new List<string>() { "Cleaver", "Meataxe", "Bonehewer" }
                    new List<string>() { "斧", "手斧", "小斧", "战斧" },
                    new List<string>() { "菜刀", "切肉刀", "伐骨者" }
                )
            },
            {
                "Greataxe", (
                    //new List<string>() { "Greataxe", "Giantaxe", "Stoneaxe" },
                    // new List<string>() { "Skullsplitter", "Titanjaw", "Vastaxe" }
                    new List<string>() { "大斧", "巨斧", "石斧" },
                    new List<string>() { "裂颅者", "泰坦之颚", "浩瀚之斧" }
                )
            },
            {
                "Hammer", (
                    //new List<string>() { "Hammer", "Club", "Cudgel", "Mace" },
                    // new List<string>() { "Truncheon", "Pummeler", "Crusher" }
                    new List<string>() { "锤", "棍棒", "棍棒", "锤矛" },
                    new List<string>() { "棍", "猛击者", "粉碎者" }
                )
            },

            {
                "GreatHammer", (
                    // new List<string>() { "Great Hammer", "Greatclub", "Giant Club", "Big Rock" },
                    // new List<string>() { "Colossus", "Hornhammer", "Dragontooth", "Soulgrinder" }
                    new List<string>() { "大锤", "大型棍棒", "巨型棍棒", "大石" },
                    new List<string>() { "巨人大锤", "角锤", "龙牙", "灵魂研磨者" }
                )
            },
            {
                "Spear", (
                    // new List<string>() { "Spear", "Pike", "Lance", "Javelin", "Partizan" },
                    // new List<string>() { "Skewer", "Brochette", "Ramspike" }
                    new List<string>() { "矛", "长矛", "长枪", "投枪", "阔头枪" },
                    new List<string>() { "刺叉", "叉", "冲锋矛" }
                )
            },
            {
                "Halberd", (
                    // new List<string>() { "Halberd", "Bayonet", "Pollaxe", "Bill-Hook" },
                    // new List<string>() { "Spontoon", "Glaive", "Axespear" }
                    new List<string>() { "戟", "刺刀", "长柄斧", "钩鐮" },
                    new List<string>() { "长柄枪", "长柄刀", "斧枪" }
                )
            },
            {
                "Scythe", (
                    new List<string>() { "大镰刀", "小镰刀" },
                    new List<string>() { "收割者", "死神钩", "收割者" }

                    //new List<string>() { "Scythe", "Sickle" },
                    //new List<string>() { "Reaper", "Grimhook", "Harvester" }
                )
            },
            {
                "Catalyst", (
                    new List<string>() { "杖" },
                    new List<string>() { "杖" }
                )
            },
            {
                "Talisman", (
                    new List<string>() { "护符" },
                    new List<string>() { "护符" }
                )
            },
            {
                "Fists", (
                    //new List<string>() { "Knuckles", "Caestus" },
                    //new List<string>() { "Shellfist", "Stonehand" }
                    new List<string>() { "拳套", "护手带" },
                    new List<string>() { "贝壳拳", "石之手" }
                )
            },
            {
                "Whip", (
                    new List<string>() { "鞭", "鞭", "开关鞭" },
                    new List<string>() { "牛皮鞭", "九尾鞭" }

                    //new List<string>() { "Whip", "Lash", "Switch" },
                    // new List<string>() { "Bullwhip", "Cat-o'-Nine-Tails" }
                )
            },
            {
                "Bow", (
                    new List<string>() { "弓", "长弓", "短弓" },
                    new List<string>() { "会心弓", "隼弓" }
                )
            },
            {
                "Greatbow", (
                    new List<string>() { "大弓" },
                    new List<string>() { "大弓", "哀伤弓" }
                )
            },
            {
                "Crossbow", (
                    new List<string>() { "弩" },
                    new List<string>() { "巨弩", "蝎尾弩" }
                )
            },
            {
                "Greatshield", (
                    new List<string>() { "大盾", "石盾" },
                    new List<string>() { "浩瀚之盾", "甲壳", "墙盾" }
                )
            },
            {
                "Shield", (
                    new List<string>() { "盾", "小圆盾", "守护者" },
                    new List<string>() { "血盾", "壳" }
                )
            }
        };

        private readonly Random Rand;

        // private readonly MarkovWordGenerator MarkovNames;
        private readonly List<string> CensoredWords = new List<string>()
            { "fuck", "shit", "cunt", "rape", "cock", "nigg", "tits", "tard" };

        const int nameUnitSize = 2;
        const int minNameLength = 10;
        const int maxNameLength = 20; // TODO: Confirm. Should be equal to true limit minus 6 (for modifier prefixes).
        const int maxAttempts = 50;
        const double titledNameOdds = 0.2; //有名字的概率

        ZHWordGenerator Generator;


        public WeaponNameGenerator(Random random)
        {
            Rand = random;
            //  MarkovNames = new MarkovWordGenerator(Resources.TextData.AllWeaponNamesNoSuffix, unitSize: nameUnitSize, random: Rand);
            this.Generator = new ZHWordGenerator(Resources.TextData.AllWeaponNamesNoSuffix.Split('\n').ToList());
        }


        public static string GetSubClassCN(string weaponClass)
        {
            if (ClassOptions.ContainsKey((weaponClass)))
            {
                return ClassOptions[weaponClass].common[0];
            }
            else
            {
                Console.WriteLine("Unknown weapon class name: " + weaponClass);
                return weaponClass;
            }
        }

        public string GetRandomName(out string randomPart, string weaponClass = "", bool isLegendary = false,
            bool exact = false)
        {
            // bool isTitled = Rand.NextDouble() < titledNameOdds; //是否有原主人
            string className = weaponClass != "" ? GetRandomClassName(weaponClass, isLegendary) : "";
            int min = 5 - className.Length;
            if (min == 0) min += 1;
            randomPart = this.Generator.RandomWord(this.Rand, min, 6);
            var fullName = $"{randomPart}{className}";
            //  Console.WriteLine($"生成武器: <{fullName}>");
            // int actualMaxNameLength = className != "" ? (maxNameLength - (className.Length + (isTitled ? 4 : 1))) : maxNameLength;
            //  randomPart = "";
            return fullName;
        }


        //返回武器类名(后缀)
        string GetRandomClassName(string weaponClass, bool isLegendary)
        {
            if (weaponClass.ToLower() == "random")
            {
                int randomIndex = Rand.Next(ClassOptions.Count);
                weaponClass = ClassOptions.ElementAt(randomIndex).Key;
            }

            if (!ClassOptions.ContainsKey(weaponClass))
                throw new ArgumentException($"'{weaponClass}' is not a valid weapon class name.");
            if (isLegendary)
            {
                int randomIndex = Rand.Next(ClassOptions[weaponClass].legendary.Count);
                return ClassOptions[weaponClass].legendary[randomIndex];
            }
            else
            {
                int randomIndex = Rand.Next(ClassOptions[weaponClass].common.Count);
                return ClassOptions[weaponClass].common[randomIndex];
            }
        }

        //static string TrimName(string randomName, int randomNameLengthLimit)
        //{
        //    while (randomName.Length > randomNameLengthLimit)
        //        // Shave off letters (and trailing space) as needed.
        //        randomName = randomName.Substring(0, randomName.Length - 1).TrimEnd(' ');
        //    if (randomName.EndsWith("'"))
        //        // Shave off abandoned apostrophes.
        //        randomName = randomName.Substring(0, randomName.Length - 1);
        //    if (randomName[randomName.Length - 2] == ' ')
        //        // Shave off one-letter word.
        //        randomName = randomName.Substring(0, randomName.Length - 2);
        //    randomName = randomName.Trim(' ');  // Probably redundant, but just in case.
        //    return randomName;
        //}
    }

    class WeaponDescriptionGenerator
    {
        private readonly Random Rand;
        private readonly SmartMarkovProseGenerator MarkovDescriptions;
        ZHParagraphGenerator ParagraphGenerator;

        const int descriptionUnitSize = 2;
        const int requestedLength = 15;
        const int maxLineLength = 39; // TODO: Confirm.
        const int maxCharLength = 150;

        public WeaponDescriptionGenerator(Random random)
        {
            Rand = random;
            //MarkovDescriptions = new SmartMarkovProseGenerator(Resources.TextData.AllWeaponDescriptions, unitSize: descriptionUnitSize, random: Rand);
            ParagraphGenerator =
                new ZHParagraphGenerator(Resources.TextData.AllWeaponDescriptions.Split('\n').ToList());
        }

        public string GetRandomDescription(string extraParagraph = "", bool exact = false)
        {
            var res = this.ParagraphGenerator.RandomParagraph(this.Rand, 60, 100);
            //  Console.WriteLine($"武器描述信息: {res}");
            return res;
        }
    }

    class ArmorNameGenerator
    {
        public static ArmorNameOptionDict PieceNameOptions { get; } = new ArmorNameOptionDict()
        {
            {
                "Head", (
                    new List<string>() { "兜帽", "帽子", "面具" },
                    new List<string>() { "头盔", "头冠", "兜鍪", }
                )
            },
            {
                "Body", (
                    new List<string>() { "长袍", "披风", "大衣", "外套" },
                    new List<string>() { "盔甲", "铠甲", "链甲" }
                )
            },
            {
                "Arms", (
                    new List<string>() { "护手", "手套" },
                    new List<string>() { "臂甲", "手镯" }
                )
            },
            {
                "Legs", (
                    new List<string>() { "裤子", "裙子", "腰巾", "紧身裤", "长裤" },
                    new List<string>() { "护腿", "靴子", "脚链" }
                )
            },
        };

        private readonly Random Rand;
        private readonly MarkovWordGenerator MarkovNames;

        private readonly List<string> CensoredWords = new List<string>()
            { "fuck", "shit", "cunt", "rape", "cock", "nigg", "tits", "tard" };

        const int nameUnitSize = 2;
        const int minNameLength = 10;
        const int maxNameLength = 20; // TODO: Confirm. Should be equal to true limit minus 6 (for modifier prefixes).
        const int maxAttempts = 50;
        const double titledNameOdds = 0.2;
        ZHWordGenerator Generator;

        public ArmorNameGenerator(Random random)
        {
            Rand = random;
            //   MarkovNames = new MarkovWordGenerator(Resources.TextData.AllArmorNames, unitSize: nameUnitSize, random: Rand);
            this.Generator = new ZHWordGenerator(Resources.TextData.AllArmorNames.Split('\n').ToList());
        }

        public Dictionary<string, string> GetRandomSetNames(out string randomPart, bool isLegendary = false,
            bool exact = false)
        {
            // Generates a name for each armor piece type using the same random template.

            bool isTitled = Rand.NextDouble() < titledNameOdds;
            Dictionary<string, string> pieceNames = new Dictionary<string, string>();
            foreach (string pieceType in PieceNameOptions.Keys)
                pieceNames[pieceType] = GetRandomClassName(pieceType, isLegendary);

            randomPart = this.Generator.RandomWord(this.Rand, 3, 6); // Can use output to affect description (TODO).

            Dictionary<string, string> pieceFullNames = new Dictionary<string, string>();
            foreach (string pieceType in PieceNameOptions.Keys)
            {
                var fullName = $"{randomPart}{pieceNames[pieceType]}";
                //    Console.WriteLine($"生成盔甲: <{fullName}>");
                pieceFullNames[pieceType] = fullName;
            }

            return pieceFullNames;
        }

        string GetRandomClassName(string armorClass, bool isHeavy)
        {
            if (armorClass.ToLower() == "random")
            {
                int randomIndex = Rand.Next(PieceNameOptions.Count);
                armorClass = PieceNameOptions.ElementAt(randomIndex).Key;
            }

            if (!PieceNameOptions.ContainsKey(armorClass))
                throw new ArgumentException($"'{armorClass}' is not a valid weapon class name.");
            if (isHeavy)
            {
                int randomIndex = Rand.Next(PieceNameOptions[armorClass].heavy.Count);
                return PieceNameOptions[armorClass].heavy[randomIndex];
            }
            else
            {
                int randomIndex = Rand.Next(PieceNameOptions[armorClass].light.Count);
                return PieceNameOptions[armorClass].light[randomIndex];
            }
        }

        static string TrimName(string randomName, int randomNameLengthLimit)
        {
            while (randomName.Length > randomNameLengthLimit)
                // Shave off letters (and trailing space) as needed.
                randomName = randomName.Substring(0, randomName.Length - 1).TrimEnd(' ');
            if (randomName.EndsWith("'"))
                // Shave off abandoned apostrophes.
                randomName = randomName.Substring(0, randomName.Length - 1);
            if (randomName[randomName.Length - 2] == ' ')
                // Shave off one-letter word.
                randomName = randomName.Substring(0, randomName.Length - 2);
            randomName = randomName.Trim(' '); // Probably redundant, but just in case.
            return randomName;
        }
    }

    class ArmorDescriptionGenerator
    {
        private readonly Random Rand;

        // private readonly SmartMarkovProseGenerator MarkovDescriptions;
        ZHParagraphGenerator Generator;

        private static string[] PieceTypes { get; } = { "Head", "Body", "Arms", "Legs" };

        const int descriptionUnitSize = 2;
        const int requestedLength = 15;
        const int maxLineLength = 39;
        const int maxCharLength = 150;

        public ArmorDescriptionGenerator(Random random)
        {
            Rand = random;
            //  MarkovDescriptions = new SmartMarkovProseGenerator(Resources.TextData.AllArmorDescriptions, unitSize: descriptionUnitSize, random: Rand);
            this.Generator = new ZHParagraphGenerator(Resources.TextData.AllArmorDescriptions.Split('\n').ToList());
        }

        public Dictionary<string, string> GetRandomSetDescriptions(Dictionary<string, string> extraParagraphs,
            bool exact = false)
        {
            //string desc = MarkovDescriptions.Generate(requestedLength, exact);
            //while (desc.Length > maxCharLength && desc.Contains(","))  // Cut off at last comma.
            //    desc = desc.Substring(0, desc.LastIndexOf(',')) + ".";
            //string wrappedDesc = string.Join("\n", WordWrapper.WordWrap(desc, maxLineLength));
            var res = this.Generator.RandomParagraph(this.Rand, 60, 100);
            //   Console.WriteLine($"盔甲描述信息: {res}");
            Dictionary<string, string> wrappedPieceDescriptions = new Dictionary<string, string>();
            foreach (string pieceType in PieceTypes)
            {
                wrappedPieceDescriptions[pieceType] = res;
            }

            return wrappedPieceDescriptions;
        }
    }

    class NPCNameGenerator
    {
        Random Rand { get; }

        //  MarkovWordGenerator MarkovNames { get; }
        static List<string> CensoredWords { get; } = new List<string>()
            { "fuck", "shit", "cunt", "rape", "cock", "nigg", "tits", "tard" };

        static int NameUnitSize { get; } = 2;
        static int MinNameLength { get; } = 5;
        static int MaxNameLength { get; } = 26;
        static int MaxAttempts { get; } = 50;
        static double TitledNameOdds { get; } = 0.7; // Knight {Name}, Sorcerer {Name}, etc.
        static double OriginNameOdds { get; } = 0.5; // {Name} of {Place}
        static double MononymOdds { get; } = 0.5;
        static double SuffixNameOdds { get; } = 0.3; // "Oscar, Knight of Astora" rather than "Knight Oscar of Astora"

        private List<string> PlaceNames;

        private List<string> TitleNames;

        private string CharSet;


        public NPCNameGenerator(Random random)
        {
            Rand = random;
            //MarkovNames = new MarkovWordGenerator(Resources.TextData.AllNPCNames, unitSize: NameUnitSize, random: Rand);
            PlaceNames = new List<string>()
            {
                "卡塔利纳", "索尔隆德", "卡利姆", "小隆德", "东国", "亚斯特拉", "巴勒德尔", "伯尼斯",
                "乌拉席露", "彼海姆", "卡萨斯", "大沼", "隆道尔", "薄暮之国", "库尔兰", "米尔伍德"
            };
            TitleNames = new List<string>()
            {
                "骑士", "佣兵", "圣女", "战士", "铁匠", "圣骑士",
                "疗伤圣手", "暗月骑士", "太阳战士", "灰心战士", "魔女", "魔法师", "商人", "流浪者", "圣职",
                "武士", "咒术师", "公主", "王子", "修女", "侍女", "使者", "游魂", "小偷"
            };
            var splits = Resources.TextData.AllNPCNames.Split('\n');
            foreach (var sp in splits)
            {
                this.CharSet += sp.Trim();
            }
        }

        private string RandomName()
        {
            var len = Rand.Next(2, 6);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                builder.Append(this.CharSet[Rand.Next(0, this.CharSet.Length)]);
            }

            return builder.ToString();
        }

        public string GetRandomName(string npcTitle = "", bool exact = false)
        {
            var Place = this.PlaceNames[Rand.Next(this.PlaceNames.Count)];
            var sp = Rand.NextDouble() > 0.5 ? "的" : "";
            var Name = $"{Place}{sp}{npcTitle}{this.RandomName()}";
            if (Rand.NextDouble() > 0.6)
            {
                Name = $"{this.RandomName()},{Place}的{npcTitle}";
            }

            // Console.WriteLine($"NPC名字: {Name}");

            return Name;
        }
    }

    class BossNameGenerator
    {
        private readonly Random Rand;
        private readonly MarkovWordGenerator MarkovNames;

        private readonly List<string> CensoredWords = new List<string>()
            { "fuck", "shit", "cunt", "rape", "cock", "nigg", "tits", "tard" };

        const int nameUnitSize = 2;
        const int minNameLength = 5;
        const int maxNameLength = 30;
        const int maxAttempts = 50;
        //private List<string> TitleNames = new List<string>() { "恶魔", "火焰恶魔", "离群恶魔", "不死院恶魔", "巨偶", "猎龙者", "刽子手", "薪王", "暗月" };

        public BossNameGenerator(Random random)
        {
            Rand = random;
            MarkovNames =
                new MarkovWordGenerator(Resources.TextData.AllBossNames, unitSize: nameUnitSize, random: Rand);
        }

        public string GetRandomName(bool exact = false)
        {
            // Keeps trying to get a name that is naturally under the absolute max limit.
            string randomName;
            int attempts = 0;
            do
            {
                randomName = MarkovNames.Generate(minNameLength, exact);
                attempts++;
                if (attempts >= maxAttempts)
                    break; // keep last name and trim
            } while (randomName.Length > maxNameLength || randomName.ToLower().ContainsAny(CensoredWords));

            if (randomName.Length > maxNameLength)
            {
                // If max attempt number is exceeded (unlikely), just use a single random name.
                randomName = MarkovNames.Generate(minNameLength, exact: true);
            }

            //  Console.WriteLine($"Boss Name: {randomName}");
            return randomName;
        }
    }

    class SpellNameGenerator
    {
        private readonly Random Rand;
        // private readonly MarkovWordGenerator MarkovNames;
        // private readonly List<string> CensoredWords = new List<string>() { "fuck", "shit", "cunt", "rape", "cock", "nigg", "tits", "tard" };

        ZHWordGenerator Generator;


        const int nameUnitSize = 2;
        const int minNameLength = 8;
        const int maxNameLength = 30;
        const int maxAttempts = 50;


        public SpellNameGenerator(Random random)
        {
            Rand = random;
            // MarkovNames = new MarkovWordGenerator(Resources.TextData.AllSpellNames, unitSize: nameUnitSize, random: Rand);

            var spellNames = Resources.TextData.AllSpellNames.Split('\n').ToList();
            this.Generator = new ZHWordGenerator(spellNames);
        }


        public string GetRandomName(string spellType, bool exact = false)
        {
            string type = "";
            if (spellType == "Sorcery")
            {
                type = "魔法";
            }
            else if (spellType == "Pyromancy")
            {
                type = "咒术";
            }
            else if (spellType == "Miracle")
            {
                type = "奇迹";
            }

            var name = type + ": " + this.Generator.RandomWord(this.Rand, 3, 7).Trim();
            //  Console.WriteLine($"法术名字: <{name}>");
            return name;
        }
    }

    class SpellDescriptionGenerator
    {
        private readonly Random Rand;
        private ZHParagraphGenerator ParagraphGenerator;

        public SpellDescriptionGenerator(Random random)
        {
            Rand = random;
            this.ParagraphGenerator = new ZHParagraphGenerator(Resources.TextData.AllSpellDescriptions.Split('\n').ToList());
        }

        public string GetRandomDescription(bool exact = false)
        {
            return this.ParagraphGenerator.RandomParagraph(this.Rand, 60, 100);
        }
    }
}