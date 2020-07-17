using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;
        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [Route("price")]
        public async Task<IActionResult> GetPrice([FromBody] List<string> purchasedItems)
        {
            try
            {
                var total = await _billingService.CalculatePrice(purchasedItems);

                return new JsonResult(total.ToString());
            }
            catch (Exception e)
            {
                return new JsonResult("Oooops, we couldn't get the total price");
            }

        }
    }
}
