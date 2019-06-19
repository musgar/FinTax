using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.Core.Models
{
    public class COAReportType : BaseEntity
    {
        public string Id { get; set; }
        public string ReportType { get; set; }
    }
}
