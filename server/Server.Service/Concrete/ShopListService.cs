using System;
using System.Threading.Tasks;
using Server.Models.DTOs.Request;
using Server.Models.DTOs.Response;
using Server.Models.Entities;
using Server.Service.Abstract;

namespace Server.Service.Concrete
{
    public class ShopListService : IShopListService
    {
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