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
    public class COALevelManagerController : Controller
    {
        IRepository<COALevel> context;

        public COALevelManagerController(IRepository<COALevel> context)
        {
            this.context = context;
        }

        // GET: CoaManager
        public ActionResult Index()
        {
            List<COALevel> coaLevels = context.Collection().ToList();
            return View(coaLevels);
        }

        public ActionResult Create()
        {
            COALevel coaLevel = new COALevel();
            return View(coaLevel);
        }

        [HttpPost]
        public ActionResult Create(COALevel coaLevel)
        {
            if (!ModelState.IsValid)
            {
                return View(coaLevel);
            }
            else
            {
                context.Insert(coaLevel);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            COALevel coaLevel = context.Find(id);
            if (coaLevel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(coaLevel);
            }
        }

        [HttpPost]
        public ActionResult Edit(COALevel coaLevel, string id)
        {
            COALevel coaLevelToEdit = context.Find(id);
            if (coaLevelToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(coaLevel);
                }

                coaLevelToEdit.Level = coaLevel.Level;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            COALevel coaLevelToDelete = context.Find(id);
            if (coaLevelToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(coaLevelToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            COALevel coaLevelToDelete = context.Find(id);
            coaLevelToDelete = context.Find(id);
            if (coaLevelToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                return View(coaLevelToDelete);
            }
        }
    }
}