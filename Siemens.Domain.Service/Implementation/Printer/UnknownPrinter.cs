using Siemens.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.Domain.Service.Implementation.Printer
{
    public class UnknownPrinter : IPrinter
    {
        /// <summary>
        /// Throws Keynotfound exception
        /// </summary>
        /// <returns>exception</returns>
        public string ReturnPrintMode()
        {
            throw new KeyNotFoundException("Please select a valid printer");
        }
    }
}
