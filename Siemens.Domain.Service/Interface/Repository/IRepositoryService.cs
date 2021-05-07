using Siemens.DataAccess.Service.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.Interface.Repository
{
    public interface IRepositoryService
    {
        /// <summary>
        /// Get customer by Id
        /// </summary>
        /// <param name="customerId">customer Id</param>
        /// <returns>Customer entity</returns>
        Task<Customer> GetCustmerByIdAsync(int customerId);

        /// <summary>
        /// inserts list of customer entities
        /// </summary>
        /// <param name="customers"> list of customer entities</param>
        /// <returns></returns>
        Task InsertCustomerDataAsync(List<Customer> customers);

        /// <summary>
        /// inserts list of metal entities
        /// </summary>
        /// <param name="metals">list of metals</param>
        /// <returns></returns>
        Task InsertMetalDataAsync(List<Metal> metals);

        /// <summary>
        /// Get the metal (for now it is just gold)
        /// </summary>
        /// <returns>returs metal entity</returns>
        Task<Metal> GetMetalAsync();
    }
}
