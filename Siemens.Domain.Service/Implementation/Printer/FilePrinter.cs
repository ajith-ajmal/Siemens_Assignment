using Siemens.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.Domain.Service.Implementation.Printer
{
    public class FilePrinter : IPrinter
    {
        /// <summary>
        /// Returns type of printer
        /// </summary>
        /// <returns>view mode</returns>
        public string ReturnPrintMode()
        {
            return "Viewable On File";
        }
    }
}
