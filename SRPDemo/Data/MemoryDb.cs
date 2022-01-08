using SRPDemo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRPDemo.Data
{
    public class MemoryDb
    {
        internal List<Item> Items { get; private set; }
        internal List<Role> Roles { get; private set; }
        internal List<User> Users { get; private set; }

        private MemoryDb()
        {
            Items = new List<Item>();
            Roles = new List<Role>();
            Users = new List<User>();
            Seed();
        }

        private static readonly Lazy<MemoryDb> lazy 
            = new Lazy<MemoryDb>(() => new MemoryDb());
        public static MemoryDb Instance
        {
            get
            {
                return lazy.Value;
            }
        }


        private void Seed()
        {

        }

    }
}
