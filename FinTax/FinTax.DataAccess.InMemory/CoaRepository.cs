using FinTax.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.DataAccess.InMemory
{
    public class CoaRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<Coa> coas = new List<Coa>();

        public CoaRepository()
        {
            coas = cache["coas"] as List<Coa>;

            if (coas == null)
            {
                coas = new List<Coa>();
            }
        }

        public void Commit()
        {
            cache["coas"] = coas;
        }

        public void Insert(Coa p)
        {
            coas.Add(p);
        }

        public void Update(Coa coa)
        {
            Coa coaToUpdate = coas.Find(p => p.Id == coa.Id);

            if (coaToUpdate != null)
            {
                coaToUpdate = coa;
            }
            else
            {
                throw new Exception("COA not found");
            }
        }

        public Coa Find(string id)
        {
            Coa coa = coas.Find(p => p.Id == id);
            if (coa != null)
            {
                return coa;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Coa> Collection()
        {
            return coas.AsQueryable();
        }

        public void Delete(string id)
        {
            Coa coaToDelete = coas.Find(p => p.Id == id);
            if (coaToDelete != null)
            {
                coas.Remove(coaToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
