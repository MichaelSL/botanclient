using BotanClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BotanClient.UnitTests
{
    public class BotanCommandMessageTests
    {
        [Fact]
        public void TestSerialization()
        {
            BotanCommandMessage message = new BotanCommandMessage
            {
                EventName = "Test1",
                RawData = new
                {
                    Test = "Test"
                },
                Uid = "Test1",
                CommandName = "/start",
                CommandArguments = new[] { "usr1" }
            };
            var stringifiedData = message.ToString();
            Assert.Equal(JsonConvert.SerializeObject(new
            {
                command = $"/start usr1",
                message = new
                {
                    Test = "Test"
                }
            }), stringifiedData);
        }
    }
}
