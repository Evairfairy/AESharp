﻿using AESharp.Logon.Repositories;

namespace AESharp.Logon
{
    public static class LogonServices
    {
        public static AccountRepository Accounts = new AccountRepository();
        public static RealmRepository Realms = new RealmRepository();
    }
}