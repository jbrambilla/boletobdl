using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bdl.BoletoBdl.Application.ViewModels;
using Bdl.BoletoBdl.Presentation.UI.Admin.Models;
using Bdl.BoletoBdl.Application.Interfaces;

namespace Bdl.BoletoBdl.Presentation.UI.Admin.Controllers
{
    public class ContatoTiposController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IContatoTipoAppService _contatoTipoAppService;

        public ContatoTiposController(IContatoTipoAppService contatoTipoAppService)
        {
            _contatoTipoAppService = contatoTipoAppService;
        }

        // GET: ContatoTipos
        public ActionResult Index()
        {
            return View(_contatoTipoAppService.GetAll());
        }

        // GET: ContatoTipos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoTipoViewModel contatoTipoViewModel = _contatoTipoAppService.GetById(id.Value);
            if (contatoTipoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contatoTipoViewModel);
        }

        // GET: ContatoTipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContatoTipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContatoTipoViewModel contatoTipoViewModel)
        {
            if (ModelState.IsValid)
            {
                _contatoTipoAppService.Add(contatoTipoViewModel);
                return RedirectToAction("Index");
            }

            return View(contatoTipoViewModel);
        }

        // GET: ContatoTipos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoTipoViewModel contatoTipoViewModel = _contatoTipoAppService.GetById(id.Value);
            if (contatoTipoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contatoTipoViewModel);
        }

        // POST: ContatoTipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContatoTipoViewModel contatoTipoViewModel)
        {
            if (ModelState.IsValid)
            {
                _contatoTipoAppService.Update(contatoTipoViewModel);
                return RedirectToAction("Index");
            }
            return View(contatoTipoViewModel);
        }

        // GET: ContatoTipos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoTipoViewModel contatoTipoViewModel = _contatoTipoAppService.GetById(id.Value);
            if (contatoTipoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contatoTipoViewModel);
        }

        // POST: ContatoTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _contatoTipoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contatoTipoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
