using BillingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApp.Entities
{
    public class MenuItem : IMenuItem
    {
        public string Name { get; set; }
        public Temperature Type { get; set; }
        public double Price { get; set; }
    }
}
