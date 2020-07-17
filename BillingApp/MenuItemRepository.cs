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
        private IList<IMenuItem> _menuItems;
        public MenuItemRepository()
        {
            if (_menuItems == null)
            {
                _menuItems = new List<IMenuItem>
                {
                    new MenuItem {Name = "Cola", Type = Temperature.Cold, Price = 0.50 },
                    new MenuItem {Name = "Coffee", Type = Temperature.Hot, Price = 1 },
                    new MenuItem {Name = "Cheese Sandwich", Type = Temperature.Cold, Price = 2 },
                    new MenuItem {Name = "Steak Sandwich", Type = Temperature.Hot, Price = 4.5 }
                };
            }
        }

        public async Task<IEnumerable<IMenuItem>> GetAll()
        {
            return _menuItems;
        }
    }
}
