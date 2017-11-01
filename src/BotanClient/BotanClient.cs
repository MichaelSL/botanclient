using BotanClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BotanClient
{
    public class BotanClient
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string ApiKey;
        private const string BOTAN_URI = "https://api.botan.io/track?token={0}&uid={1}&name={2}";

        public BotanClient(string ApiKey)
        {
            this.ApiKey = ApiKey;
        }

        public async Task<BotanResponse> SendEvent(BotanMessage botanMessage)
        {
            var url = String.Format(BOTAN_URI, ApiKey, botanMessage.Uid, botanMessage.EventName);

            var response = await httpClient.PostAsync(url, new StringContent(botanMessage.ToString(), Encoding.UTF8, "application/json"));
            
            if (!response.IsSuccessStatusCode)
            {
                return new BotanResponse
                {
                    Status = response.StatusCode.ToString(),
                    Info = response.ReasonPhrase
                };
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var botanResponse = JsonConvert.DeserializeObject<BotanResponse>(responseString);
            return botanResponse;
        }
    }
}
