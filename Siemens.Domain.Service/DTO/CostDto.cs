using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.DTO
{
    public class CostDto
    {
        public int CustomerId { get; set; }

        public string CustomerType { get; set; }

        public bool IsdiscountedPrice { get; set; }

        public double FinalPrice { get; set; }

        public string PrintableOn { get; set; }

    }
}
