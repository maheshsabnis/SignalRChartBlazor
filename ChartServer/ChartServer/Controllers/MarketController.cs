using ChartServer.DataProvider;
using ChartServer.RHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChartServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private IHubContext<MarketHub> marketHub;
        private TimeWatcher watcher;

        public MarketController(IHubContext<MarketHub> mktHub, TimeWatcher watch)
        {
            marketHub = mktHub;
            watcher = watch;
        }
        [HttpGet]
        public IActionResult Get()
        {
            if(!watcher.IsWatcherStarted)
            {
                watcher.Watcher(()=>marketHub.Clients.All.SendAsync("SendMarketStatusData",MarketDataProvider.GetMarketData()));
            }

            return Ok(new { Message = "Request Completed" });
        }
    }
}
