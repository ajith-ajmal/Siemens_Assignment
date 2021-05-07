using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.DataAccess.Service.DataModels
{
  public  class Metal
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public double DiscountPercent { get; set; }
        public double CostPerGram { get; set; }

    }
}
