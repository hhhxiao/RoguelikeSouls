using SoulsFormatsMod;
using System;
using System.Collections.Generic;
using SoulsFormatsMod.PARAMS;
using RoguelikeSouls.Utils;
using RoguelikeSouls.Extensions;
using System.Linq;

namespace RoguelikeSouls.Installation
{
    enum TreasureType
    {
        None = 0, // no reward (used in random selection)
        CommonItem = 1, // e.g. Firebomb
        UncommonItem = 2, // e.g. Black Firebomb
        RareItem = 3, // e.g. Divine Blessing, Mote
        VeryRareItem = 4, // e.g. Soul of a Hero, Tome
        BasicWeapon = 5,
        BasicArmor = 6,
        LegendaryWeapon = 7,
        LegendaryArmor = 8,
        AbyssalWeapon = 9,
        AbyssalArmor = 10,
        Spell = 11,
        Ember = 13,
        Key = 14,
        CorpseRenewable = 15, // Common/Uncommon/Rare/VeryRare, depending on map rating
        ChestRenewable = 16, // Common/Uncommon/Rare/VeryRare, depending on map rating
    }

    class Treasure
    {
        public string Name { get; }
        public ItemLotCategory Category;
        public int ItemID { get; }
        public TreasureType Type { get; }
        public int MaxCount { get; }
        public Label[] Labels { get; }

        public Treasure(string name, ItemLotCategory category, int itemID, TreasureType rewardType, int maxCount,
            params Label[] labels)
        {
            Name = name;
            Category = category;
            ItemID = itemID;
            Type = rewardType;
            MaxCount = maxCount;
            Labels = labels;
        }
    }

    static class Treasures
    {
        public static List<Treasure> RenewableList { get; } = new List<Treasure>()
        {
            // Rewards that can be used in multiple item lots ("renewable").
            new Treasure("Elizabeth's Mushroom", ItemLotCategory.Good, 230, TreasureType.RareItem, 1, Label.Divine,
                Label.Plant),
            new Treasure("Divine Blessing", ItemLotCategory.Good, 240, TreasureType.RareItem, 1, Label.Divine,
                Label.Sapient, Label.Mimic),
            new Treasure("Green Blossom", ItemLotCategory.Good, 260, TreasureType.UncommonItem, 1, Label.Plant),
            new Treasure("Bloodred Moss Clump", ItemLotCategory.Good, 270, TreasureType.CommonItem, 1, Label.Infested,
                Label.Plant),
            new Treasure("Purple Moss Clump", ItemLotCategory.Good, 271, TreasureType.CommonItem, 1, Label.Poison,
                Label.Infested, Label.Plant),
            new Treasure("Blooming Purple Moss Clump", ItemLotCategory.Good, 272, TreasureType.UncommonItem, 1,
                Label.Poison, Label.Infested, Label.Plant),
            new Treasure("Purging Stone", ItemLotCategory.Good, 274, TreasureType.RareItem, 1, Label.Divine,
                Label.Stone),
            new Treasure("Egg Vermifuge", ItemLotCategory.Good, 275, TreasureType.RareItem, 1, Label.Bug,
                Label.Infested),
            new Treasure("Repair Powder", ItemLotCategory.Good, 280, TreasureType.RareItem, 1, Label.Metal,
                Label.Sapient),
            new Treasure("Throwing Knife", ItemLotCategory.Good, 290, TreasureType.CommonItem, 10, Label.Sapient),
            new Treasure("Poison Throwing Knife", ItemLotCategory.Good, 291, TreasureType.UncommonItem, 5,
                Label.Sapient, Label.Poison),
            new Treasure("Firebomb", ItemLotCategory.Good, 292, TreasureType.CommonItem, 5, Label.Sapient, Label.Fire),
            new Treasure("Dung Pie", ItemLotCategory.Good, 293, TreasureType.UncommonItem, 1, Label.Poison,
                Label.Infested),
            new Treasure("Alluring Skull", ItemLotCategory.Good, 294, TreasureType.UncommonItem, 1, Label.Sapient,
                Label.Magic),
            new Treasure("Lloyd's Talisman", ItemLotCategory.Good, 296, TreasureType.UncommonItem, 1, Label.Sapient,
                Label.Divine),
            new Treasure("Black Firebomb", ItemLotCategory.Good, 297, TreasureType.UncommonItem, 5, Label.Sapient,
                Label.Fire),
            new Treasure("Charcoal Pine Resin", ItemLotCategory.Good, 310, TreasureType.RareItem, 1, Label.Fire,
                Label.Plant),
            new Treasure("Gold Pine Resin", ItemLotCategory.Good, 311, TreasureType.RareItem, 1, Label.Lightning,
                Label.Plant),
            new Treasure("Transient Curse", ItemLotCategory.Good, 312, TreasureType.UncommonItem, 1, Label.Ghost),
            new Treasure("Rotten Pine Resin", ItemLotCategory.Good, 313, TreasureType.RareItem, 1, Label.Poison,
                Label.Plant),
            new Treasure("Homeward Bone", ItemLotCategory.Good, 330, TreasureType.UncommonItem, 1, Label.Sapient,
                Label.Skeleton),
            new Treasure("Prism Stone", ItemLotCategory.Good, 370, TreasureType.UncommonItem, 3, Label.Sapient,
                Label.Crystal, Label.Stone),
            new Treasure("Soul of a Lost Undead", ItemLotCategory.Good, 400, TreasureType.CommonItem, 1, Label.Hollow),
            new Treasure("Large Soul of a Lost Undead", ItemLotCategory.Good, 401, TreasureType.CommonItem, 1,
                Label.Hollow),
            new Treasure("Soul of a Nameless Soldier", ItemLotCategory.Good, 402, TreasureType.CommonItem, 1,
                Label.Hollow),
            new Treasure("Large Soul of a Nameless Soldier", ItemLotCategory.Good, 403, TreasureType.UncommonItem, 1,
                Label.Hollow),
            new Treasure("Soul of a Proud Knight", ItemLotCategory.Good, 404, TreasureType.UncommonItem, 1,
                Label.Hollow),
            new Treasure("Large Soul of a Proud Knight", ItemLotCategory.Good, 405, TreasureType.UncommonItem, 1,
                Label.Hollow),
            new Treasure("Soul of a Brave Warrior", ItemLotCategory.Good, 406, TreasureType.RareItem, 1, Label.Hollow),
            new Treasure("Large Soul of a Brave Warrior", ItemLotCategory.Good, 407, TreasureType.RareItem, 1,
                Label.Hollow),
            new Treasure("Soul of a Hero", ItemLotCategory.Good, 408, TreasureType.VeryRareItem, 1, Label.Hollow),
            new Treasure("Soul of a Great Hero", ItemLotCategory.Good, 409, TreasureType.VeryRareItem, 1, Label.Hollow),
            new Treasure("Humanity", ItemLotCategory.Good, 500, TreasureType.UncommonItem, 1, Label.Abyssal,
                Label.Sapient),
            new Treasure("Twin Humanities", ItemLotCategory.Good, 501, TreasureType.RareItem, 1, Label.Abyssal,
                Label.Sapient),

            new Treasure("Mote of Vitality", ItemLotCategory.Good, 650, TreasureType.RareItem, 1),
            new Treasure("Mote of Attunement", ItemLotCategory.Good, 651, TreasureType.RareItem, 1),
            new Treasure("Mote of Endurance", ItemLotCategory.Good, 652, TreasureType.RareItem, 1),
            new Treasure("Mote of Strength", ItemLotCategory.Good, 653, TreasureType.RareItem, 1),
            new Treasure("Mote of Dexterity", ItemLotCategory.Good, 654, TreasureType.RareItem, 1),
            new Treasure("Mote of Resistance", ItemLotCategory.Good, 655, TreasureType.RareItem, 1),
            new Treasure("Mote of Intelligence", ItemLotCategory.Good, 656, TreasureType.RareItem, 1),
            new Treasure("Mote of Faith", ItemLotCategory.Good, 657, TreasureType.RareItem, 1),

            new Treasure("Tome of Vitality", ItemLotCategory.Good, 660, TreasureType.VeryRareItem, 1),
            new Treasure("Tome of Attunement", ItemLotCategory.Good, 661, TreasureType.VeryRareItem, 1),
            new Treasure("Tome of Endurance", ItemLotCategory.Good, 662, TreasureType.VeryRareItem, 1),
            new Treasure("Tome of Strength", ItemLotCategory.Good, 663, TreasureType.VeryRareItem, 1),
            new Treasure("Tome of Dexterity", ItemLotCategory.Good, 664, TreasureType.VeryRareItem, 1),
            new Treasure("Tome of Resistance", ItemLotCategory.Good, 665, TreasureType.VeryRareItem, 1),
            new Treasure("Tome of Intelligence", ItemLotCategory.Good, 666, TreasureType.VeryRareItem, 1),
            new Treasure("Tome of Faith", ItemLotCategory.Good, 667, TreasureType.VeryRareItem, 1),

            // new Treasure("Standard Arrow",                        ItemLotCategory.Weapon, 2000000, TreasureType.CommonItem, 20, Label.Sapient, Label.Archer),
            // new Treasure("Large Arrow",                           ItemLotCategory.Weapon, 2001000, TreasureType.CommonItem, 20, Label.Sapient, Label.Archer),
            new Treasure("Feather Arrow", ItemLotCategory.Weapon, 2002000, TreasureType.UncommonItem, 20, Label.Sapient,
                Label.Archer),
            new Treasure("Fire Arrow", ItemLotCategory.Weapon, 2003000, TreasureType.UncommonItem, 20, Label.Sapient,
                Label.Archer, Label.Poison),
            new Treasure("Poison Arrow", ItemLotCategory.Weapon, 2004000, TreasureType.UncommonItem, 20, Label.Sapient,
                Label.Archer, Label.Fire),
            new Treasure("Moonlight Arrow", ItemLotCategory.Weapon, 2005000, TreasureType.UncommonItem, 20,
                Label.Sapient, Label.Archer, Label.Divine),
            // new Treasure("Wooden Arrow",                          ItemLotCategory.Weapon, 2006000, TreasureType.CommonItem, 20, Label.Sapient, Label.Archer, Label.Infested),
            new Treasure("Dragonslayer Arrow", ItemLotCategory.Weapon, 2007000, TreasureType.RareItem, 10,
                Label.Sapient, Label.Archer, Label.Dragon),
            new Treasure("Gough's Great Arrow", ItemLotCategory.Weapon, 2008000, TreasureType.RareItem, 10,
                Label.Sapient, Label.Archer, Label.Dragon),

            // new Treasure("Standard Bolt",                         ItemLotCategory.Weapon, 2100000, TreasureType.UncommonItem, 20, Label.Sapient, Label.Archer),
            new Treasure("Heavy Bolt", ItemLotCategory.Weapon, 2101000, TreasureType.UncommonItem, 20, Label.Sapient,
                Label.Archer, Label.Metal),
            new Treasure("Sniper Bolt", ItemLotCategory.Weapon, 2102000, TreasureType.UncommonItem, 20, Label.Sapient,
                Label.Archer),
            // new Treasure("Wood Bolt",                             ItemLotCategory.Weapon, 2103000, TreasureType.CommonItem, 20, Label.Sapient, Label.Archer),
            new Treasure("Lightning Bolt", ItemLotCategory.Weapon, 2104000, TreasureType.RareItem, 15, Label.Sapient,
                Label.Archer, Label.Lightning),

            new Treasure("Refined Ember", ItemLotCategory.Good, 1000, TreasureType.Ember, 1, Label.Metal),
            new Treasure("Crystal Ember", ItemLotCategory.Good, 1010, TreasureType.Ember, 1, Label.Crystal),
            new Treasure("Magic Ember", ItemLotCategory.Good, 1020, TreasureType.Ember, 1, Label.Magic),
            new Treasure("Enchanted Ember", ItemLotCategory.Good, 1030, TreasureType.Ember, 1, Label.Magic),
            new Treasure("Lightning Ember", ItemLotCategory.Good, 1040, TreasureType.Ember, 1, Label.Lightning),
            new Treasure("Divine Ember", ItemLotCategory.Good, 1050, TreasureType.Ember, 1, Label.Divine),
            new Treasure("Dire Ember", ItemLotCategory.Good, 1060, TreasureType.Ember, 1, Label.Divine),
            new Treasure("Blazing Ember", ItemLotCategory.Good, 1070, TreasureType.Ember, 1, Label.Fire),
            new Treasure("Dragonfire Ember", ItemLotCategory.Good, 1080, TreasureType.Ember, 1, Label.Dragon),

            new Treasure("Small Titanite Piece", ItemLotCategory.Good, 1100, TreasureType.CommonItem, 1, Label.Stone,
                Label.Metal),
            new Treasure("Large Titanite Piece", ItemLotCategory.Good, 1110, TreasureType.UncommonItem, 1, Label.Stone,
                Label.Metal),
            new Treasure("Giant Titanite Piece", ItemLotCategory.Good, 1120, TreasureType.RareItem, 1, Label.Stone,
                Label.Metal),
            new Treasure("Colossal Titanite Piece", ItemLotCategory.Good, 1130, TreasureType.VeryRareItem, 1,
                Label.Stone, Label.Metal),
        };

        public static Treasure GetCorpseRenewable(int mapRating, Random random)
        {
            double roll = random.NextDouble();
            if (roll < (0.01 * Math.Abs(mapRating)))
                return GetRandomReward(TreasureType.VeryRareItem, random);
            else if (roll < (0.05 * Math.Abs(mapRating)))
                return GetRandomReward(TreasureType.RareItem, random);
            else if (roll < (0.25 * Math.Abs(mapRating)))
                return GetRandomReward(TreasureType.UncommonItem, random);
            else
                return GetRandomReward(TreasureType.CommonItem, random);
        }

        public static Treasure GetChestRenewable(int mapRating, Random random)
        {
            double roll = random.NextDouble();
            if (roll < (0.05 * Math.Abs(mapRating)))
                return GetRandomReward(TreasureType.VeryRareItem, random);
            else if (roll < (0.3 * Math.Abs(mapRating)))
                return GetRandomReward(TreasureType.RareItem, random);
            else
                return GetRandomReward(TreasureType.UncommonItem, random);
        }

        public static Treasure GetRandomReward(TreasureType treasureType, Random random)
        {
            List<Treasure> options = new List<Treasure>(RenewableList.Where(treasure => treasure.Type == treasureType));
            return options.GetRandomElement(random);
        }

        public static Treasure GetRandomReward(TreasureType treasureType, Label[] labels,
            List<(ItemLotCategory, int)> usedItems, Random random)
        {
            List<Treasure> options = new List<Treasure>(RenewableList.Where(
                treasure => treasure.Type == treasureType && treasure.Labels.Intersect(labels).Any()));
            if (!options.Any())
                // No items of this rarity for this list of labels (e.g. Demonic only). Any label is permitted.
                options = new List<Treasure>(RenewableList.Where(treasure => treasure.Type == treasureType));
            // Exclude used treasure.
            options = new List<Treasure>(options.Where(treasure =>
                !usedItems.Contains((treasure.Category, treasure.ItemID))));
            return options.Any()
                ? options.GetRandomElement(random)
                : null; // If all available treasure is used, no item in this slot.
        }

        public static Treasure GetRandomRewardWeightedByLabel(TreasureType type, Label[] labels, Random random)
        {
            // Returns a random "renewable" reward for an enemy drop with any of the given labels. 
            // Rewards that share more labels with the given list are proportionately 
            // more likely to be chosen.
            Dictionary<Treasure, int> weightDict = new Dictionary<Treasure, int>();
            foreach (Treasure reward in RenewableList)
            {
                IEnumerable<Label> sharedLabels = reward.Labels.Intersect(labels);
                if (reward.Type == type && sharedLabels.Any())
                    weightDict[reward] = sharedLabels.Count();
            }

            return weightDict.GetWeightedRandomElement(random);
        }
    }

    class GoodsGenerator
    {
        public static Dictionary<string, string> CNNames { get; } = new Dictionary<string, string>()
        {
            { "Hand of Cessation", "停止之手" },
            { "Undead Flame", "不死火焰" },
            { "Mark of Death", "死亡印记" },
            { "Heart of St. Jude", "圣裘德之心" },

            { "Refined Ember", "精制余烬" },
            { "Crystal Ember", "结晶余烬" },
            { "Magic Ember", "法术余烬" },
            { "Enchanted Ember", "魔力余烬" },
            { "Lightning Ember", "雷电余烬" },
            { "Divine Ember", "烬神圣余烬" },
            { "Dire Ember", "邪教余烬" },
            { "Blazing Ember", "火焰余烬" },
            { "Dragonfire Ember", "龙族余烬" },

            { "Small Titanite Piece", "小楔形石碎片 " },
            { "Large Titanite Piece", "中型楔形石碎片" },
            { "Giant Titanite Piece", "大楔形石碎片" },
            { "Colossal Titanite Piece", "巨大楔形石碎片" },

            { "Rusted Key", "生锈钥匙" },
            { "Tarnished Key", "晦暗钥匙" },
            { "Polished Key", "抛光钥匙" },
            { "Giant Key", "巨大钥匙" },
            { "Holy Sigil", "神圣徽记" },
            { "Piercing Eye", "穿刺只眼" },
            { "Skeleton Keys", "骷髅钥匙" },

            { "Mote of Vitality", "体力微粒" },
            { "Mote of Attunement", "记忆力微粒" },
            { "Mote of Endurance", "耐力微粒" },
            { "Mote of Strength", "力量微粒" },
            { "Mote of Dexterity", "增加灵巧微粒" },
            { "Mote of Resistance", "抗性微粒" },
            { "Mote of Intelligence", "智力微粒" },
            { "Mote of Faith", "信仰微粒" },
            { "Tome of Vitality", "体力只书" },
            { "Tome of Attunement", "记忆力之书" },
            { "Tome of Endurance", "耐力之书" },
            { "Tome of Strength", "力量之书" },
            { "Tome of Dexterity", "灵巧之书" },
            { "Tome of Resistance", "抗性之书" },
            { "Tome of Intelligence", "智力之书" },
            { "Tome of Faith", "大幅增加信仰" },
            { "Alvina's Ring", "雅薇娜戒指" },

            { "Solaire's Ring", "索拉尔戒指" },
            { "Siegmeyer's Ring", "杰克麦雅的戒指" },
            { "Logan's Ring", "罗根戒指" },
            { "Quelana's Ring", "克拉娜友谊的戒指" },
            { "Havel's Ring", "哈维尔友谊的戒指" },
            { "Mornstein's Ring", "莫恩斯坦戒指" },
            { "Lobos Jr's Ring", "小洛博斯戒指" }
        };

        public static Dictionary<string, string> Summaries { get; } = new Dictionary<string, string>()
        {
            { "Hand of Cessation", "带有邪恶意图的死亡遗物" },
            { "Undead Flame", "篝火点的燃火花" },
            { "Mark of Death", "死亡时获得的物品" },
            { "Heart of St. Jude", "建立联系的炽热核心" },

            { "Refined Ember", "武器质变余烬" },
            { "Crystal Ember", "武器质变余烬" },
            { "Magic Ember", "武器质变余烬" },
            { "Enchanted Ember", "武器质变余烬" },
            { "Lightning Ember", "武器质变余烬" },
            { "Divine Ember", "武器质变余烬" },
            { "Dire Ember", "武器质变余烬" },
            { "Blazing Ember", "武器质变余烬" },
            { "Dragonfire Ember", "武器质变余烬" },
            { "Small Titanite Piece", "盔甲升级材料" },
            { "Large Titanite Piece", "盔甲升级材料" },
            { "Giant Titanite Piece", "盔甲升级材料" },
            { "Colossal Titanite Piece", "盔甲升级材料" },
            //
            { "Rusted Key", "打开旧木门的钥匙" },
            { "Tarnished Key", "打开加固门的钥匙" },
            { "Polished Key", "打开一些金属门的钥匙" },
            { "Giant Key", "打开巨大大门的钥匙" },
            { "Holy Sigil", "授予使用电梯的徽记" },
            { "Piercing Eye", "幻觉破坏者" },
            { "Skeleton Keys", "打开大多数锁的钥匙" },


            //
            { "Mote of Vitality", "增加体力" },
            { "Mote of Attunement", "增加记忆力" },
            { "Mote of Endurance", "增加耐力" },
            { "Mote of Strength", "增加力量" },
            { "Mote of Dexterity", "增加灵巧" },
            { "Mote of Resistance", "增加抗性" },
            { "Mote of Intelligence", "增加智力" },
            { "Mote of Faith", "增加信仰" },

            { "Tome of Vitality", "大幅增加体力" },
            { "Tome of Attunement", "大幅增加记忆力" },
            { "Tome of Endurance", "大幅增加耐力" },
            { "Tome of Strength", "大幅增加力量" },
            { "Tome of Dexterity", "大幅增加灵巧" },
            { "Tome of Resistance", "大幅增加抗性" },
            { "Tome of Intelligence", "大幅增加智力" },
            { "Tome of Faith", "大幅增加信仰" }
        };


        public static Dictionary<string, string> Descriptions { get; } = new Dictionary<string, string>()
        {
            { "Hand of Cessation", "一根扭曲肢体的一部分，来自某个古老怪物。\n每当其不死的携带者在罗德兰面临死亡时，手指似乎会逐一卷曲。\n手动捏紧它们可提前返回传火祭祀场。" },
            { "Undead Flame", "不死之火的不朽火花，有点像暗记的戒指。\n在罗德兰中创建篝火时使用，但要注意每个区域只能点燃一个篝火。" },
            { "Mark of Death", "死亡时出现在物品栏中的不安的知觉之眼。\n似乎只有传火祭祀场的光芒才能吓退这些虚幻的存在。" },
            { "Heart of St. Jude", "所有同伴情感的燃烧之心。\n据说凝视火焰，可以瞥见一个永远不必独处的未来。\n释放它以永久增加敌人的难度。" },

            //
            { "Refined Ember", "古老的铁匠余烬之一。用它来精炼任何基础武器的刃缘或分量，可提供适度的攻击力增加。" },
            { "Crystal Ember", "古老的铁匠余烬之一。用它来在任何基础武器上加工实心结晶，可在损耗耐久度的代价下大幅增加伤害。结晶武器无法修复。" },
            { "Magic Ember", "古老的铁匠余烬之一。用它来赋予武器魔力，增加魔法伤害。" },

            { "Enchanted Ember", "古老的铁匠余烬之一。用它来赋予武器巫术的饥渴，适度增加魔法伤害，并在击中敌人时重新充能法术。" },
            { "Lightning Ember", "古老的铁匠余烬之一。用它来赋予武器雷电之力，对穿甲的敌人特别有效，并对龙类有中等效果。" },

            { "Divine Ember", "古老的铁匠余烬之一。用它来赋予武器神圣的力量，增加神圣魔法伤害，对复活的亡灵尤为有效。" },
            { "Dire Ember", "古老的铁匠余烬之一，被认为已经失传。用它来赋予武器自身必死的一部分，提供与死亡的接近程度成比例的伤害增加。" },
            { "Blazing Ember", "古老的铁匠余烬之一。用它来赋予武器灼热的热量，可以将无甲敌人烤成焦炭。" },
            { "Dragonfire Ember", "古老的铁匠余烬之一，被认为已经失传。用它来赋予武器龙之火的惊人热量，对击中的敌人造成持续伤害，并能熔化龙鳞。小心挥舞这样的火焰。" },

            {
                "Small Titanite Piece",
                "一小块破碎的楔形石块，可用于轻微的盔甲强化。"
            },
            {
                "Large Titanite Piece",
                "一大块破碎的楔形石块，可用于中度的盔甲强化。"
            },
            {
                "Giant Titanite Piece",
                "一块巨大的破碎的楔形石块，可用于强烈的盔甲强化。"
            },
            {
                "Colossal Titanite Piece",
                "一块几乎无瑕的楔形石块，可用于极端的盔甲强化。"
            },

            {
                "Rusted Key",
                "简单的钥匙，保养较差最终被丢弃。\n可以打开一些老旧木门上的锁。"
            },
            {
                "Tarnished Key",
                "简单的钥匙，开始显示出许多年代的迹象。\n可以打开一些较新的木门上的锁。"
            },
            {
                "Polished Key",
                "带有一些刮痕的简单钥匙。\n可以打开一些金属门上的锁。"
            },
            {
                "Giant Key",
                "深渊中巨大门的大钥匙，\n可能还能打开其他的门。"
            },
            {
                "Holy Sigil",
                "罗德兰中许多升降梯所需的神圣石印。"
            },
            {
                "Piercing Eye",
                "令人不安的蓝色眼球。\n持有者可以穿透一些幻象。"
            },
            {
                "Skeleton Keys",
                "带有多把钥匙的钥匙串，\n一起可以打开罗德兰中大多数门。"
            },
            {
                "Mote of Vitality",
                "木雕。不知何故，咀嚼它会略微增加体力，\n尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Mote of Attunement",
                "木雕。不知何故，咀嚼它会略微增加记忆力，\n尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Mote of Endurance",
                "木雕。不知何故，咀嚼它会略微增加耐力，\n尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Mote of Strength",
                "木雕。不知何故，咀嚼它会略微增加力量，\n尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Mote of Dexterity",
                "木雕。不知何故，咀嚼它会略微增加灵巧，\n尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Mote of Resistance",
                "木雕。不知何故，咀嚼它会略微增加抗性，\n尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Mote of Intelligence",
                "木雕。不知何故，咀嚼它会略微增加智力，\n尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Mote of Faith",
                "木雕。不知何故，咀嚼它会略微增加信仰，\n尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Tome of Vitality",
                "来自一本古老书籍的一页。可以传授力量，\n使体力大幅增加，尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Tome of Attunement",
                "来自一本古老书籍的一页。可以传授力量，\n使记忆力大幅增加，尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Tome of Endurance",
                "来自一本古老书籍的一页。可以传授力量，\n使耐力大幅增加，尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Tome of Strength",
                "来自一本古老书籍的一页。可以传授力量，\n使力量大幅增加，尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Tome of Dexterity",
                "来自一本古老书籍的一页。可以传授力量，\n使灵巧大幅增加，尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Tome of Resistance",
                "来自一本古老书籍的一页。可以传授力量，\n使抗性大幅增加，尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Tome of Intelligence",
                "来自一本古老书籍的一页。可以传授力量，\n使智力大幅增加，尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Tome of Faith",
                "来自一本古老书籍的一页。可以传授力量，\n使信仰大幅增加，尽管这个恩惠在返回传火祭祀场时会失去。"
            },
            {
                "Alvina's Ring",
                "标志着与神秘的雅薇娜友谊的戒指。\n减缓「终结之手」的衰减，将传火祭祀场外不死生命的次数从五次增加到九次。"
            },
            {
                "Solaire's Ring",
                "标志着与欢乐的索拉尔友谊的戒指。\n允许佩戴者在放置篝火后移动它，尽管在每个区域只能使用一次。"
            },
            {
                "Siegmeyer's Ring",
                "标志着与不懈的杰克麦雅友谊的戒指。\n在佩戴者从传火祭祀场冒险时给予一些关心。\n除了提醒人们坚忍伙伴关系的喜悦外，没有其他效果。"
            },
            {
                "Logan's Ring",
                "标志着与好奇的罗根友谊的戒指。\n增加通往深渊的传送门出现的几率，这不应该轻易进入。"
            },
            {
                "Quelana's Ring",
                "标志着与古老的克拉娜友谊的戒指。\n在旅程开始时给予佩戴者三种炼狱术，并提供对岩浆的一些抵抗力。"
            },
            {
                "Havel's Ring",
                "标志着与不可战胜的哈维尔友谊的戒指。\n大幅增加佩戴者的最大装备负重，使旅行更加轻松。"
            },
            {
                "Mornstein's Ring",
                "标志着与莫恩斯坦，利奥尼安国王和无畏战士的友谊的戒指。\n增加遇到非常强大敌人的几率，战胜它们可能会带来更优质的战利品。"
            },
            {
                "Lobos Jr's Ring",
                "标志着与小洛博斯，冒险家们永恒的盟友的友谊的戒指。\n佩戴者将会在罗德兰中的旅程变得更加漫长，其敌人变得更加稀少和多样化。"
            }
        };

        public static Dictionary<string, ushort> Icons = new Dictionary<string, ushort>()
        {
            { "White Sign Soapstone", 2000 },
            { "Red Sign Soapstone", 2001 },
            { "Red Eye Orb", 2002 },
            { "Black Separation Crystal", 2003 },
            { "Orange Guidance Soapstone", 2082 },
            { "Book of the Guilty", 2009 },
            { "Eye of Death", 2087 },
            { "Cracked Red Eye Orb", 2006 },
            { "Servant Roster", 2007 },
            { "Blue Eye Orb", 2010 },
            { "Dragon Eye", 2011 },
            { "Black Eye Orb", 2132 },
            { "Darksign", 2145 },
            { "Purple Coward's Crystal", 2148 },
            { "Estus Flask Empty", 2004 },
            { "Estus Flask", 2005 },
            { "Silver Pendant", 2157 },
            { "Elizabeth's Mushroom", 2158 },
            { "Divine Blessing", 2012 },
            { "Green Blossom", 2014 },
            { "Bloodred Moss Clump", 2015 },
            { "Purple Moss Clump", 2016 },
            { "Blooming Purple Moss Clump", 2017 },
            { "Purging Stone", 2019 },
            { "Egg Vermifuge", 2013 },
            { "Repair Powder", 2020 },
            { "Throwing Knife", 2021 },
            { "Poison Throwing Knife", 2022 },
            { "Firebomb", 2023 },
            { "Dung Pie", 2024 },
            { "Alluring Skull", 2025 },
            { "Lloyd's Talisman", 2027 },
            { "Black Firebomb", 2026 },
            { "Charcoal Pine Resin", 2028 },
            { "Gold Pine Resin", 2029 },
            { "Transient Curse", 2030 },
            { "Rotten Pine Resin", 2031 },
            { "Homeward Bone", 2034 },
            { "Prism Stone", 2042 },
            { "Binoculars", 2043 },
            { "Indictment", 2041 },
            { "Souvenir of Reprisal", 2032 },
            { "Sunlight Medal", 2035 },
            { "Pendant", 2037 },
            { "Dragon Head Stone", 2121 },
            { "Dragon Torso Stone", 2122 },
            { "Rubbish", 2038 },
            { "Copper Coin", 2039 },
            { "Silver Coin", 2040 },
            { "Gold Coin", 2055 },
            { "Peculiar Doll", 2146 },
            { "Dried Finger", 2129 },
            { "Fire Keeper Soul", 2086 },
            { "Soul of a Lost Undead", 2045 },
            { "Large Soul of a Lost Undead", 2046 },
            { "Soul of a Nameless Soldier", 2047 },
            { "Large Soul of a Nameless Soldier", 2048 },
            { "Soul of a Proud Knight", 2049 },
            { "Large Soul of a Proud Knight", 2050 },
            { "Soul of a Brave Warrior", 2051 },
            { "Large Soul of a Brave Warrior", 2052 },
            { "Soul of a Hero", 2053 },
            { "Soul of a Great Hero", 2054 },
            { "Humanity", 2112 },
            { "Twin Humanities", 2113 },
            { "Hello Carving", 2149 },
            { "Thank you Carving", 2150 },
            { "Very good! Carving", 2151 },
            { "I'm sorry Carving", 2152 },
            { "Help me! Carving", 2153 },
            { "Soul of Quelaag", 2114 },
            { "Soul of Sif", 2115 },
            { "Soul of Gwyn, Lord of Cinder", 2116 },
            { "Core of an Iron Golem", 2117 },
            { "Soul of Ornstein", 2118 },
            { "Soul of the Moonlight Butterfly", 2119 },
            { "Soul of Smough", 2120 },
            { "Soul of Priscilla", 2133 },
            { "Soul of Gwyndolin", 2134 },
            { "Guardian Soul", 2154 },
            { "Soul of Artorias", 2155 },
            { "Soul of Manus", 2156 },

            { "Large Ember", 2109 },
            { "Very Large Ember", 2070 },
            { "Crystal Large Ember", 2071 },
            { "Large Magic Ember", 2073 },
            { "Enchanted Ember", 2074 },
            { "Divine Ember", 2110 },
            { "Large Divine Ember", 2075 },
            { "Dark Ember", 2076 },
            { "Large Flame Ember", 2077 },
            { "Chaos Flame Ember", 2078 },

            { "Titanite Shard", 2090 },
            { "Large Titanite Shard", 2091 },
            { "Green Titanite Shard", 2092 },
            { "Titanite Chunk", 2093 },
            { "Blue Titanite Chunk", 2094 },
            { "White Titanite Chunk", 2095 },
            { "Red Titanite Chunk", 2096 },
            { "Titanite Slab", 2097 },
            { "Blue Titanite Slab", 2098 },
            { "White Titanite Slab", 2099 },
            { "Red Titanite Slab", 2100 },
            { "Dragon Scale", 2111 },
            { "Demon Titanite", 2036 },
            { "Twinkling Titanite", 2123 },

            { "Basement Key", 2135 },
            { "Crest of Artorias", 2136 },
            { "Cage Key", 2137 },
            { "Archive Tower Cell Key", 2138 },
            { "Archive Tower Giant Door Key", 2139 },
            { "Archive Tower Giant Cell Key", 2140 },
            { "Blighttown Key", 2141 },
            { "Key to New Londo Ruins", 2061 },
            { "Annex Key", 2062 },
            { "Dungeon Cell Key", 2079 },
            { "Big Pilgrim's Key", 2080 },
            { "Undead Asylum F2 East Key", 2081 },
            { "Key to the Seal", 2102 },
            { "Key to Depths", 2103 },
            { "Lift Chamber Key", 2104 },
            { "Undead Asylum F2 West Key", 2105 },
            { "Mystery Key", 2106 },
            { "Sewer Chamber Key", 2124 },
            { "Watchtower Basement Key", 2125 },
            { "Archive Prison Extra Key", 2126 },
            { "Residence Key", 2127 },
            { "Crest Key", 2128 },
            { "Master Key", 2142 },
            { "Lord Soul", 2056 },
            { "Bequeathed Lord Soul Shard", 2058 },
            { "None", 2060 },
            { "Lordvessel", 2085 },
            { "Broken Pendant", 2147 },
            { "Weapon Smithbox", 2063 },
            { "Armor Smithbox", 2064 },
            { "Repairbox", 2065 },
            { "Rite of Kindling", 2084 },
            { "Bottomless Box", 2088 },
        };

        SoulsMod Mod { get; }

        Good SystemItemTemplate
        {
            get => Mod.VanillaGPARAM.Goods[117];
        } // Darksign

        Good MarkerItemTemplate
        {
            get => Mod.VanillaGPARAM.Goods[2012];
        } // Key

        Good ConsumableTemplate
        {
            get => Mod.VanillaGPARAM.Goods[260];
        } // Green Blossom

        Good ReinforcementTemplate
        {
            get => Mod.VanillaGPARAM.Goods[1000];
        } // Titanite Shard

        Good KeyItemTemplate
        {
            get => Mod.VanillaGPARAM.Goods[2001];
        } // Basement Key

        Accessory RingTemplate
        {
            get => Mod.VanillaGPARAM.Rings[100];
        } // Havel's Ring

        ItemLot ItemLotTemplate
        {
            get => Mod.VanillaGPARAM.ItemLots[1000];
        } // Solaire's Soapstone gift

        public GoodsGenerator(SoulsMod mod)
        {
            // No randomization involved.
            Mod = mod;
        }

        public void Install()
        {
            ModifyObjActs();
            CreateGoods();
            CreateUniqueItemLots();
            CreateRings();
            ModifyObjects();
        }

        void ModifyObjActs()
        {
            // Set up ObjActs. These were originally hard-coded in the Param resource.

            Mod.GPARAM.ObjActs[1200].Name = "Sunlight Gate Lever"; // disabled in m10_01 MSB (region trigger used)

            Mod.GPARAM.ObjActs[1202].Name = "Parish Bell Lever";

            Mod.GPARAM.ObjActs[1305].Name = "Watchtower Door (Upper)";
            Mod.GPARAM.ObjActs[1305].SpQualifiedId = 2001; // Rusted Key
            Mod.GPARAM.ObjActs[1305].SpQualifiedType2 = 1; // has good
            Mod.GPARAM.ObjActs[1305].SpQualifiedId2 = 2100; // Skeleton Keys

            Mod.GPARAM.ObjActs[1306].Name = "Door to Depths"; // disabled in m10_01 MSB (region trigger used)

            Mod.GPARAM.ObjActs[1308].Name = "Parish Cell";
            Mod.GPARAM.ObjActs[1308].SpQualifiedId = 2003; // Polished Key (still has Master Key access)

            Mod.GPARAM.ObjActs[1310].Name = "Burg House";
            Mod.GPARAM.ObjActs[1310].ActionFailedMsgId = -1;
            Mod.GPARAM.ObjActs[1310].SpQualifiedType = 0; // none
            Mod.GPARAM.ObjActs[1310].SpQualifiedId = 0;
            Mod.GPARAM.ObjActs[1310].SpQualifiedType2 = 0; // none
            Mod.GPARAM.ObjActs[1310].SpQualifiedId2 = 0;

            Mod.GPARAM.ObjActs[1314].Name = "Lower Burg Shortcut";

            Mod.GPARAM.ObjActs[1317].Name = "Lower Burg House";
            Mod.GPARAM.ObjActs[1317].ActionFailedMsgId = -1;
            Mod.GPARAM.ObjActs[1317].SpQualifiedType = 0; // none
            Mod.GPARAM.ObjActs[1317].SpQualifiedId = 0;
            Mod.GPARAM.ObjActs[1317].SpQualifiedType2 = 0; // none
            Mod.GPARAM.ObjActs[1317].SpQualifiedId2 = 0;

            Mod.GPARAM.ObjActs[1465].Name = "Firelink New Londo Gate"; // disabled in m10_02 MSB

            Mod.GPARAM.ObjActs[1550].Name = "Painted World Sewer Lever";

            Mod.GPARAM.ObjActs[1580].Name = "Painted World Annex Door";
            Mod.GPARAM.ObjActs[1580].SpQualifiedId = 2002; // Tarnished Key
            Mod.GPARAM.ObjActs[1580].SpQualifiedType2 = 1; // has good
            Mod.GPARAM.ObjActs[1580].SpQualifiedId2 = 2100; // Skeleton Keys

            Mod.GPARAM.ObjActs[6010].Name = "New Londo to Valley Gate";
            Mod.GPARAM.ObjActs[6010].ActionFailedMsgId = -1;
            Mod.GPARAM.ObjActs[6010].SpQualifiedType = 0; // none
            Mod.GPARAM.ObjActs[6010].SpQualifiedId = 0;
            Mod.GPARAM.ObjActs[6010].SpQualifiedType2 = 0; // none
            Mod.GPARAM.ObjActs[6010].SpQualifiedId2 = 0;

            Mod.GPARAM.ObjActs[11305].Name =
                "Watchtower Basement (Lower)"; // disabled in m10_01 MSB (region trigger used)

            Mod.GPARAM.ObjActs[11312].Name = "Lower Burg Basement Door";
            Mod.GPARAM.ObjActs[11312].ActionFailedMsgId = -1;
            Mod.GPARAM.ObjActs[11312].SpQualifiedType = 0; // none
            Mod.GPARAM.ObjActs[11312].SpQualifiedId = 0;
            Mod.GPARAM.ObjActs[11312].SpQualifiedType2 = 0; // none
            Mod.GPARAM.ObjActs[11312].SpQualifiedId2 = 0;

            Mod.GPARAM.ObjActs[16010].Name = "New Londo Flood Lever Gate";
            Mod.GPARAM.ObjActs[16010].SpQualifiedId = 2003; // Polished Key
            Mod.GPARAM.ObjActs[16010].SpQualifiedType2 = 1; // has good
            Mod.GPARAM.ObjActs[16010].SpQualifiedId2 = 2100; // Skeleton Keys
        }


        void ModifyObjects()
        {
            // Give chests 200 HP, so they can be destroyed if necessary. Also disable deflection on them.
            // (I assume their ObjAct event won't work if they're destroyed, which is fine. Not sure about
            // attached treasure events.)
            Mod.GPARAM.Objects[110].ObjectHP = 200;
            Mod.GPARAM.Objects[110].DeflectsAttacks = false;
        }

        void CreateRings()
        {
            // No better place to put this. They're basically goods.
            // Only wearing Quelana's and Havel's rings actually does anything.
            CreateRing(100, "Alvina's Ring", 1, 4041, 8800);
            CreateRing(101, "Solaire's Ring", 2, 4011, 8801);
            CreateRing(102, "Siegmeyer's Ring", 3, 4020, 8802);
            CreateRing(103, "Logan's Ring", 4, 4008, 8803);
            CreateRing(104, "Quelana's Ring", 5, 4003, 8804);
            CreateRing(105, "Havel's Ring", 6, 4000, 8805);
            CreateRing(106, "Mornstein's Ring", 7, 4031, 8806);
            CreateRing(107, "Lobos Jr's Ring", 8, 4035, 8807);
        }

        Accessory CreateRing(int ringID, string ringName, int sortIndex, ushort iconID, int spEffect)
        {
            Mod.GPARAM.Rings.DeleteRow(ringID);
            Accessory newRing = Mod.GPARAM.Rings.CopyRow(RingTemplate, ringID);
            newRing.Name = ringName;
            if (!Descriptions.ContainsKey(ringName))
                throw new Exception($"No description for ring {ringName}.");
            newRing.Summary = "象征牢不可破的友谊的戒指";
            newRing.Description = string.Join("\n", WordWrapper.WordWrap(Descriptions[ringName], 39));
            newRing.SortIndex = sortIndex;
            newRing.MenuIcon = iconID;
            newRing.SpecialEffect = spEffect;
            newRing.Name = CNNames[ringName];
            return newRing;
        }

        void CreateUniqueItemLots()
        {
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 50010);
            Mod.GPARAM.ItemLots[50010].SetSimpleItem(ItemLotCategory.Good, 2001, 1, 50050010);
            Mod.GPARAM.ItemLots[50010].Name = CNNames["Rusted Key"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 50020);
            Mod.GPARAM.ItemLots[50020].SetSimpleItem(ItemLotCategory.Good, 2002, 1, 50050020);
            Mod.GPARAM.ItemLots[50020].Name = CNNames["Tarnished Key"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 50030);
            Mod.GPARAM.ItemLots[50030].SetSimpleItem(ItemLotCategory.Good, 2003, 1, 50050030);
            Mod.GPARAM.ItemLots[50030].Name = CNNames["Polished Key"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 50050);
            Mod.GPARAM.ItemLots[50050].SetSimpleItem(ItemLotCategory.Good, 2005, 1, 50050050);
            Mod.GPARAM.ItemLots[50050].Name = CNNames["Giant Key"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 50060);
            Mod.GPARAM.ItemLots[50060].SetSimpleItem(ItemLotCategory.Good, 2006, 1, 50050060);
            Mod.GPARAM.ItemLots[50060].Name = CNNames["Holy Sigil"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 50070);
            Mod.GPARAM.ItemLots[50070].SetSimpleItem(ItemLotCategory.Good, 2007, 1, 50050070);
            Mod.GPARAM.ItemLots[50070].Name = CNNames["Piercing Eye"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 50100);
            Mod.GPARAM.ItemLots[50100].SetSimpleItem(ItemLotCategory.Good, 2100, 1, 50050100);
            Mod.GPARAM.ItemLots[50100].Name = CNNames["Skeleton Keys"];

            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 51000);
            Mod.GPARAM.ItemLots[51000].SetSimpleItem(ItemLotCategory.Ring, 100, 1, 50051000);
            Mod.GPARAM.ItemLots[51000].Name = CNNames["Alvina's Ring"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 51010);
            Mod.GPARAM.ItemLots[51010].SetSimpleItem(ItemLotCategory.Ring, 101, 1, 50051010);
            Mod.GPARAM.ItemLots[51010].Name = CNNames["Solaire's Ring"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 51020);
            Mod.GPARAM.ItemLots[51020].SetSimpleItem(ItemLotCategory.Ring, 102, 1, 50051020);
            Mod.GPARAM.ItemLots[51020].Name = CNNames["Siegmeyer's Ring"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 51030);
            Mod.GPARAM.ItemLots[51030].SetSimpleItem(ItemLotCategory.Ring, 103, 1, 50051030);
            Mod.GPARAM.ItemLots[51030].Name = CNNames["Logan's Ring"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 51040);
            Mod.GPARAM.ItemLots[51040].SetSimpleItem(ItemLotCategory.Ring, 104, 1, 50051040);
            Mod.GPARAM.ItemLots[51040].Name = CNNames["Quelana's Ring"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 51050);
            Mod.GPARAM.ItemLots[51050].SetSimpleItem(ItemLotCategory.Ring, 105, 1, 50051050);
            Mod.GPARAM.ItemLots[51050].Name = CNNames["Havel's Ring"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 51060);
            Mod.GPARAM.ItemLots[51060].SetSimpleItem(ItemLotCategory.Ring, 106, 1, 50051060);
            Mod.GPARAM.ItemLots[51060].Name = CNNames["Mornstein's Ring"];
            Mod.GPARAM.ItemLots.CopyRow(ItemLotTemplate, 51070);
            Mod.GPARAM.ItemLots[51070].SetSimpleItem(ItemLotCategory.Ring, 107, 1, 50051070);
            Mod.GPARAM.ItemLots[51070].Name = CNNames["Lobos Jr's Ring"];
        }

        void CreateGoods()
        {
            // Consumables are all largely the same.
            CreateReinforcementGoods();
            CreateKeys();
        }

        void CreateKeys()
        {
            Good hand = CreateGood(600, "Hand of Cessation", 3, Icons["Dried Finger"], SystemItemTemplate);
            hand.RefID = 8898;
            hand.ConfirmationMessage = 80008;

            Good flame = CreateGood(601, "Undead Flame", 4, Icons["Rite of Kindling"], SystemItemTemplate);
            flame.RefID = 8899;
            flame.ConfirmationMessage = 80033;
            flame.AutomaticallyEquipped = true;

            Good endGame = CreateGood(602, "Heart of St. Jude", 5, Icons["Soul of Gwyn, Lord of Cinder"],
                SystemItemTemplate);
            endGame.RefID = 8897;
            endGame.ConfirmationMessage = 80034;
            endGame.ConsumedOnUse = true;

            Good markOfDeath = CreateGood(603, "Mark of Death", 9999, Icons["Eye of Death"], MarkerItemTemplate);
            markOfDeath.GoodType = 0;
            markOfDeath.UseableByHumans = false;
            markOfDeath.UseableByHollows = false;
            markOfDeath.MaxHoldQuantity = 99;

            Good mote;
            mote = CreateGood(650, "Mote of Vitality", 60, Icons["Very good! Carving"], ConsumableTemplate);
            mote.RefID = 8901;
            mote.LimitCategory = 0;
            mote = CreateGood(651, "Mote of Attunement", 61, Icons["Very good! Carving"], ConsumableTemplate);
            mote.RefID = 8911;
            mote.LimitCategory = 0;
            mote = CreateGood(652, "Mote of Endurance", 62, Icons["Very good! Carving"], ConsumableTemplate);
            mote.RefID = 8921;
            mote.LimitCategory = 0;
            mote = CreateGood(653, "Mote of Strength", 63, Icons["Very good! Carving"], ConsumableTemplate);
            mote.RefID = 8931;
            mote.LimitCategory = 0;
            mote = CreateGood(654, "Mote of Dexterity", 64, Icons["Very good! Carving"], ConsumableTemplate);
            mote.RefID = 8941;
            mote.LimitCategory = 0;
            mote = CreateGood(655, "Mote of Resistance", 65, Icons["Very good! Carving"], ConsumableTemplate);
            mote.RefID = 8951;
            mote.LimitCategory = 0;
            mote = CreateGood(656, "Mote of Intelligence", 66, Icons["Very good! Carving"], ConsumableTemplate);
            mote.RefID = 8961;
            mote.LimitCategory = 0;
            mote = CreateGood(657, "Mote of Faith", 67, Icons["Very good! Carving"], ConsumableTemplate);
            mote.RefID = 8971;
            mote.LimitCategory = 0;

            Good tome;
            tome = CreateGood(660, "Tome of Vitality", 68, Icons["Servant Roster"], ConsumableTemplate);
            tome.RefID = 8904;
            tome.LimitCategory = 0;
            tome = CreateGood(661, "Tome of Attunement", 69, Icons["Servant Roster"], ConsumableTemplate);
            tome.RefID = 8914;
            tome.LimitCategory = 0;
            tome = CreateGood(662, "Tome of Endurance", 70, Icons["Servant Roster"], ConsumableTemplate);
            tome.RefID = 8924;
            tome.LimitCategory = 0;
            tome = CreateGood(663, "Tome of Strength", 71, Icons["Servant Roster"], ConsumableTemplate);
            tome.RefID = 8934;
            tome.LimitCategory = 0;
            tome = CreateGood(664, "Tome of Dexterity", 72, Icons["Servant Roster"], ConsumableTemplate);
            tome.RefID = 8944;
            tome.LimitCategory = 0;
            tome = CreateGood(665, "Tome of Resistance", 73, Icons["Servant Roster"], ConsumableTemplate);
            tome.RefID = 8954;
            tome.LimitCategory = 0;
            tome = CreateGood(666, "Tome of Intelligence", 74, Icons["Servant Roster"], ConsumableTemplate);
            tome.RefID = 8964;
            tome.LimitCategory = 0;
            tome = CreateGood(667, "Tome of Faith", 75, Icons["Servant Roster"], ConsumableTemplate);
            tome.RefID = 8974;
            tome.LimitCategory = 0;

            // CreateGood(384, "Peculiar Doll", 4030, Icons["Peculiar Doll"], KeyItemTemplate);  // the Painting will always appear
            Good key;
            key = CreateGood(2001, "Rusted Key", 4021, Icons["Watchtower Basement Key"],
                KeyItemTemplate); // unlocks basic wooden doors
            key.IsUnique = true;
            key = CreateGood(2002, "Tarnished Key", 4022, Icons["Key to Depths"],
                KeyItemTemplate); // unlocks reinforced wooden doors (e.g. Depths)
            key.IsUnique = true;
            key = CreateGood(2003, "Polished Key", 4023, Icons["Basement Key"],
                KeyItemTemplate); // unlocks basic metal gates
            key.IsUnique = true;
            // CreateGood(2004, "Mechanism Key", 4024, Icons["Crest Key"], KeyItemTemplate);  // allows use of most levers/mechanisms
            key = CreateGood(2005, "Giant Key", 4025, Icons["Blighttown Key"],
                KeyItemTemplate); // unlocks a few giant doors
            key.IsUnique = true;
            key = CreateGood(2006, "Holy Sigil", 4026, Icons["Crest of Artorias"],
                KeyItemTemplate); // allows use of most button-triggered elevators and Darkroot door
            key.IsUnique = true;
            key = CreateGood(2007, "Piercing Eye", 4027, Icons["Blue Eye Orb"],
                KeyItemTemplate); // allows one to break illusory walls
            key.IsUnique = true;
            // CreateGood(2008, "Palace Key", 4028, Icons["Big Pilgrim's Key"], KeyItemTemplate);  // allows one to break illusory walls
            key = CreateGood(2100, "Skeleton Keys", 4029, Icons["Master Key"], KeyItemTemplate);
            key.IsUnique = true;
        }

        void CreateReinforcementGoods()
        {
            // Create reinforcement materials: nine Embers and three Titanite types for armor reinforcement.
            CreateGood(1000, "Refined Ember", 1000, Icons["Large Ember"], ReinforcementTemplate);
            CreateGood(1010, "Crystal Ember", 1001, Icons["Crystal Large Ember"], ReinforcementTemplate);
            CreateGood(1020, "Magic Ember", 1002, Icons["Large Magic Ember"], ReinforcementTemplate);
            CreateGood(1030, "Enchanted Ember", 1003, Icons["Enchanted Ember"], ReinforcementTemplate);
            CreateGood(1040, "Lightning Ember", 1004, Icons["Very Large Ember"], ReinforcementTemplate);
            CreateGood(1050, "Divine Ember", 1005, Icons["Large Divine Ember"], ReinforcementTemplate);
            CreateGood(1060, "Dire Ember", 1006, Icons["Dark Ember"], ReinforcementTemplate);
            CreateGood(1070, "Blazing Ember", 1007, Icons["Large Flame Ember"], ReinforcementTemplate);
            CreateGood(1080, "Dragonfire Ember", 1008, Icons["Chaos Flame Ember"], ReinforcementTemplate);

            CreateGood(1100, "Small Titanite Piece", 1010, Icons["Titanite Shard"], ReinforcementTemplate);
            CreateGood(1110, "Large Titanite Piece", 1011, Icons["Large Titanite Shard"], ReinforcementTemplate);
            CreateGood(1120, "Giant Titanite Piece", 1012, Icons["Titanite Chunk"], ReinforcementTemplate);
            CreateGood(1130, "Colossal Titanite Piece", 1013, Icons["Titanite Slab"], ReinforcementTemplate);
            // Delete remaining reinforcement materials params.
            Mod.GPARAM.Goods.DeleteRowRange(1140, 2000);
        }

        Good CreateGood(int goodID, string goodName, int sortIndex, ushort iconID, Good goodTemplate)
        {
            Mod.GPARAM.Goods.DeleteRow(goodID);
            Good newGood = Mod.GPARAM.Goods.CopyRow(goodTemplate, goodID);
            newGood.Name = goodName;
            if (!Summaries.ContainsKey(goodName))
                throw new Exception($"No summary for good {goodName}.");
            if (!Descriptions.ContainsKey(goodName))
                throw new Exception($"No description for good {goodName}.");
            newGood.Summary = Summaries[goodName];
            newGood.Description = string.Join("\n", WordWrapper.WordWrap(Descriptions[goodName], 39));
            newGood.SortIndex = sortIndex;
            newGood.GoodIcon = iconID;
            if (CNNames.ContainsKey(goodName))
            {
                newGood.Name = CNNames[goodName];
            }
            else
            {
#if DEBUG
                Console.WriteLine($"找不到物品{goodName}的中文名");
#endif
            }

            return newGood;
        }
    }
}