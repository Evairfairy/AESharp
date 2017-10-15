// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class AccountForcedPermissions
    {
            [Key, Column( "login" ), Required]
            public string Login { get; set; }

            [Column( "permissions" ), Required]
            public string Permissions { get; set; }

    }
}