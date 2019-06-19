using FinTax.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.DataAccess.InMemory
{
    public class COAReportTypeRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<COAReportType> coaReports = new List<COAReportType>();

        public COAReportTypeRepository()
        {
            coaReports = cache["coaReports"] as List<COAReportType>;

            if (coaReports == null)
            {
                coaReports = new List<COAReportType>();
            }
        }

        public void Commit()
        {
            cache["coaReports"] = coaReports;
        }

        public void Insert(COAReportType p)
        {
            coaReports.Add(p);
        }

        public void Update(COAReportType coaReport)
        {
            COAReportType coaReportTypeToUpdate = coaReports.Find(p => p.Id == coaReport.Id);

            if (coaReportTypeToUpdate != null)
            {
                coaReportTypeToUpdate = coaReport;
            }
            else
            {
                throw new Exception("COA Report Type not found");
            }
        }

        public COAReportType Find(string id)
        {
            COAReportType coaReportType = coaReports.Find(p => p.Id == id);
            if (coaReportType != null)
            {
                return coaReportType;
            }
            else
            {
                throw new Exception("COA Report Type not found");
            }
        }

        public IQueryable<COAReportType> Collection()
        {
            return coaReports.AsQueryable();
        }

        public void Delete(string id)
        {
            COAReportType coaReportTypeToDelete = coaReports.Find(p => p.Id == id);
            if (coaReportTypeToDelete != null)
            {
                coaReports.Remove(coaReportTypeToDelete);
            }
            else
            {
                throw new Exception("COA Report Type not found");
            }
        }
    }
}
