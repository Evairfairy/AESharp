using System.Collections.Generic;

namespace AESharp.Logon.Repositories
{
    public class RealmRepository
    {
        private readonly List<Realm> _realms = new List<Realm>
        {
            new Realm
            {
                Name = "Evairfairy's Test Realm",
                Address = "127.0.0.1:8095",
                Type = RealmType.Normal,
                Flags = RealmFlags.Recommended,
                IsLocked = false,
                Region = RealmRegion.QA
            },
            new Realm
            {
                Name = "Zyres' Test Realm",
                Address = "127.0.0.1:8096",
                Type = RealmType.PVP,
                Flags = RealmFlags.NewPlayers,
                IsLocked = false,
                Region = RealmRegion.QA
            },
            new Realm
            {
                Name = "Tony's Test Realm",
                Address = "127.0.0.1:8097",
                Type = RealmType.RP,
                Flags = RealmFlags.Full,
                IsLocked = false,
                Region = RealmRegion.QA
            },
            new Realm
            {
                Name = "Rakinishu's Test Realm",
                Address = "127.0.0.1:8098",
                Type = RealmType.RPPVP,
                Flags = RealmFlags.RedName,
                IsLocked = true,
                Region = RealmRegion.QA
            }
        };

        public List<Realm> GetRealms()
        {
            List<Realm> realms = new List<Realm>();

            foreach (Realm realm in _realms)
            {
                realms.Add(realm);
            }

            return realms;
        }
    }
}