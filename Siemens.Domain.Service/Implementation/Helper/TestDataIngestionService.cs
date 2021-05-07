using Newtonsoft.Json;
using Siemens.DataAccess.Service.DataModels;
using Siemens.Domain.Service.DTO;
using Siemens.Domain.Service.Interface.Helper;
using Siemens.Domain.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.Implementation.Helper
{
    public class TestDataIngestionService : ITestDataIngestionService
    {
        private readonly IRepositoryService _repositoryService;
        public TestDataIngestionService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        /// <summary>
        /// converts the DTos to entities and calls the repository service
        /// </summary>
        /// <param name="customerDtos">DTo of customer</param>
        /// <returns></returns>
        public async Task InserCustomerDataAsync(List<CustomerDto> customerDtos)
        {
            var entities = MapDtoToCustomerEntity(customerDtos);
            await _repositoryService.InsertCustomerDataAsync(entities);


        }

        /// <summary>
        /// converts the DTos to entities and calls the repository service
        /// </summary>
        /// <param name="metalDtos">DTo of metal</param>
        /// <returns></returns>
        public async Task InsertMetalDataAsync(List<MetalDto> metalDtos)
        {
            var entities = MapDtoToMetalEntity(metalDtos);
            await _repositoryService.InsertMetalDataAsync(entities);
        }

        #region <<private helper methods>>
        private List<Customer> MapDtoToCustomerEntity(List<CustomerDto> customerDto)
        {
            return JsonConvert.DeserializeObject<List<Customer>>(JsonConvert.SerializeObject(customerDto));
        }

        private List<Metal> MapDtoToMetalEntity(List<MetalDto> metalDto)
        {
            return JsonConvert.DeserializeObject<List<Metal>>(JsonConvert.SerializeObject(metalDto));
        }

        #endregion
    }
}
