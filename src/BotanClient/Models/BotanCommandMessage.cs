using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotanClient.Models
{
    public class BotanCommandMessage: BotanMessage
    {
        public string CommandName { get; set; }
        public IList<string> CommandArguments { get; set; }

        public override string ToString()
        {
            var dataObject = new
            {
                command = $"{CommandName} {String.Join(" ", CommandArguments)}",
                message = RawData
            };
            return JsonConvert.SerializeObject(dataObject);
        }
    }
}
