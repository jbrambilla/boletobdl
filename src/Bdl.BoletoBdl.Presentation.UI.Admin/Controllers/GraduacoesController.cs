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
    public class GraduacoesController : Controller
    {

        private readonly IGraduacaoAppService _graduacaoAppService;

        public GraduacoesController(IGraduacaoAppService graduacaoAppService)
        {
            _graduacaoAppService = graduacaoAppService;
        }

        // GET: Graduacoes
        public ActionResult Index()
        {
            return View(_graduacaoAppService.GetAll());
        }

        // GET: Graduacoes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraduacaoViewModel graduacaoViewModel = _graduacaoAppService.GetById(id.Value);
            if (graduacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(graduacaoViewModel);
        }

        // GET: Graduacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Graduacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GraduacaoViewModel graduacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                _graduacaoAppService.Add(graduacaoViewModel);
                return RedirectToAction("Index");
            }

            return View(graduacaoViewModel);
        }

        // GET: Graduacoes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraduacaoViewModel graduacaoViewModel = _graduacaoAppService.GetById(id.Value);
            if (graduacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(graduacaoViewModel);
        }

        // POST: Graduacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GraduacaoViewModel graduacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                _graduacaoAppService.Update(graduacaoViewModel);
                return RedirectToAction("Index");
            }
            return View(graduacaoViewModel);
        }

        // GET: Graduacoes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraduacaoViewModel graduacaoViewModel = _graduacaoAppService.GetById(id.Value);
            if (graduacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(graduacaoViewModel);
        }

        // POST: Graduacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _graduacaoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _graduacaoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
