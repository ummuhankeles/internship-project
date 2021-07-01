using System;
using System.Collections.Generic;

namespace Server.Models.Entities
{
    public class ShopList
    {
        public ShopList()
        {
            ID = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid ID { get; private set; }

        public string Name { get; set; }
        public string ShortURL { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastActionAt { get; set; }

        public ICollection<ShopItem> Items { get; set; }
    }
}