using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.Domain.Service.Interface.Helper
{
    public  interface IMath
    {
        /// <summary>
        /// returns the discounted value on the given
        /// </summary>
        /// <param name="totalPrice">to be discounted on</param>
        /// <param name="discountRate">discount</param>
        /// <returns>discounted value in double</returns>
        double Discount(double totalPrice, double discountRate);

        /// <summary>
        /// Gets the total quantity
        /// </summary>
        /// <param name="itemCost">cost</param>
        /// <param name="Quantity">number of items</param>
        /// <returns>total value</returns>
        double Total(double itemCost, double Quantity);
    }
}
