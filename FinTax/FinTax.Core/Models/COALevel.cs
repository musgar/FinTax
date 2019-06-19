using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.Core.Models
{
    public class COALevel
    {
        public string Id { get; set; }
        public string Level { get; set; }

        public COALevel()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
