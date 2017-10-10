// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class SocialFriends
    {
            [Column( "character_guid" )]
            public int CharacterGuid { get; set; }

            [Column( "friend_guid" )]
            public int FriendGuid { get; set; }

            [Column( "note" ), Required]
            public string Note { get; set; }

    }
}