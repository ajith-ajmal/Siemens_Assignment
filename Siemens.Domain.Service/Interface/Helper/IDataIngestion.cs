using Siemens.Domain.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.Interface.Helper
{
   public interface ITestDataIngestionService
    {
        /// <summary>
        /// converts the DTos to entities and calls the repository service
        /// </summary>
        /// <param name="customerDtos">DTo of customer</param>
        /// <returns></returns>
        Task InserCustomerDataAsync(List<CustomerDto> customerDtos);

        /// <summary>
        /// Converts the Dtos to entities and calls the repository service
        /// </summary>
        /// <param name="metalDtos">Dto of metal</param>
        /// <returns></returns>
        Task InsertMetalDataAsync(List<MetalDto> metalDtos);

    }
}
