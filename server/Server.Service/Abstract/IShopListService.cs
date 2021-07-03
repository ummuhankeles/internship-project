using System.Threading.Tasks;
using Server.Models;
using Server.Models.DTOs.Request;
using Server.Models.Entities;

namespace Server.Service.Abstract
{
    public interface IShopListService
    {
        Task<ApiResponse> InsertAsync(ShopListRequest value);
        Task<ApiResponse> UpdateAsync(string shortURL, ShopListRequest value);
        Task<ApiResponse> GetWithAllItemsByShortURL(string shortURL);
        Task<ShopList> GetByShortURL(string shortURL);
    }
}