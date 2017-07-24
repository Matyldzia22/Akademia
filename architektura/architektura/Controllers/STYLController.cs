using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using architektura.Models;

namespace architektura.Controllers
{
    public class STYLController : Controller
    {
        private OperationDataContext dbContext = new OperationDataContext();
        // GET: STYL
        public ActionResult Index()
        {
            var stylList = from m in dbContext.STYLs
                           select m;
            return View(stylList);
        }

        // GET: STYL/Details/id
        public ActionResult Details(int id)
        {
            var query = from m in dbContext.STYLs
                        where m.idSTYL == id
                        select m;

            var stylModel = query.FirstOrDefault();

            var styl = new STYL()
            {
                idSTYL = stylModel.idSTYL,
                name = stylModel.name,
                age = stylModel.age

            };
            return View(styl);
        }

        // GET: STYL/Create
        public ActionResult Create()
        {
            STYL styl = new STYL();
            return View();
        }

        // POST: STYL/Create
        [HttpPost]
        public ActionResult Create(STYL stylModel)
        {
            if (ModelState.IsValid)
            {
                STYL styl = new STYL()
                {
                    name = stylModel.name,
                    age = stylModel.age,
                    picture = stylModel.picture

                };

                dbContext.STYLs.InsertOnSubmit(styl);
                dbContext.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(stylModel);
        }

        // GET: STYL/Edit/id
        public ActionResult Edit(int id)
        {
            var query = from m in dbContext.STYLs
                        where m.idSTYL == id
                        select m;

            var stylData = query.FirstOrDefault();

            var stylModel = new STYL()
            {
                idSTYL = stylData.idSTYL,
                name = stylData.name,
                age = stylData.age,
                picture = stylData.picture

            };
            return View(stylModel);
        }

        // POST: STYL/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, STYL stylModel)
        {
            try
            {
                STYL styl = dbContext.STYLs.Where(val => val.idSTYL == stylModel.idSTYL).Single<STYL>();
                styl.idSTYL = stylModel.idSTYL;
                styl.name = stylModel.name;
                styl.age = stylModel.age;
                styl.picture = stylModel.picture;


                dbContext.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: STYL/Delete/id
        public ActionResult Delete(int id)
        {
            var query = from m in dbContext.STYLs
                        where m.idSTYL == id
                        select m;
            var stylData = query.FirstOrDefault();

            var stylModel = new STYL()
            {
                idSTYL = stylData.idSTYL,
                name = stylData.name,
                age = stylData.age

            };
            return View(stylModel);
        }

        // POST: STYL/Delete/id
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                dbContext.DeleteSTYL(id);
                dbContext.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
