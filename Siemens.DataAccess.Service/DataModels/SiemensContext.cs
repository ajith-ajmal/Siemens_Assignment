using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.DataAccess.Service.DataModels
{
    public class SiemensContext:DbContext
    {
        public SiemensContext(DbContextOptions<SiemensContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Metal> Metal { get; set; }

    }
}
