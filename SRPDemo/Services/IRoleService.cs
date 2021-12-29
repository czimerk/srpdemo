using System;

namespace SRPDemo.Services
{
    interface IRoleService
    {
        bool HasReadAccess(Guid userId);
        bool HasReadWriteAccess(Guid userId);
    }
}