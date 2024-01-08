import os, sys
import json
import collections
import xml.etree.ElementTree as ET


def read_fmg_xml(path: str):
    kv = {}
    tree = ET.parse(path)
    root = tree.getroot()
    entries = root[3]
    for t in entries:
        kv[int(t.get("id"))] = t.text
    return kv


def read_fmg_as_list(path: str):
    lst = []
    kvs = read_fmg_xml(path)
    for k, v in kvs.items():
        v = str(v)
        if len(v) > 0 and v != "%null%":
            lst.append(v)
    return list(dict.fromkeys(lst))


def save_list(lst, name: str):
    with open(name, "w", encoding="utf8") as f:
        for e in lst:
            e = str(e)
            f.write(e.strip() + "\n")
        f.close()


# AllArmorDescriptions


def save_all_armor_descriptions():
    lst = read_fmg_as_list("./xmls/Armor_long_desc_.fmg.xml")

    res = []
    for i in lst:
        sps = i.split("\n\n")
        for j in sps:
            j = j.replace("\n", "")
            ss = j.split("。")
            for x in ss:
                if len(x.strip()) > 0:
                    if not ("／" in x or "【" in x or "platmsg" in x or "武器种类" in x):
                        res.append(x.replace("“", "").replace("”", "") + "。")

    save_list(list(dict.fromkeys(res)), "AllArmorDescriptions.txt")


def save_all_armor_names():
    lst = read_fmg_as_list("./xmls/Armor_name_.fmg.xml")
    lst = [i for i in lst if not "+" in i]

    def mapper(name: str):
        suffixs = [
            "头盔",
            "面罩",
            "腿甲",
            "臂甲",
            "靴子",
            "铠甲",
            "裙子",
            "腿套",
            "臂套",
            "长衣",
            "围裙",
            "护臂",
            "帽子",
            "风帽",
            "手套",
            "头冠",
            "长裤",
            "大衣",
            "礼帽",
            "紧身裤",
            "大衣",
            "外衣",
            "头巾",
            "护手",
            "长袍",
        ]
        for s in suffixs:
            if name.endswith(s):
                name = name.replace(s, "")
        return name

    lst = map(mapper, lst)
    lst = list(dict.fromkeys(lst))

    for i in lst:
        print(i)
    save_list(lst, "AllArmorNames.txt")


def save_all_spell_descriptions():
    lst = read_fmg_as_list("./xmls/Magic_long_desc_.fmg.xml")

    def mapper(name: str):
        return (
            name.replace("\r\n\r\n", "")
            .replace("\n\n", "")
            .replace("，", ",")
            .replace("。", "")
        ).strip() + "."

    lst = map(mapper, lst)
    save_list(lst, "AllSpellDescriptions.txt")


def saves_all_spell_names():
    lst = read_fmg_as_list("./xmls/Magic_name_.fmg.xml")
    save_list(lst, "AllSpellNames.txt")


def save_all_spell_summaries():
    res = []
    lst = read_fmg_as_list("./xmls/Magic_long_desc_.fmg.xml")
    for i in lst:
        i = str(i)
        s = i.split("\n")
        for j in s:
            if j.startswith("能"):
                res.append(j[1:].replace("。", "").replace(".", ""))
    res = list(dict.fromkeys(res))
    save_list(res, "AllSpellSummaries.txt")


def save_weapon_names():
    weapon_list = read_fmg_as_list("./xmls/Weapon_name_.fmg.xml")

    def weapon_fiter(name: str):
        types = ["混沌", "火焰", "魔力", "法术", "邪教", "雷电", "粗制", "神圣", "结晶"]
        for t in types:
            if name.startswith(t):
                return False
        return "+" not in name

    weapon_list = filter(weapon_fiter, weapon_list)
    weapon_list = list(dict.fromkeys(weapon_list))

    def suffix_mapper(name: str):
        suffixs = [
            "大剑",
            "巨剑",
            "小刀",
            "直剑",
            "匕首",
            "棍棒",
            "铁锤",
            "木槌",
            "钩剑",
            "刺剑",
            "矛",
            "大锤",
            "菜刀",
            "重锤",
            "曲剑",
            "大斧",
            "短刀",
            "长刀",
            "大盾",
            "拳套",
            "钩爪",
            "大弓",
            "大杖",
            "护符",
            "杖",
            "弩",
            "箭",
            "戟",
            "弓",
            "斧",
            "剑",
            "刀",
            "盾",
            "枪",
        ]
        for s in suffixs:
            if name.endswith(s):
                name = name.replace(s, "")
        return name

    without_suffix = map(suffix_mapper, weapon_list)
    without_suffix = list(dict.fromkeys(without_suffix))
    save_list(weapon_list, "AllWeaponNames.txt")
    save_list(without_suffix, "AllWeaponNamesNoSuffix.txt")


def save_all_weapon_descriptions():
    lst = read_fmg_as_list("./xmls/Weapon_long_desc_.fmg.xml")

    res = []
    for i in lst:
        sps = i.split("\n\n")
        for j in sps:
            j = j.replace("\n", "")
            ss = j.split("。")
            for x in ss:
                if len(x.strip()) > 0:
                    if not ("／" in x or "【" in x or "platmsg" in x or "武器种类" in x):
                        res.append(x.replace("“", "").replace("”", "") + "。")

    save_list(res, "AllWeaponDescriptions.txt")


# save_all_armor_names()
save_all_armor_descriptions()


# weapon_set = []
# kvs = read_fmg_xml()
# for k, v in kvs.items():
#     v = str(v)
#     n = 0
#     for t in types:
#         if v.startswith(t):
#             n += 1
#     if v.count("+") or n > 0:
#         continue
#     weapon_set.append(v)
# weapon_set = list(dict.fromkeys(weapon_set))
# with open("AllWeaponNames.txt", "w", encoding="utf8") as f:
#     for i in weapon_set:
#         f.write(i + "\n")
#     f.close()
# with open("AllWeaponNamesNoSuffix.txt", "w", encoding="utf8") as f:
#     for i in weapon_set:
#         f.write(i + "\n")
#     f.close()


# def dump_all_armor_descriptions():
#     kvs = read_fmg_xml("./xmls/Armor_long_desc_.fmg.xml")
#     with open("AllArmorDescriptions.txt", "w", encoding="utf8") as f:
#         for k, v in kvs.items():
#             if str(v) != "%null%":
#                 f.write("\n" + v + "\n")
#         f.close()


# def dump_all_armor_names():
#     armors = []
#     kvs = read_fmg_xml("./xmls/Armor_name_.fmg.xml")
#     for k, v in kvs.items():
#         v = str(v)
#         if v != "%null%" and (not "+" in v):
#             armors.append(v)
#     armors = list(dict.fromkeys(armors))

#     with open("AllArmorNames.txt", "w", encoding="utf8") as f:
#         for v in armors:
#             f.write(v + "\n")
#         f.close()


# dump_all_armor_descriptions()
# dump_weapon_names()
