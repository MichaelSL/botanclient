using BotanClient.Models;
using Newtonsoft.Json;
using System;
using Xunit;

namespace BotanClient.UnitTests
{
    public class BotanMessageTests
    {
        [Fact]
        public void TestSerialization()
        {
            BotanMessage message = new BotanMessage
            {
                EventName = "Test1",
                RawData = new
                {
                    Test = "Test"
                },
                Uid = "Test1"
            };
            var stringifiedData = message.ToString();
            Assert.Equal(JsonConvert.SerializeObject(new { Test = "Test" }), stringifiedData);
        }

        [Fact]
        public void TestNullserialization()
        {
            BotanMessage message = new BotanMessage
            {
                EventName = "Test1",
                RawData = null,
                Uid = "Test1"
            };
            var stringifiedData = message.ToString();
            Assert.Equal(JsonConvert.SerializeObject(null), stringifiedData);
        }
    }
}
