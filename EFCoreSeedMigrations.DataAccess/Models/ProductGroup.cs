using System;
using System.Collections.Generic;

namespace EFCoreSeedMigrations.Models
{
    public class ProductGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
