using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Data;
using Server.Models;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Models.Entities;
using Server.Models.Enums;
using Server.Service.Abstract;

namespace Server.Service.Concrete
{
    public class ShopItemService : IShopItemService
    {
        private readonly IMapper mapper;
        private readonly XContext context;
        private readonly ILogger<ShopItemService> logger;
        private readonly IShopListService shopListService;

        public ShopItemService(XContext _context, IMapper _mapper, ILogger<ShopItemService> _logger, IShopListService _shopListService)
        {
            context = _context;
            mapper = _mapper;
            logger = _logger;
            shopListService = _shopListService;
        }

        public async Task<ShopItem> GetById(Guid shopItemID)
        {
            return await context.ShopItems.FirstOrDefaultAsync(x => x.ID == shopItemID);
        }

        public async Task<ApiResponse> InsertAsync(string shortURL, ShopItemRequest value)
        {
            var shopList = await shopListService.GetByShortURL(shortURL);
            if (shopList == null)
            {
                return new ApiResponse(ApiResponseType.NotFound);
            }

            var newShopItem = mapper.Map<ShopItem>(value);

            newShopItem.ShopListId = shopList.ID;
            newShopItem.Status = ShopItemStatus.OnList;

            await context.AddAsync(newShopItem);
            await context.SaveChangesAsync();

            return new ApiResponse(ApiResponseType.Ok, mapper.Map<ShopItemResponse>(newShopItem));
        }

        public async Task<ApiResponse> UpdateAsync(Guid shopItemID, ShopItemRequest value)
        {
            var shopItem = await GetById(shopItemID);
            if (shopItem == null)
            {
                return new ApiResponse(ApiResponseType.NotFound);
            }

            shopItem.Name = value.Name;
            shopItem.Definition = value.Definition;
            shopItem.Status = value.Status;
            await context.SaveChangesAsync();

            return new ApiResponse(ApiResponseType.NoContent);
        }
    }
}