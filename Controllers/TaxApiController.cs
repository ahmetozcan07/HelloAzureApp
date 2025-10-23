using Microsoft.AspNetCore.Mvc;
using MyCvMvcApp.Models;

namespace MyCvMvcApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxApiController : ControllerBase
    {
        [HttpPost("calculate")]
        public ActionResult<TaxRequestModel> Calculate(TaxRequestModel reqModel)
        {
            var resModel = new TaxResponseModel();

            if (reqModel == null || reqModel.Income <= 0)
                return BadRequest("Income must be greater than zero.");

            decimal income = reqModel.Income;
            decimal tax = 0;

            if (income <= 110000)
                tax = income * 0.15m;
            else if (income <= 230000)
                tax = (110000 * 0.15m) + ((income - 110000) * 0.20m);
            else if (income <= 580000)
                tax = (110000 * 0.15m) + (120000 * 0.20m) + ((income - 230000) * 0.27m);
            else
                tax = (110000 * 0.15m) + (120000 * 0.20m) + (350000 * 0.27m) + ((income - 580000) * 0.35m);

            resModel.Tax = tax;
            resModel.Income = income;

            return Ok(resModel);
        }
    }
}