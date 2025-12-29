using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LLib.GameData;

[SuppressMessage("Design", "CA1028", Justification = "uint in Lumina")]
public enum EClassJob : uint
{
    Adventurer = 0,
    Gladiator = 1,
    Pugilist = 2,
    Marauder = 3,
    Lancer = 4,
    Archer = 5,
    Conjurer = 6,
    Thaumaturge = 7,
    Carpenter = 8,
    Blacksmith = 9,
    Armorer = 10,
    Goldsmith = 11,
    Leatherworker = 12,
    Weaver = 13,
    Alchemist = 14,
    Culinarian = 15,
    Miner = 16,
    Botanist = 17,
    Fisher = 18,
    Paladin = 19,
    Monk = 20,
    Warrior = 21,
    Dragoon = 22,
    Bard = 23,
    WhiteMage = 24,
    BlackMage = 25,
    Arcanist = 26,
    Summoner = 27,
    Scholar = 28,
    Rogue = 29,
    Ninja = 30,
    Machinist = 31,
    DarkKnight = 32,
    Astrologian = 33,
    Samurai = 34,
    RedMage = 35,
    BlueMage = 36,
    Gunbreaker = 37,
    Dancer = 38,
    Reaper = 39,
    Sage = 40,
    Viper = 41,
    Pictomancer = 42,
}

public static class EClassJobExtensions
{
    public static bool IsClass(this EClassJob classJob) =>
        classJob is >= EClassJob.Gladiator and <= EClassJob.Thaumaturge
            or EClassJob.Arcanist
            or EClassJob.Rogue
        || classJob.IsCrafter()
        || classJob.IsGatherer();

    public static bool HasBaseClass(this EClassJob classJob) =>
        Enum.GetValues<EClassJob>()
            .Where(x => x.IsClass())
            .Any(x => x.AsJob() == classJob);

    public static EClassJob AsJob(this EClassJob classJob) => classJob switch
    {
        EClassJob.Gladiator => EClassJob.Paladin,
        EClassJob.Marauder => EClassJob.Warrior,
        EClassJob.Pugilist => EClassJob.Monk,
        EClassJob.Lancer => EClassJob.Dragoon,
        EClassJob.Rogue => EClassJob.Ninja,
        EClassJob.Archer => EClassJob.Bard,
        EClassJob.Conjurer => EClassJob.WhiteMage,
        EClassJob.Thaumaturge => EClassJob.BlackMage,
        EClassJob.Arcanist => EClassJob.Summoner,
        _ => classJob,
    };

    public static bool IsTank(this EClassJob classJob) =>
        classJob is EClassJob.Gladiator
            or EClassJob.Paladin
            or EClassJob.Marauder
            or EClassJob.Warrior
            or EClassJob.DarkKnight
            or EClassJob.Gunbreaker;

    public static bool IsHealer(this EClassJob classJob) =>
        classJob is EClassJob.Conjurer
            or EClassJob.WhiteMage
            or EClassJob.Scholar
            or EClassJob.Astrologian
            or EClassJob.Sage;

    public static bool IsMelee(this EClassJob classJob) =>
        classJob is EClassJob.Pugilist
            or EClassJob.Monk
            or EClassJob.Lancer
            or EClassJob.Dragoon
            or EClassJob.Rogue
            or EClassJob.Ninja
            or EClassJob.Samurai
            or EClassJob.Reaper
            or EClassJob.Viper;

    public static bool IsPhysicalRanged(this EClassJob classJob) =>
        classJob is EClassJob.Archer
            or EClassJob.Bard
            or EClassJob.Machinist
            or EClassJob.Dancer;

    public static bool IsCaster(this EClassJob classJob) =>
        classJob is EClassJob.Thaumaturge
            or EClassJob.BlackMage
            or EClassJob.Arcanist
            or EClassJob.Summoner
            or EClassJob.RedMage
            or EClassJob.BlueMage
            or EClassJob.Pictomancer;

    public static bool DealsPhysicalDamage(this EClassJob classJob) =>
        classJob.IsTank() || classJob.IsMelee() || classJob.IsPhysicalRanged();

    public static bool DealsMagicDamage(this EClassJob classJob) =>
        classJob.IsHealer() || classJob.IsCaster();

    public static bool IsCrafter(this EClassJob classJob) =>
        classJob is >= EClassJob.Carpenter and <= EClassJob.Culinarian;

    public static bool IsGatherer(this EClassJob classJob) => classJob is >= EClassJob.Miner and <= EClassJob.Fisher;

    public static string ToFriendlyString(this EClassJob classJob)
    {
        return classJob switch
        {
            EClassJob.Adventurer => "冒险者",
            EClassJob.Gladiator => "剑术师",
            EClassJob.Pugilist => "格斗家",
            EClassJob.Marauder => "斧术师",
            EClassJob.Lancer => "枪术师",
            EClassJob.Archer => "弓箭手",
            EClassJob.Conjurer => "幻术师",
            EClassJob.Thaumaturge => "咒术师",
            EClassJob.Carpenter => "刻木匠",
            EClassJob.Blacksmith => "锻铁匠",
            EClassJob.Armorer => "铸甲匠",
            EClassJob.Goldsmith => "雕金匠",
            EClassJob.Leatherworker => "制革匠",
            EClassJob.Weaver => "裁衣匠",
            EClassJob.Alchemist => "炼金术士",
            EClassJob.Culinarian => "烹调师",
            EClassJob.Miner => "采矿工",
            EClassJob.Botanist => "园艺工",
            EClassJob.Fisher => "捕鱼人",
            EClassJob.Paladin => "骑士",
            EClassJob.Monk => "武僧",
            EClassJob.Warrior => "战士",
            EClassJob.Dragoon => "龙骑士",
            EClassJob.Bard => "吟游诗人",
            EClassJob.WhiteMage => "白魔法师",
            EClassJob.BlackMage => "黑魔法师",
            EClassJob.Arcanist => "秘术师",
            EClassJob.Summoner => "召唤师",
            EClassJob.Scholar => "学者",
            EClassJob.Rogue => "双剑师",
            EClassJob.Ninja => "忍者",
            EClassJob.Machinist => "机工士",
            EClassJob.DarkKnight => "暗黑骑士",
            EClassJob.Astrologian => "占星术士",
            EClassJob.Samurai => "武士",
            EClassJob.RedMage => "赤魔法师",
            EClassJob.BlueMage => "青魔法师",
            EClassJob.Gunbreaker => "绝枪战士",
            EClassJob.Dancer => "舞者",
            EClassJob.Reaper => "钐镰客",
            EClassJob.Sage => "贤者",
            EClassJob.Viper => "蝰蛇剑士",
            EClassJob.Pictomancer => "绘灵法师",
            _ => classJob.ToString(),
        };
    }
}
