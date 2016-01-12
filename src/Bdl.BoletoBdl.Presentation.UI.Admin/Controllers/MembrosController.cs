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
                membroEnderecoViewModel = _membroAppService.Add(membroEnderecoViewModel);
                if (!membroEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in membroEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    loadViewBags();
                    return View(membroEnderecoViewModel);
                }

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
            ViewBag.MembroId = id;
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
                membroViewModel = _membroAppService.Update(membroViewModel);
                if (!membroViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in membroViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    loadViewBags();
                    ViewBag.MembroId = membroViewModel.MembroId;
                    return View(membroViewModel);
                }

                return RedirectToAction("Index");
            }
            loadViewBags();
            ViewBag.MembroId = membroViewModel.MembroId;
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

        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.MembroId = id;
            return PartialView("_EnderecoList", _membroAppService.GetById(id).EnderecoList);
        }


        public ActionResult AdicionarEndereco(Guid id)
        {
            ViewBag.MembroId = id;
            return PartialView("_AdicionarEndereco");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _membroAppService.AddEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Membros", new { id = enderecoViewModel.MembroId });
                return Json(new { success = true, url = url, replacetarget = "endereco"});
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _membroAppService.GetEnderecoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _membroAppService.UpdateEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Membros", new { id = enderecoViewModel.MembroId });
                return Json(new { success = true, url = url, replacetarget = "endereco" });
            }

            return PartialView("_AtualizarEndereco", enderecoViewModel);
        }

        public ActionResult DeletarEndereco(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var enderecoViewModel = _membroAppService.GetEnderecoById(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        // POST: Clientes/Delete/5

        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var membroId = _membroAppService.GetEnderecoById(id).MembroId;
            _membroAppService.RemoveEndereco(id);

            string url = Url.Action("ListarEnderecos", "Membros", new { id = membroId });
            return Json(new { success = true, url = url, replacetarget = "endereco" });
        }

        public ActionResult ListarContatos(Guid id)
        {
            ViewBag.MembroId = id;
            return PartialView("_ContatoList", _membroAppService.GetById(id).ContatoList);
        }

        public ActionResult AdicionarContato(Guid id)
        {
            ViewBag.MembroId = id;
            ViewBag.ContatoTipoId = new SelectList(_membroAppService.GetAllContatoTipo().OrderBy(g => g.Nome), "ContatoTipoId", "Nome");
            return PartialView("_AdicionarContato");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _membroAppService.AddContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Membros", new { id = contatoViewModel.MembroId });
                return Json(new { success = true, url = url, replacetarget = "contato" });
            }
            ViewBag.ContatoTipoId = new SelectList(_membroAppService.GetAllContatoTipo().OrderBy(g => g.Nome), "ContatoTipoId", "Nome");
            return PartialView("_AdicionarContato", contatoViewModel);
        }

        public ActionResult AtualizarContato(Guid id)
        {
            ViewBag.ContatoTipoId = new SelectList(_membroAppService.GetAllContatoTipo().OrderBy(g => g.Nome), "ContatoTipoId", "Nome");
            return PartialView("_AtualizarContato", _membroAppService.GetContatoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _membroAppService.UpdateContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Membros", new { id = contatoViewModel.MembroId });
                return Json(new { success = true, url = url, replacetarget = "contato" });
            }
            ViewBag.ContatoTipoId = new SelectList(_membroAppService.GetAllContatoTipo().OrderBy(g => g.Nome), "ContatoTipoId", "Nome");
            return PartialView("_AtualizarContato", contatoViewModel);
        }

        public ActionResult DeletarContato(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contatoViewModel = _membroAppService.GetContatoById(id.Value);
            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarContato", contatoViewModel);
        }

        // POST: Clientes/Delete/5

        [HttpPost, ActionName("DeletarContato")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarContatoConfirmed(Guid id)
        {
            var membroId = _membroAppService.GetContatoById(id).MembroId;
            _membroAppService.RemoveContato(id);

            string url = Url.Action("ListarContatos", "Membros", new { id = membroId });
            return Json(new { success = true, url = url, replacetarget = "contato" });
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
