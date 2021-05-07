using Siemens.Domain.Service.Interface.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.Domain.Service.Implementation.Helper
{
   public class Maths : IMath
    {

        /// <summary>
        /// returns the discounted value on the given
        /// </summary>
        /// <param name="totalPrice">to be discounted on</param>
        /// <param name="discountRate">discount</param>
        /// <returns>discounted value in double</returns>
        public double Discount( double totalPrice, double discountRate)
        {
            return totalPrice - (totalPrice * (discountRate/100));
        }

        /// <summary>
        /// Gets the total quantity
        /// </summary>
        /// <param name="itemCost">cost</param>
        /// <param name="Quantity">number of items</param>
        /// <returns>total value</returns>
        public double Total(double itemCost, double Quantity)
        {
            return itemCost * Quantity;
        }
    }
}
