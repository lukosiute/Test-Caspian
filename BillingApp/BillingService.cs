using BillingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApp
{
    public class BillingService : IBillingService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public BillingService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<double> CalculatePrice(IEnumerable<string> purchasedItems)
        {
            var availbleItems = await _menuItemRepository.GetAll();
            double total = 0;
            foreach (var item in purchasedItems)
            {
                total += availbleItems.SingleOrDefault(x => x.Name.ToLower() == item.ToLower())?.Price ?? 0;
            }

            return Math.Round(total, 2);
        }
    }
}
