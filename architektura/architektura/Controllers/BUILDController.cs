using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using architektura.Models;

namespace architektura.Controllers
{
    public class BUILDController : Controller
    {
        private OperationDataContext dbContext = new OperationDataContext();
        // GET: BUILD
        public ActionResult Index()
        {
            var buildList = from m in dbContext.BUILDs
                            select m;
            return View(buildList);
        }

        // GET: BUILD/Details/id
        public ActionResult Details(int id)
        {
            var query = from m in dbContext.BUILDs
                        where m.idBUILD == id
                        select m;

            var buildModel = query.FirstOrDefault();

            var build = new BUILD()
            {
                idBUILD = buildModel.idBUILD,
                buildname = buildModel.buildname,
                city = buildModel.city,
                country = buildModel.country,

                idSTYL = buildModel.idSTYL
            };
            return View(build);
        }

        // GET: BUILD/Create
        public ActionResult Create()
        {
            ViewBag.idSTYL = new SelectList(dbContext.STYLs, "idSTYL", "name");
            return View();
        }

        // POST: BUILD/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "idBUILD, buildname, city, country, idSTYL")] BUILD build)
        {
            if (ModelState.IsValid)
            {
                dbContext.BUILDs.InsertOnSubmit(build);
                dbContext.SubmitChanges();

                return RedirectToAction("Details", "STYL", new { id = build.idSTYL });
            }

            ViewBag.idSTYL = new SelectList(dbContext.STYLs, "idSTYL", "name", build.idSTYL);

            return View(build);

        }

        // GET: BUILD/Edit/id
        public ActionResult Edit(int id)
        {
            var query = from m in dbContext.BUILDs
                        where m.idBUILD == id
                        select m;

            var buildModel = query.FirstOrDefault();

            BUILD build = new BUILD()
            {
                idBUILD = buildModel.idBUILD,
                buildname = buildModel.buildname,
                city = buildModel.city,
                country = buildModel.country,
                idSTYL = buildModel.idSTYL
            };

            ViewBag.idSTYL = new SelectList(dbContext.STYLs, "idSTYL", "name", id = build.idSTYL);

            return View(build);
        }

        // POST: BUILD/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "idBUILD, buildname, city, country, idSTYL")] BUILD buildModel)
        {
            if (ModelState.IsValid)
            {
                BUILD build = dbContext.BUILDs.Where(val => val.idBUILD == buildModel.idBUILD).Single<BUILD>();
                build.buildname = buildModel.buildname;
                build.city = buildModel.city;
                build.country = buildModel.country;

                dbContext.SubmitChanges();

                return RedirectToAction("Details", "STYL", new { id = build.idSTYL });
            }

            ViewBag.idSTYL = new SelectList(dbContext.STYLs, "idSTYL", "name", id = buildModel.idSTYL);

            return View(buildModel);
        }

        // GET: BUILD/Delete/id
        public ActionResult Delete(int id)
        {
            var query = from m in dbContext.BUILDs
                        where m.idBUILD == id
                        select m;
            var buildModel = query.FirstOrDefault();

            var build = new BUILD()
            {
                idBUILD = buildModel.idBUILD,
                buildname = buildModel.buildname,
                city = buildModel.city,
                country = buildModel.country,
                idSTYL = buildModel.idSTYL
            };


            return View(build);
        }

        // POST: BUILD/Delete/id
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                BUILD build = dbContext.BUILDs.Where(val => val.idBUILD == id).SingleOrDefault();
                dbContext.BUILDs.DeleteOnSubmit(build);
                dbContext.SubmitChanges();

                return RedirectToAction("Details", "STYL", new { id = build.idSTYL });
            }
            catch
            {
                return View();
            }
        }
    }
}
