using BillingApp.Entities;
using BillingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApp
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private IEnumerable<IMenuItem> _menuItems;
        public MenuItemRepository()
        {
            _menuItems = new List<IMenuItem>
                {
                    new MenuItem {Name = "Cola", Temperature = Temperature.Cold, Type = ItemType.Drink, Price = 0.5 },
                    new MenuItem {Name = "Coffee", Temperature = Temperature.Hot, Type = ItemType.Drink, Price = 1 },
                    new MenuItem {Name = "Cheese Sandwich", Temperature = Temperature.Cold, Type = ItemType.Food, Price = 2 },
                    new MenuItem {Name = "Steak Sandwich", Temperature = Temperature.Hot, Type = ItemType.Food, Price = 4.5 }
                };
        }

        public async Task<IEnumerable<IMenuItem>> GetByName(IEnumerable<string> names)
        {
            return _menuItems.Where(x => names.Contains(x.Name)).ToList();
        }
    }
}
