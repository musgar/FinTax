using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.Core.Models
{
    public class Coa
    {
        public string Id { get; set; }

        [DisplayName("Kode COA")]
        public string Code { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string DownFrom { get; set; }
        public string ReportType { get; set; }
        public string Attachment { get; set; }

        public Coa()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
