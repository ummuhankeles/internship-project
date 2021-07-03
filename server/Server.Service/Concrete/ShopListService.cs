using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Server.Data;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Models.Entities;
using Server.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Server.Models;
using Server.Models.Enums;

namespace Server.Service.Concrete
{
    public class ShopListService : IShopListService
    {
        private readonly IMapper mapper;
        private readonly XContext context;
        private readonly ILogger<ShopListService> logger;

        public ShopListService(XContext _context, IMapper _mapper, ILogger<ShopListService> _logger)
        {
            context = _context;
            mapper = _mapper;
            logger = _logger;
        }

        public async Task<ShopList> GetByShortURL(string shortURL)
        {
            return await context.ShopLists.FirstOrDefaultAsync(x => x.ShortURL == shortURL);
        }

        public async Task<ApiResponse> GetWithAllItemsByShortURL(string shortURL)
        {
            var data = await context.ShopLists.Include(x => x.Items)
                .Where(x => x.ShortURL == shortURL)
                .FirstOrDefaultAsync();

            if (data == null)
            {
                return new ApiResponse(ApiResponseType.NotFound);
            }

            return new ApiResponse(mapper.Map<ShopListResponse>(data), ApiResponseType.Ok);
        }

        public async Task<ApiResponse> InsertAsync(ShopListRequest value)
        {
        re:
            var newShopList = mapper.Map<ShopList>(value);
            await context.AddAsync(newShopList);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                logger.LogWarning(ex.InnerException.Message);
                goto re;
            }
            // should return object, because front-end app needs newShopList.shortURL
            return new ApiResponse(mapper.Map<ShopListResponse>(newShopList), ApiResponseType.Ok);
        }

        public async Task<ApiResponse> UpdateAsync(string shortURL, ShopListRequest value)
        {
            var shopList = await context.ShopLists.FirstOrDefaultAsync(x => x.ShortURL == shortURL);
            if (shopList == null)
            {
                return new ApiResponse(ApiResponseType.NotFound);
            }
            shopList.Name = value.Name;
            await context.SaveChangesAsync();
            return new ApiResponse(ApiResponseType.NoContent);
        }
    }
}