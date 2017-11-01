using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanClient.Models
{
    public class BotanResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("info")]
        public string Info { get; set; }
    }
}
