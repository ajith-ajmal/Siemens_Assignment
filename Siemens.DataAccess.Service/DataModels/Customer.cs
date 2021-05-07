using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.DataAccess.Service.DataModels
{
   public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public bool IsDiscountable { get; set; }
    }
}
