﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Domain.Entities.Products
{
    public class ProductBrand:Entity<int>
    {
        public string Name { get; set; } = default!;
    }
}
