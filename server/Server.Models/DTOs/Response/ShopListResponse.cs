using System.Collections.Generic;

namespace Server.Models.DTOs.Response
{
    public class ShopListResponse
    {
        public string Name { get; set; }
        public string ShortURL { get; set; }

        public ICollection<ShopItemResponse> Items { get; set; }
    }
}