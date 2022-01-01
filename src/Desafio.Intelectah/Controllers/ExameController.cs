using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Desafio.Intelectah.ViewModels;
using Desafio.Intelectah.Business.Models.Exames;
using Desafio.Intelectah.Business.Models.Exames.Services;
using AutoMapper;

namespace Desafio.Intelectah.Controllers
{
    public class ExameController : Controller
    {
        private readonly IExameRepository _exameRepository;
        private readonly IExameService _exameService;
        private readonly IMapper _mapper;

        public ExameController(IExameRepository exameRepository,
                                  IExameService exameService,
                                  IMapper mapper)
        {
            _exameRepository = exameRepository;
            _exameService = exameService;
            _mapper = mapper;
        }

        // GET: Exame
        [Route("lista-de-exames")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ExameViewModel>>(await _exameRepository.ObterTodos()));
        }


        // GET: Exame/Details/5
        [Route("dados-do-exame/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var exameViewModel = await ObterExame(id);

            if (exameViewModel == null)
            {
                return HttpNotFound();
            }
            return View(exameViewModel);
        }

        // GET: Exame/Create
        [Route("novo-exame")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exame/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("novo-exame")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ExameViewModel exameViewModel)
        {


            if (ModelState.IsValid)
            {
                await _exameService.Adicionar(_mapper.Map<Exame>(exameViewModel));

                return RedirectToAction("Index");
            }

            return View(exameViewModel);

        }

        // GET: Exame/Edit/5
        [Route("editar-exame/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {

            var exameViewModel = await ObterExame(id);
            if (exameViewModel == null)
            {
                return HttpNotFound();
            }
            return View(exameViewModel);
        }

        // POST: Exame/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("editar-exame/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ExameViewModel exameViewModel)
        {
            if (ModelState.IsValid)
            {
                await _exameService.Atualizar(_mapper.Map<Exame>(exameViewModel));
                return RedirectToAction("Index");
            }
            return View(exameViewModel);
        }

        // GET: Exame/Delete/5
        [Route("excluir-exame/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {

            var exameViewModel = await ObterExame(id);
            if (exameViewModel == null)
            {
                return HttpNotFound();
            }
            return View(exameViewModel);
        }

        // POST: Exame/Delete/5
        [Route("excluir-exame/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var exameViewModel = await ObterExame(id);
            if (exameViewModel == null)
            {
                return HttpNotFound();
            }

            _exameService.Remover(id);
            return RedirectToAction("Index");
        }

        private async Task<ExameViewModel> ObterExame(Guid id)
        {
            var exame = _mapper.Map<ExameViewModel>(await _exameRepository.ObterExameTipo(id));
            return exame;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _exameRepository.Dispose();
                _exameService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
