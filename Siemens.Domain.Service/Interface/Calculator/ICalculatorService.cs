using Siemens.Domain.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.Interface
{
    public interface ICalculatorService
    {
        /// <summary>
        /// Calcuates cost of gold ad returns the Dto
        /// </summary>
        /// <param name="customerId">unique customer Id</param>
        /// <param name="grams">grams in double /int</param>
        /// <param name="viewMode"> to be viewed on Paper,Screen,File</param>
        /// <returns>toatl tax</returns>
        Task<CostDto> Compute(int customerId, double grams, string viewMode);
    }
}
