using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models.DTOs.Request;
using Server.Service.Abstract;

namespace Server.WebAPI.Controllers
{
    [ApiController]
    [Route("shoplists")]
    public class ShopListController : BaseController
    {
        private readonly IShopListService shopListService;

        public ShopListController(IShopListService _shopListService)
        {
            shopListService = _shopListService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateList([FromBody] ShopListRequest model)
        {
            return ApiReturn(await shopListService.InsertAsync(model));
        }

        [HttpGet("{shortURL}")]
        public async Task<IActionResult> GetWithAllItems([FromRoute] string shortURL)
        {
            return ApiReturn(await shopListService.GetWithAllItemsByShortURL(shortURL));
        }

        [HttpPut("{shortURL}")]
        public async Task<IActionResult> UpdateList([FromRoute] string shortURL, [FromBody]ShopListRequest model)
        {
            return ApiReturn(await shopListService.UpdateAsync(shortURL, model));
        }
    }
}