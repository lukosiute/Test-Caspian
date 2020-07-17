using BillingApp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillingApp.Interfaces
{
    public interface IMenuItemRepository
    {
        public Task<IEnumerable<IMenuItem>> GetByName(IEnumerable<string> names);
    }
}