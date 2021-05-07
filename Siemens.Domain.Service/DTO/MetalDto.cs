using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Domain.Service.DTO
{
  public  class MetalDto
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public double DiscountPercent { get; set; }
        public double CostPerGram { get; set; }

    }
}
