using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.Core.Models
{
    public class COAAttachment
    {
        public string Id { get; set; }
        public string Attachment { get; set; }

        public COAAttachment()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
