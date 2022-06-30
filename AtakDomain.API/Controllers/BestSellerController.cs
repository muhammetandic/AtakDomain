using AtakDomain.Common.Intarfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtakDomain.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestSellerController : ControllerBase
    {
        private readonly IBestSellerService _bestSellerService;

        public BestSellerController(IBestSellerService bestSellerService)
        {
            _bestSellerService = bestSellerService;
        }

        [HttpGet]
        public IActionResult Get(string userId)
        {
            return Ok(_bestSellerService.GetBestSellerProducts(userId));
        }
    }
}