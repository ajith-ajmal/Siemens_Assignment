using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siemens.Domain.Service.Constants;
using Siemens.Domain.Service.DTO;
using Siemens.Domain.Service.Enum;
using Siemens.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.API.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        public CalculateController( ICalculatorService calculatorService)
        {
           _calculatorService = calculatorService;
        }

        /// <summary>
        /// Gets the cost of Gold based on the selected quantity
        /// </summary>
        /// <param name="customerId"> unique customer Id (1 or 2)</param>
        /// <param name="grams">total grams (any int or double)</param>
        /// <param name="viewMode">to be viewed on (options: Paper or Screen or File)</param>
        /// <returns>cost Dto that contains the cost info and the customer privilege</returns>

        [HttpGet]
        [Route("{customerId}/{grams}/{viewMode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        
        public async Task<ActionResult<CostDto>> GetCost(int customerId, double grams, string viewMode)
        {

            var response =await _calculatorService.Compute(customerId, grams, viewMode);
            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(ResponseMessage.NotFound);
            }
        }

    }
}
