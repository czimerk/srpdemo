using System;
using System.Collections.Generic;
using System.Text;

namespace SRPDemo.Services
{
    class RoleService : IRoleService
    {
        public bool HasReadAccess(Guid userId)
        {
            return MemoryDb.Instance.Roles.Find(r => r.UserId == userId
            && (r.Access == AccessType.Read || r.Access == AccessType.ReadWrite)) != null;
        }

        public bool _roleService.HasReadWriteAccess(Guid userId)
        {
            return MemoryDb.Instance.Roles.Find(r => r.UserId == userId
            && r.Access == AccessType.ReadWrite) != null;
        }
    }
}
