using SoulsFormatsMod;
using System.Collections.Generic;

namespace RoguelikeSouls.Installation
{
    class TextGenerator
    {
        SoulsMod Mod { get; }

        public static Dictionary<int, string> EventTexts = new Dictionary<int, string>()
        {
            // Default text IDs for NPC invasion events.
            { 6990, "遭到无名暗灵的入侵" },
            { 6991, "已打败无名暗灵" },
            { 6992, "入侵无名暗灵的世界" },
            { 6993, "已向无名暗灵复仇" },

            { 79999, "Mod连接错误，请重启MOD软件" },
            { 80000, "出发地" },
            { 80001, "退出被锁上了" },
            { 80002, "无法退出" },
            // { 80003, "Sigil required" },
            { 80004, "返回传火祭祀场" },
            { 80005, "开启罗德兰之旅" },
            { 80006, "获得了王的灵魂，解锁了更多宝藏。" },
            { 80007, "获得了王的灵魂，解锁了深渊宝藏。" },
            { 80008, "放弃旅途并返回传火祭祀场？" },
            { 80009, "无根手指松开了..." },

            { 80010, "钟声没响" },
            { 80011, "月光魔法挡住了道路" },
            { 80012, "没有容器无法获得王的灵魂" },
            { 80013, "进入深渊传送门" },
            { 80014, "要塞大门已经打开" },
            { 80015, "恶魔魔法挡住了道路" },

            // Unique "receive gift" prompts now start at 80080.
            { 80021, "已经收到两份礼物了" },
            { 80022, "下次证明你自己的价值" },
            { 80023, "现在可以获取王的灵魂了，解锁了更多的宝藏。" },
            { 80024, "正在启程..." },

            { 80030, "已创建营火" },
            { 80031, "无法创建营火" },
            { 80032, "无法再次创建营火" },
            { 80033, "在这里点燃营火吗?" },
            { 80034, "提升游戏难度吗?" },

            { 80041, "索拉尔已经获救" },
            { 80042, "杰克麦雅已经获救" },
            { 80043, "罗根已经获救" },
            { 80044, "克拉娜已经获救" },
            { 80045, "哈维尔已经获救" },
            { 80046, "莫恩斯坦已经获救" },
            { 80047, "小罗博斯已经获救" },

            { 80050, "Level 1" },
            { 80051, "Level 2" },
            { 80052, "Level 3" },
            { 80053, "Level 4" },
            { 80054, "Level 5" },
            { 80055, "Level 6" },
            { 80056, "Level 7" },
            { 80057, "Level 8" },
            { 80058, "Level 9" },
            { 80059, "Level 10" },

            { 80060, "Level 1 (CURSED!)" },
            { 80061, "Level 2 (CURSED!)" },
            { 80062, "Level 3 (CURSED!)" },
            { 80063, "Level 4 (CURSED!)" },
            { 80064, "Level 5 (CURSED!)" },
            { 80065, "Level 6 (CURSED!)" },
            { 80066, "Level 7 (CURSED!)" },
            { 80067, "Level 8 (CURSED!)" },
            { 80068, "Level 9 (CURSED!)" },
            { 80069, "Level 10 (CURSED!)" },

            { 80070, "Bonus Level" },

            { 80080, "收到来自雅薇娜的礼物" },
            { 80081, "收到来自索拉尔的礼物" },
            { 80082, "收到来自杰克麦雅的礼物" },
            { 80083, "收到来自罗根的礼物" },
            { 80084, "收到来自克拉娜的礼物" },
            { 80085, "收到来自哈维尔的礼物" },
            { 80086, "收到来自摩恩斯坦国王的礼物" },
            { 80087, "收到来自小洛洛斯的礼物" },

            { 90001, "<?gdsparam@2001?> required" },
            { 90002, "<?gdsparam@2002?> required" },
            { 90003, "<?gdsparam@2003?> required" },
            { 90005, "<?gdsparam@2005?> required" },
            { 90006, "<?gdsparam@2006?> required" },
            { 90007, "<?gdsparam@2007?> required" },
            { 90100, "<?gdsparam@2100?> required" },

            {
                10010660, "受到诅咒后，你的生命值减半，\n在旅程结束之前解除诅咒需要使用净化石。"
            },

            { 15000185, "使用灵魂交换微粒" },

            { 15000500, "获取战士装备" },
            { 15000501, "获取骑士装备" },
            { 15000502, "获取流浪者装备" },
            { 15000503, "获取盗贼装备" },
            { 15000504, "获取蛮族装备" },
            { 15000505, "获取猎人装备" },
            { 15000506, "获取女巫装备" },
            { 15000507, "获取圣职装备" },

            { 15000510, "捏碎四根手指以获得祝福" },

            { 15000550, "已经选择装备" },
            { 15000551, "命运已经注定" },
        };
        
        public TextGenerator(SoulsMod mod)
        {
            Mod = mod;
        }

        public void Install()
        {
            AddEventText();
            ChangeConversations();
            Mod.Text.NPCNames[1000] = "Da Boss"; // humorous backup in case EMEVD injection fails for whatever reason
            Mod.Text.NPCNames[1001] = "Spawn of Chaos"; // too hard to inject custom names into Bed of Chaos fight
        }

        public void AddEventText()
        {
            foreach (var kv in EventTexts)
            {
                Mod.Text.EventText[kv.Key] = kv.Value;
            }
        }

        public void ChangeConversations()
        {
            Mod.Text.Conversations[23010040] = "啊，我来得太迟了。你已经触碰了被诅咒的手。";
            Mod.Text.Conversations[23010041] = "你的任务将会充满艰险，但希望并未丧失。";
            Mod.Text.Conversations[23010042] = "你朋友的命运无需被封印。";
            Mod.Text.Conversations[23010043] = "我恳求你：带上那只乌鸦，去找你的亲人。";

            Mod.Text.Conversations[23010120] = "你坚韧而忠诚，毫无疑问。";
            Mod.Text.Conversations[23010121] = "但你是否将继续前行，到达火之摇篮？";
            Mod.Text.Conversations[23010122] = "我听说那地方相当热闹。";
            Mod.Text.Conversations[23010123] = "不要因为这个差劲的笑话而批评我。";

            Mod.Text.Conversations[23010020] = "那可怜的手是有害的。";
            Mod.Text.Conversations[23010021] = "但如果你戴上我的戒指，你会发现它略微减轻了些许。";
            Mod.Text.Conversations[23010022] = "那么？前进吧，英雄。";
            Mod.Text.Conversations[23010023] = "不需要等待。";
            Mod.Text.Conversations[23010024] = "你完全有能力继续前行，不是吗？";
        }
    }
}