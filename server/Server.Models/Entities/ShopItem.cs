using System;
using Server.Models.Enums;

namespace Server.Models.Entities
{
    public class ShopItem
    {
        public ShopItem()
        {
            ID = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid ID { get; private set; }
        public Guid ShopListId { get; set; }

        public string Name { get; set; }
        public string Definition { get; set; }
        public ShopItemStatus Status { get; set; } = ShopItemStatus.OnList; // default on list
        
        public DateTime CreatedAt { get; private set; }
        public DateTime LastActionAt { get; set; }
    }
}