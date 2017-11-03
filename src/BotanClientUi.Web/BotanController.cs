using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotanClientUi.Web
{
    [Produces("application/json")]
    [Route("api/Botan")]
    public class BotanController : Controller
    {
        private readonly BotanClient.BotanClient botanClient;

        public BotanController(BotanClient.BotanClient botanClient)
        {
            this.botanClient = botanClient;
        }

        [Route("Event")]
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromForm]dynamic eventModel)
        {
            var botanResponse = await botanClient.SendEvent(new BotanClient.Models.BotanMessage
            {
                EventName = Request.Form["eventName"],
                Uid = Request.Form["uid"],
                RawData = Request.Form["rawData"]
            });
            return Ok(botanResponse);
        }

        [Route("Url/{uri}/{user}")]
        [HttpGet]
        public async Task<IActionResult> ShortenUrl(string uri, string user)
        {
            var resUrl = await botanClient.ShortenUrl(Uri.UnescapeDataString(uri), user.Split(',', StringSplitOptions.RemoveEmptyEntries));
            return Ok(resUrl);
        }
    }
}