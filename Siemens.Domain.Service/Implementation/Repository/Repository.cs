using Microsoft.EntityFrameworkCore;
using Siemens.DataAccess.Service.DataModels;
using Siemens.Domain.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.Implementation.Repository
{
    public class Repository : IRepositoryService
    {
        private readonly SiemensContext _siemensContext;
        public Repository(SiemensContext siemensContext)
        {
            _siemensContext = siemensContext;
        }

        /// <summary>
        /// Get customer by Id
        /// </summary>
        /// <param name="customerId">customer Id</param>
        /// <returns>Customer entity</returns>
        public async Task<Customer> GetCustmerByIdAsync(int customerId)
        {
            return await _siemensContext.Customer.Where(x => x.CustomerId == customerId).Select(x => x).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get the metal (for now it is just gold)
        /// </summary>
        /// <returns>returs metal entity</returns>
        public async Task<Metal> GetMetalAsync()
        {
            return await _siemensContext.Metal.Select(x => x).FirstOrDefaultAsync();
        }

        /// <summary>
        /// inserts list of customer entities
        /// </summary>
        /// <param name="customers"> list of customer entities</param>
        /// <returns></returns>
        public async Task InsertCustomerDataAsync(List<Customer> customers)
        {
          await  _siemensContext.Customer.AddRangeAsync(customers);
          await _siemensContext.SaveChangesAsync();
        }

        /// <summary>
        /// inserts list of metal entities
        /// </summary>
        /// <param name="metals">list of metals</param>
        /// <returns></returns>
        public async Task InsertMetalDataAsync(List<Metal> metals)
        {
            await _siemensContext.Metal.AddRangeAsync(metals);
            await _siemensContext.SaveChangesAsync();
        }
    }
}
