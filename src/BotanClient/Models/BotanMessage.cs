using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanClient.Models
{
    public class BotanMessage
    {
        public string Uid { get; set; }
        public string EventName { get; set; }

        public object RawData { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(RawData);
        }
    }
}
