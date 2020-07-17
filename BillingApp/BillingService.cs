using BillingApp.Entities;
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

        private double _total;
        public BillingService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }


        public async Task<double> CalculatePrice(IEnumerable<string> purchasedItems)
        {
            var availableItems = await _menuItemRepository.GetByName(purchasedItems);

            foreach (var item in purchasedItems)
            {
                _total += availableItems.SingleOrDefault(x => x.Name.ToLower() == item.ToLower())?.Price ?? 0;
            }


            if (availableItems.Any(x => x.Type == ItemType.Food && x.Temperature == Temperature.Hot))
            {
                await Apply20pctServiceCharge();
            }
            else if (availableItems.Any(x => x.Type == ItemType.Food))
            {
                await Apply10pctServiceCharge();
            }

            return _total;
        }


        async Task Apply20pctServiceCharge()
        {
            var serviceCharge = _total * ServiceCharge.TwentyPercent;
            _total += serviceCharge > ServiceCharge.MaxAmount ? ServiceCharge.MaxAmount : serviceCharge;
        }

        async Task Apply10pctServiceCharge()
        {
            _total += _total * ServiceCharge.TenPercent;
            _total = Math.Round(_total, 2);
        }
    }
}


