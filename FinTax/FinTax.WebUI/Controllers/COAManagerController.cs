using FinTax.Core.Contracts;
using FinTax.Core.Models;
using FinTax.Core.ViewModels;
using FinTax.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinTax.WebUI.Controllers
{
    public class COAManagerController : Controller
    {
        IRepository<Coa> context;
        IRepository<COAAttachment> coaAttachments;
        IRepository<COALevel> coaLevels;
        IRepository<COAReportType> coaReportTypes;

        public COAManagerController(IRepository<Coa> context, IRepository<COAAttachment> attachmentContext, 
            IRepository<COALevel> levelContext, IRepository<COAReportType> reportTypeContext)
        {
            this.context = context;
            this.coaAttachments = attachmentContext;
            this.coaLevels = levelContext;
            this.coaReportTypes = reportTypeContext;
        }

        // GET: CoaManager
        public ActionResult Index()
        {
            List<Coa> coas = context.Collection().OrderBy(x => x.Code).ToList();
            return View(coas);
        }

        public ActionResult Create()
        {
            COAManagerViewModel viewModel = new COAManagerViewModel();

            viewModel.COA = new Coa();
            viewModel.COAAttachments = coaAttachments.Collection();
            viewModel.COALevels = coaLevels.Collection();
            viewModel.COAReportTypes = coaReportTypes.Collection();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Coa coa)
        {
            if (!ModelState.IsValid)
            {
                return View(coa);
            }
            else
            {
                context.Insert(coa);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Coa coa = context.Find(id);
            if (coa == null)
            {
                return HttpNotFound();
            }
            else
            {
                COAManagerViewModel viewModel = new COAManagerViewModel();
                viewModel.COA = coa;
                viewModel.COAAttachments = coaAttachments.Collection();
                viewModel.COALevels = coaLevels.Collection();
                viewModel.COAReportTypes = coaReportTypes.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Coa coa, string id)
        {
            Coa coaToEdit = context.Find(id);
            if (coaToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(coa);
                }

                coaToEdit.Description = coa.Description;
                coaToEdit.Code = coa.Code;
                coaToEdit.Attachment = coa.Attachment;
                coaToEdit.Level = coa.Level;
                coaToEdit.ReportType = coa.ReportType;
                coaToEdit.DownFrom = coa.DownFrom;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            Coa coaToDelete = context.Find(id);
            if (coaToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(coaToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Coa coaToDelete = context.Find(id);
            if (coaToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                return View(coaToDelete);
            }
        }
    }
}