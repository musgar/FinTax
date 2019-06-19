using FinTax.Core.Models;
using FinTax.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinTax.WebUI.Controllers
{
    public class COAAttachmentManagerController : Controller
    {
        InMemoryRepository<COAAttachment> context;

        public COAAttachmentManagerController()
        {
            context = new InMemoryRepository<COAAttachment>();
        }

        // GET: CoaManager
        public ActionResult Index()
        {
            List<COAAttachment> coaAttachments = context.Collection().ToList();
            return View(coaAttachments);
        }

        public ActionResult Create()
        {
            COAAttachment coaAttachment = new COAAttachment();
            return View(coaAttachment);
        }

        [HttpPost]
        public ActionResult Create(COAAttachment coaAttachment)
        {
            if (!ModelState.IsValid)
            {
                return View(coaAttachment);
            }
            else
            {
                context.Insert(coaAttachment);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            COAAttachment coaAttachment = context.Find(id);
            if (coaAttachment == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(coaAttachment);
            }
        }

        [HttpPost]
        public ActionResult Edit(COALevel coaAttachment, string id)
        {
            COAAttachment coaAttachmentToEdit = context.Find(id);
            if (coaAttachmentToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(coaAttachmentToEdit);
                }

                coaAttachmentToEdit.Attachment = coaAttachmentToEdit.Attachment;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            COAAttachment coaAttachmentToDelete = context.Find(id);
            if (coaAttachmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(coaAttachmentToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            COAAttachment coaAttachmentToDelete = context.Find(id);
            coaAttachmentToDelete = context.Find(id);
            if (coaAttachmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                return View(coaAttachmentToDelete);
            }
        }
    }
}