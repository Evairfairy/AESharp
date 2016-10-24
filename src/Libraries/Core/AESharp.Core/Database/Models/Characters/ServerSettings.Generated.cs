// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class ServerSettings
    {
            [Key, Column( "setting_id" ), Required]
            public string SettingId { get; set; }

            [Column( "setting_value" )]
            public int SettingValue { get; set; }

    }
}