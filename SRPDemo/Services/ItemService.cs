using SRPDemo.Data;
using SRPDemo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRPDemo.Services
{
    class ItemService
    {
        public bool Create(Item item)
        {
            item.Id = Guid.NewGuid();
            MemoryDb.Instance.Items.Add(item);
            return true;
        }

        public bool Update(Item updatedItem)
        {
            var item = MemoryDb.Instance.Items.Find(i => i.Id == updatedItem.Id);
            if (item == null)
                return false;

            item.Name = updatedItem.Name;
            item.OwnerId = updatedItem.OwnerId;
            item.Description = updatedItem.Description;
            
            return true;
        }

        public bool Delete(Guid itemId)
        {
            var item = MemoryDb.Instance.Items.Find(i => i.Id == itemId);
            if (item == null)
                return false;

            MemoryDb.Instance.Items.Remove(item);
            return true;
        }

        public Item Get(Guid itemId)
        {
            var item = MemoryDb.Instance.Items.Find(i => i.Id == itemId);
            return item;
        }

        public IEnumerable<Item> GetAll()
        {
            return MemoryDb.Instance.Items;
        }
    }
}
