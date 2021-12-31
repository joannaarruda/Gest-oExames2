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
using Desafio.Intelectah.Business.Models.TiposExames;
using Desafio.Intelectah.Business.Models.TiposExames.Services;
using AutoMapper;

namespace Desafio.Intelectah.Controllers
{
    public class TipoExameController : Controller
    {
        private readonly ITipoExameRepository _tipoExameRepository;
        private readonly ITipoExameService _tipoExameService;
        private readonly IMapper _mapper;

        public TipoExameController(ITipoExameRepository tipoExameRepository,
                                  ITipoExameService tipoExameService,
                                  IMapper mapper)
        {
            _tipoExameRepository = tipoExameRepository;
            _tipoExameService = tipoExameService;
            _mapper = mapper;
        }

        // GET: TiposExames
        [Route("lista-de-tipoexames")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<TipoExameViewModel>>(await _tipoExameRepository.ObterTodos()));
        }

        // GET: TiposExames/Details/5
        [Route("lista-de-tipoexames/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var tipoExameViewModel = await ObterTipoExame(id);

            if (tipoExameViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoExameViewModel);
        }
        // GET: TipoExame/Create
   
        [Route("novo-tipoexame")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: TipoExames/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("novo-tipoexame")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TipoExameViewModel tipoExameViewModel)
        {


            if (ModelState.IsValid)
            {
                await _tipoExameService.Adicionar(_mapper.Map<TipoExame>(tipoExameViewModel));

                return RedirectToAction("Index");
            }

            return View(tipoExameViewModel);
           
        }

        // GET: TipoExame/Edit/5
        [Route("editar-tipoexame/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {

            var tipoExameViewModel = await ObterTipoExame(id);
            if (tipoExameViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoExameViewModel);
        }

        // POST: Pacientes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("editar-tipoexame/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TipoExameViewModel tipoExameViewModel)
        {
            if (ModelState.IsValid)
            {
                await _tipoExameService.Atualizar(_mapper.Map<TipoExame>(tipoExameViewModel));
                return RedirectToAction("Index");
            }
            return View(tipoExameViewModel);
        }

        // GET: TipoExame/Delete/5
        
        [Route("excluir-tipoexame/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {

            var tipoExameViewModel = await ObterTipoExame(id);
            if (tipoExameViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoExameViewModel);
        }

        // POST: Pacientes/Delete/5
        [Route("excluir-tipoexame/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var tipoExameViewModel = await ObterTipoExame(id);
            if (tipoExameViewModel == null)
            {
                return HttpNotFound();
            }

            _tipoExameService.Remover(id);
            return RedirectToAction("Index");
        }
        private async Task<TipoExameViewModel> ObterTipoExame(Guid id)
        {
            var tipoExame = _mapper.Map<TipoExameViewModel>(await _tipoExameRepository.ObterPorId(id));
            return tipoExame;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tipoExameRepository.Dispose();
                _tipoExameService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
