using System;
using System.Collections.Generic;
using System.Text;

namespace SRPDemo.Domain
{
    class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid OwnerId { get; set; }
    }
}
