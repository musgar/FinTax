using FinTax.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.Core.ViewModels
{
    public class COAManagerViewModel
    {
        public Coa COA { get; set; }
        public IEnumerable<COAAttachment> COAAttachments { get; set; }
        public IEnumerable<COALevel> COALevels { get; set; }
        public IEnumerable<COAReportType> COAReportTypes { get; set; }
    }
}
