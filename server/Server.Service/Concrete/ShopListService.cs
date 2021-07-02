using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Server.Data;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Models.Entities;
using Server.Service.Abstract;

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

        public Task<ShopListResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ShopListResponse> GetWithAllItemsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ShopListResponse> InsertAsync(ShopListRequest value)
        {
        re:
            var newShopList = mapper.Map<ShopList>(value);
            await context.AddAsync(newShopList);

            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return mapper.Map<ShopListResponse>(newShopList);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                logger.LogWarning(ex.InnerException.Message);
                goto re;
            }
        }

        public Task<bool> UpdateAsync(ShopListRequest value)
        {
            throw new NotImplementedException();
        }
    }
}