using Siemens.Domain.Service.Enum;
using Siemens.Domain.Service.Implementation.Printer;
using Siemens.Domain.Service.Interface;
using Siemens.Domain.Service.Interface.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.Domain.Service.Implementation.Factory
{
    public class Factory : IFactory
    {
        /// <summary>
        /// Factory Method that returns the instance based on request param
        /// </summary>
        /// <param name="type">view mode</param>
        /// <returns>subtype of IPrinter</returns>
        public IPrinter ReturnInstance(string type)
        {
            if (type.Equals(PrinterType.paper.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return new PaperPrinter();
            }
            else if (type.Equals(PrinterType.screen.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return new ScreenPrinter();
            }
            else if (type.Equals(PrinterType.file.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return new FilePrinter();
            }
            else
            {
                return new UnknownPrinter();
            }

        }
    }
}
