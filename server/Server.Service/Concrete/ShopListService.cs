using System;
using System.Threading.Tasks;
using Server.Data;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Service.Abstract;

namespace Server.Service.Concrete
{
    public class ShopListService : IShopListService
    {
        private readonly XContext context;
        public ShopListService(XContext _context)
        {
            context = _context;
        }

        public Task<ShopListResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ShopListResponse> GetWithAllItemsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ShopListResponse> InsertAsync(ShopListRequest value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ShopListRequest value)
        {
            throw new NotImplementedException();
        }
    }
}