﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCHPlanner3.Data.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductNo { get; set; }
        public string Description { get; set; }
        public string CostPrice { get; set; }
        public string RetailPrice { get; set; }
        public int GarageId { get; set; }
    }
}
