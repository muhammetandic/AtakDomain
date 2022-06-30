using AtakDomain.Common.Entities;
using AtakDomain.Common.Intarfaces;
using AtakDomain.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtakDomain.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        // GET: api/History
        [HttpGet]
        public IActionResult Get(string userId)
        {
            return Ok(_historyService.LastTenHistory(userId));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string userId, string productId)
        {
            await _historyService.RemoveHistoryAsync(userId, productId);
            return Ok();
        }
    }
}