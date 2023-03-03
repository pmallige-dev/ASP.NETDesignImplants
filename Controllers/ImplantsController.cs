using DesignImplants.Models;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesignImplants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImplantsController : ControllerBase
    {
        [HttpPost]
        public ImplantsResponse Post([FromBody] ImplantsRequest implantsRequest)
        {
            var designImplantPrice = 0.0;
            var printImplantPrice = 0.0;

            foreach (var element in implantsRequest.Usage)
            {
                if (element.FeatureName == "DesignImplant")
                {
                    if (element.QuantityUsed <= 5)
                    {
                        designImplantPrice = element.QuantityUsed * 29.99;
                    }
                    else if (element.QuantityUsed > 5)
                    {
                        var tierTwoDesignImplants = element.QuantityUsed - 5;
                        designImplantPrice = 5 * 29.99 + tierTwoDesignImplants * 34.99;
                    }
                }

                if (element.FeatureName == "PrintImplant")
                {
                    if (element.QuantityUsed <= 25)
                    {
                        printImplantPrice = element.QuantityUsed * 49.99;
                    }
                    else if (element.QuantityUsed > 25)
                    {
                        var tierTwoPrintImplants = element.QuantityUsed - 25;
                        printImplantPrice = 25 * 49.99 + tierTwoPrintImplants * 59.99;
                    }
                }
            }

            var totalPrice = designImplantPrice + printImplantPrice;

            var response = new ImplantsResponse();
            response.BillableAmount = totalPrice.ToString();

            return response;

        }
    }
}
