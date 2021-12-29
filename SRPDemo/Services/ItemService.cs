using SRPDemo.Data;
using SRPDemo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRPDemo.Services
{
    class ItemService
    {
        public bool Create(Item item, Guid userId)
        {
            if (HasReadWriteAccess(userId))
            {
                item.Id = Guid.NewGuid();
                MemoryDb.Instance.Items.Add(item);
                return true;
            }
            return false;
        }

        public bool Update(Item updatedItem, Guid userId)
        {
            if (HasReadWriteAccess(userId))
            {
                var item = MemoryDb.Instance.Items.Find(i => i.Id == updatedItem.Id);
                if (item == null)
                    return false;

                item.Name = updatedItem.Name;
                item.OwnerId = updatedItem.OwnerId;
                item.Description = updatedItem.Description;

                return true;
            }
            return false;
        }

        public bool Delete(Guid itemId, Guid userId)
        {
            if (HasReadWriteAccess(userId))
            {
                var item = MemoryDb.Instance.Items.Find(i => i.Id == itemId);
                if (item == null)
                    return false;

                MemoryDb.Instance.Items.Remove(item);
                return true;
            }
            return false;
        }

        public Item Get(Guid itemId, Guid userId)
        {
            if (HasReadAccess(userId))
            {
                var item = MemoryDb.Instance.Items.Find(i => i.Id == itemId);
                return item;
            }

            return null;
        }

        public IEnumerable<Item> GetAll(Guid userId)
        {
            if (HasReadAccess(userId))
                return MemoryDb.Instance.Items;

            return null;
        }

        private bool HasReadAccess(Guid userId)
        {
            return MemoryDb.Instance.Roles.Find(r => r.UserId == userId
            && (r.Access == AccessType.Read || r.Access == AccessType.ReadWrite)) != null;
        }

        private bool HasReadWriteAccess(Guid userId)
        {
            return MemoryDb.Instance.Roles.Find(r => r.UserId == userId
            && r.Access == AccessType.ReadWrite) != null;
        }
    }
}
