using FinTax.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.DataAccess.InMemory
{
    public class COALevelRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<COALevel> coaLevels = new List<COALevel>();

        public COALevelRepository()
        {
            coaLevels = cache["coaLevels"] as List<COALevel>;

            if (coaLevels == null)
            {
                coaLevels = new List<COALevel>();
            }
        }

        public void Commit()
        {
            cache["coaLevels"] = coaLevels;
        }

        public void Insert(COALevel p)
        {
            coaLevels.Add(p);
        }

        public void Update(COALevel coaLevel)
        {
            COALevel coaLevelToUpdate = coaLevels.Find(p => p.Id == coaLevel.Id);

            if (coaLevelToUpdate != null)
            {
                coaLevelToUpdate = coaLevel;
            }
            else
            {
                throw new Exception("COA Level not found");
            }
        }

        public COALevel Find(string id)
        {
            COALevel coaLevel = coaLevels.Find(p => p.Id == id);
            if (coaLevel != null)
            {
                return coaLevel;
            }
            else
            {
                throw new Exception("COA Level not found");
            }
        }

        public IQueryable<COALevel> Collection()
        {
            return coaLevels.AsQueryable();
        }

        public void Delete(string id)
        {
            COALevel coaLevelToDelete = coaLevels.Find(p => p.Id == id);
            if (coaLevelToDelete != null)
            {
                coaLevels.Remove(coaLevelToDelete);
            }
            else
            {
                throw new Exception("COA Level not found");
            }
        }
    }
}
