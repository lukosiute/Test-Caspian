using BillingApp.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApp.Interfaces
{
    public interface IMenuItem
    {
        public string Name { get; set; }
        public Temperature Temperature { get; set; }
        public ItemType Type { get; set; }
        public double Price { get; set; }
    }
}