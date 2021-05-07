using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.DTO
{
   public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public bool IsDiscountable { get; set; }

    }
}
