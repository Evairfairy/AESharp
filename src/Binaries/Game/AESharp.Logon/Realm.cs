using System;

namespace AESharp.Logon
{
    [Flags]
    public enum RealmFlags : byte
    {
        None = 0x0,
        RedName = 0x1,
        Offline = 0x2,
        SpecifyBuild = 0x4,
        Unk1 = 0x8,
        Unk2 = 0x10,
        NewPlayers = 0x20,
        Recommended = 0x40,
        Full = 0x80
    }

    public enum RealmType : byte
    {
        Normal = 0,
        PVP = 1,
        RP = 6,
        RPPVP = 8
    }

    public enum RealmPopulation
    {
        Low = 0,
        Medium = 1,
        High = 2,
        New = 200,
        Full = 400,
        Recommended = 600
    }

    public enum RealmRegion : uint
    {
        Development = 1,
        UnitedStates = 2,
        Oceanic = 3,
        LatinAmerica = 4,
        Tournament = 5,
        Korea = 6,
        Tournament2 = 7,
        English = 8,
        German = 9,
        French = 10,
        Spanish = 11,
        Russian = 12,
        Tournament3 = 13,
        Taiwan = 14,
        Tournament4 = 15,
        China = 16,
        CN1 = 17,
        CN2 = 18,
        CN3 = 19,
        CN4 = 20,
        CN5 = 21,
        CN6 = 22,
        CN7 = 23,
        CN8 = 24,
        Tournament5 = 25,
        TestServer = 26,
        Tournament6 = 27,
        QA = 28,
        CN9 = 29,
        TestServer2 = 30,
        CN10 = 31,
        CTC = 32,
        CNC = 33,
        CN14 = 34,
        CN269 = 35,
        CN37 = 36,
        CN58 = 37
    }

    public class Realm
    {
        public bool IsLocked { get; set; }
        public RealmFlags Flags { get; set; }
        public RealmType Type { get; set; }
        public RealmRegion Region { get; set; }

        // Todo: Figure this out
        public float Population => 1.6f;

        public string Name { get; set; }
        public string Address { get; set; }
    }
}