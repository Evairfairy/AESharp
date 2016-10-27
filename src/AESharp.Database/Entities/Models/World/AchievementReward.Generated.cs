// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class AchievementReward
    {
            [Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "gender" )]
            public sbyte Gender { get; set; }

            [Column( "title_A" )]
            public uint TitleA { get; set; }

            [Column( "title_H" )]
            public uint TitleH { get; set; }

            [Column( "item" )]
            public uint Item { get; set; }

            [Column( "sender" )]
            public uint Sender { get; set; }

            [Column( "subject" )]
            public string Subject { get; set; }

            [Column( "text" )]
            public string Text { get; set; }

    }
}