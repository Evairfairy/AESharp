using System.Collections.Generic;
using AESharp.Logon.Accounts;

namespace AESharp.Logon.Repositories
{
    public class AccountRepository
    {
        private readonly List<Account> _accounts = new List<Account>
        {
            new Account
            {
                Username = "TESTGM",
                PasswordHash = "bd86ae633416f58d5a9bfdfb9f43245d0cc41fea", // TESTGM:TESTGM
                Banned = false
            },
            new Account
            {
                Username = "BANTEST",
                PasswordHash = "ce4327c054cb52b5622a619c450f7a48f7e68bea", // BANTEST:BANTEST
                Banned = true
            }
        };

        public Account GetAccount( string username )
        {
            lock( this._accounts )
            {
                foreach( Account account in this._accounts )
                {
                    if( account.Username.ToUpperInvariant() == username.ToUpperInvariant() )
                        return account;
                }
            }

            return null;
        }
    }
}
