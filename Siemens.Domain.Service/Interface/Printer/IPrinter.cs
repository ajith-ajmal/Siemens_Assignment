using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.Domain.Service.Interface
{
   public interface IPrinter
    {
        /// <summary>
        /// Returns type of printer
        /// </summary>
        /// <returns>view mode</returns>
        string ReturnPrintMode();
    }
}
