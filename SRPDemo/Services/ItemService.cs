using SRPDemo.Data;
using SRPDemo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRPDemo.Services
{
    class ItemService
    {
        private readonly IRoleService _roleService;

        public ItemService(IRoleService roleService)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }
        public bool Create(Item item, Guid userId)
        {
            if (_roleService.HasReadWriteAccess(userId))
            {
                item.Id = Guid.NewGuid();
                MemoryDb.Instance.Items.Add(item);
                return true;
            }
            return false;
        }

        public bool Update(Item updatedItem, Guid userId)
        {
            if (_roleService.HasReadWriteAccess(userId))
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
            if (_roleService.HasReadWriteAccess(userId))
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
            if (_roleService.HasReadAccess(userId))
            {
                var item = MemoryDb.Instance.Items.Find(i => i.Id == itemId);
                return item;
            }

            return null;
        }

        public IEnumerable<Item> GetAll(Guid userId)
        {
            if (_roleService.HasReadAccess(userId))
                return MemoryDb.Instance.Items;

            return null;
        }

      
    }
}
