using Siemens.Domain.Service.DTO;
using Siemens.Domain.Service.Enum;
using Siemens.Domain.Service.Interface;
using Siemens.Domain.Service.Interface.Factory;
using Siemens.Domain.Service.Interface.Helper;
using Siemens.Domain.Service.Interface.Repository;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.Implementation.Calculator
{
    public class GoldCaculator : ICalculatorService
    {
        private readonly IRepositoryService _repositoryService;
        private  IPrinter _printer;
        private readonly IMath _math;
        private readonly IFactory _factory;
        public GoldCaculator(IRepositoryService repositoryService, IMath math, IFactory factory)
        {
            _repositoryService = repositoryService;
            _math = math;
            _factory = factory;
        }

        /// <summary>
        /// Calcuates cost of gold ad returns the Dto
        /// </summary>
        /// <param name="customerId">unique customer Id</param>
        /// <param name="grams">grams in double /int</param>
        /// <param name="viewMode"> to be viewed on Paper,Screen,File</param>
        /// <returns>toatl tax</returns>
        public async Task<CostDto> Compute(int customerId, double grams, string viewMode)
        {
            var customerEntity = await _repositoryService.GetCustmerByIdAsync(customerId);
            if (customerEntity != null)
            {
                var metalEntity = await _repositoryService.GetMetalAsync();
                _printer = _factory.ReturnInstance(viewMode);
                double totalPrice = _math.Total(metalEntity.CostPerGram, grams);
                if (customerEntity.IsDiscountable)
                {
                    totalPrice = _math.Discount(totalPrice, metalEntity.DiscountPercent);
                }
                string printMode = _printer.ReturnPrintMode();
                return MapResponseDto(customerEntity.CustomerId, customerEntity.Type, customerEntity.IsDiscountable, totalPrice, printMode);

            }
            else
            {
                return null;
            }
        }

        #region <<Private Helper Methods>>

        private CostDto MapResponseDto(int customerId, string clientType, bool isdiscountedPrice, double FinalPrice, string printMode)
        {
            return new CostDto
            {
                CustomerId = customerId,
                CustomerType = clientType,
                IsdiscountedPrice = isdiscountedPrice,
                FinalPrice = FinalPrice,
                PrintableOn = printMode
            };
        }
        #endregion
    }
}
