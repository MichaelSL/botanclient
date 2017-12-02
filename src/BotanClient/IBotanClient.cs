using System.Collections.Generic;
using System.Threading.Tasks;
using BotanClient.Models;

namespace BotanClient
{
    public interface IBotanClient
    {
        Task<BotanResponse> SendEvent(BotanMessage botanMessage);
        Task<string> ShortenUrl(string url, IEnumerable<string> userIds);
    }
}