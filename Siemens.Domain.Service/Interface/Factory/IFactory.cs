using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.Domain.Service.Interface.Factory
{
   public interface IFactory
    {
        /// <summary>
        /// Factory Method that returns the instance based on request param
        /// </summary>
        /// <param name="type">view mode</param>
        /// <returns>subtype of IPrinter</returns>
        IPrinter ReturnInstance(string type);

    }
}
