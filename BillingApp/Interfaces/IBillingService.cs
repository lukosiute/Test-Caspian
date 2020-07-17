using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillingApp.Interfaces
{
    public interface IBillingService
    {
        public Task<double> CalculatePrice(IEnumerable<string> purchasedItems);
    }
}