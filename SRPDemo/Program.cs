using SRPDemo.Data;
using SRPDemo.Domain;
using System;

namespace SRPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Fütykös",
                Description = "Fegyelmező eszk.",
                //...
            };

        }
    }
}
