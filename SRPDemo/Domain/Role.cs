using System;
using System.Collections.Generic;
using System.Text;

namespace SRPDemo.Domain
{
    class Role
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public AccessType Access { get; set; }
    }
}
