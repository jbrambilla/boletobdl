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
    public class MembrosController : Controller
    {
        private readonly IMembroAppService _membroAppService;

        public MembrosController(IMembroAppService membroAppService)
        {
            _membroAppService = membroAppService;
        }

        // GET: Membros
        public ActionResult Index()
        {
            return View(_membroAppService.GetAll());
        }

        // GET: Membros/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembroViewModel membroViewModel = _membroAppService.GetById(id.Value);
            if (membroViewModel == null)
            {
                return HttpNotFound();
            }
            return View(membroViewModel);
        }

        // GET: Membros/Create
        public ActionResult Create()
        {
            loadViewBags();
            return View();
        }

        // POST: Membros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MembroEnderecoViewModel membroEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _membroAppService.Add(membroEnderecoViewModel);
                return RedirectToAction("Index");
            }

            loadViewBags();
            return View(membroEnderecoViewModel);
        }

        // GET: Membros/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembroViewModel membroViewModel = _membroAppService.GetById(id.Value);
            if (membroViewModel == null)
            {
                return HttpNotFound();
            }
            loadViewBags();
            return View(membroViewModel);
        }

        // POST: Membros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MembroViewModel membroViewModel)
        {
            if (ModelState.IsValid)
            {
                _membroAppService.Update(membroViewModel);
                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(membroViewModel);
        }

        // GET: Membros/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembroViewModel membroViewModel = _membroAppService.GetById(id.Value);
            if (membroViewModel == null)
            {
                return HttpNotFound();
            }
            return View(membroViewModel);
        }

        // POST: Membros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _membroAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _membroAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private void loadViewBags()
        {
            ViewBag.GraduacaoId = new SelectList(_membroAppService.GetAllGraduacoes().OrderBy(g => g.Nome), "GraduacaoId", "Nome");
            ViewBag.ContatoTipoId = new SelectList(_membroAppService.GetAllContatoTipo().OrderBy(g => g.Nome), "ContatoTipoId", "Nome");
        }
    }
}
