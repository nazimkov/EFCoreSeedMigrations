using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSeedMigrations.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid GroupId { get; set; }
        public ProductGroup Group { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
