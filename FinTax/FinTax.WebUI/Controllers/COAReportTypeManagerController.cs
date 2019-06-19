using FinTax.Core.Contracts;
using FinTax.Core.Models;
using FinTax.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinTax.WebUI.Controllers
{
    public class COAReportTypeManagerController : Controller
    {
        IRepository<COAReportType> context;


        public COAReportTypeManagerController(IRepository<COAReportType> context)
        {
            this.context = context;
        }

        // GET: CoaManager
        public ActionResult Index()
        {
            List<COAReportType> coaReports = context.Collection().ToList();
            return View(coaReports);
        }

        public ActionResult Create()
        {
            COAReportType coaReport = new COAReportType();
            return View(coaReport);
        }

        [HttpPost]
        public ActionResult Create(COAReportType coaReport)
        {
            if (!ModelState.IsValid)
            {
                return View(coaReport);
            }
            else
            {
                context.Insert(coaReport);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            COAReportType coaReport = context.Find(id);
            if (coaReport == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(coaReport);
            }
        }

        [HttpPost]
        public ActionResult Edit(COALevel coaAttachment, string id)
        {
            COAReportType coaReportToEdit = context.Find(id);
            if (coaReportToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(coaReportToEdit);
                }

                coaReportToEdit.ReportType = coaReportToEdit.ReportType;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            COAReportType coaReportToDelete = context.Find(id);
            if (coaReportToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(coaReportToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            COAReportType coaReportToDelete = context.Find(id);
            coaReportToDelete = context.Find(id);
            if (coaReportToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                return View(coaReportToDelete);
            }
        }
    }
}