// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class ArenaTeams
    {
            [Key, Column( "id" )]
            public int Id { get; set; }

            [Column( "type" )]
            public int Type { get; set; }

            [Column( "leader" )]
            public int Leader { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

            [Column( "emblemstyle" )]
            public int Emblemstyle { get; set; }

            [Column( "emblemcolour" )]
            public long Emblemcolour { get; set; }

            [Column( "borderstyle" )]
            public int Borderstyle { get; set; }

            [Column( "bordercolour" )]
            public long Bordercolour { get; set; }

            [Column( "backgroundcolour" )]
            public long Backgroundcolour { get; set; }

            [Column( "rating" )]
            public int Rating { get; set; }

            [Column( "data" ), Required]
            public string Data { get; set; }

            [Column( "ranking" )]
            public int Ranking { get; set; }

            [Column( "player_data1" ), Required]
            public string PlayerData1 { get; set; }

            [Column( "player_data2" ), Required]
            public string PlayerData2 { get; set; }

            [Column( "player_data3" ), Required]
            public string PlayerData3 { get; set; }

            [Column( "player_data4" ), Required]
            public string PlayerData4 { get; set; }

            [Column( "player_data5" ), Required]
            public string PlayerData5 { get; set; }

            [Column( "player_data6" ), Required]
            public string PlayerData6 { get; set; }

            [Column( "player_data7" ), Required]
            public string PlayerData7 { get; set; }

            [Column( "player_data8" ), Required]
            public string PlayerData8 { get; set; }

            [Column( "player_data9" ), Required]
            public string PlayerData9 { get; set; }

            [Column( "player_data10" ), Required]
            public string PlayerData10 { get; set; }

    }
}