using FinTax.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Coa> COAS { get; set; }
        public DbSet<COAAttachment> COAAttachments { get; set; }
        public DbSet<COALevel> COALevels { get; set; }
        public DbSet<COAReportType> COAReportTypes { get; set; }
    }
}
