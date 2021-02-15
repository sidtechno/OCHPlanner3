﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCHPlanner3.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductNo { get; set; }
        public string Description { get; set; }
        public string CostPrice { get; set; }
        public string RetailPrice { get; set; }
        public int GarageId { get; set; }
    }

    public class ProductManagementViewModel : BaseViewModel
    {
        public int SelectedGarageId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
