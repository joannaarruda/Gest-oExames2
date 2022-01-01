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
using Desafio.Intelectah.Business.Models.MarcacoesConsultas;
using Desafio.Intelectah.Business.Models.MarcacoesConsultas.Services;
using AutoMapper;

namespace Desafio.Intelectah.Controllers
{
    public class MarcacaoConsultaController : Controller
    {
        private readonly IMarcacaoConsultaRepository _marcacaoConsultaRepository;
        private readonly IMarcacaoConsultaService _marcacaoConsultaService;
        private readonly IMapper _mapper;

        public MarcacaoConsultaController(IMarcacaoConsultaRepository marcacaoConsultaRepository,
                                  IMarcacaoConsultaService marcacaoConsultaService,
                                  IMapper mapper)
        {
            _marcacaoConsultaRepository = marcacaoConsultaRepository;
            _marcacaoConsultaService = marcacaoConsultaService;
            _mapper = mapper;
        }

        // GET: MarcacaoConsulta
        [Route("lista-de-consultas")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MarcacaoConsultaViewModel>>(await _marcacaoConsultaRepository.ObterTodos()));
        }

        // GET: MarcacaoConsulta/Details/5
        [Route("dados-da-consulta/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var marcacaoConsultaViewModel = await ObterMarcacao(id);

            if (marcacaoConsultaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(marcacaoConsultaViewModel);
        }

        // GET: MarcacaoConsulta/Create
        [Route("nova-consulta")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: MarcacaoConsulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("nova-consulta")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MarcacaoConsultaViewModel marcacaoConsultaViewModel)
        {


            if (ModelState.IsValid)
            {
                await _marcacaoConsultaService.Adicionar(_mapper.Map<MarcacaoConsulta>(marcacaoConsultaViewModel));

                return RedirectToAction("Index");
            }

            return View(marcacaoConsultaViewModel);

        }


        // GET: MarcacaoConsulta/Edit/5
        [Route("editar-marcacao/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {

            var marcacaoConsultaViewModel = await ObterMarcacao(id);
            if (marcacaoConsultaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(marcacaoConsultaViewModel);
        }

        // POST: MarcacaoConsulta/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("editar-marcacao/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MarcacaoConsultaViewModel marcacaoConsultaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _marcacaoConsultaService.Atualizar(_mapper.Map<MarcacaoConsulta>(marcacaoConsultaViewModel));
                return RedirectToAction("Index");
            }
            return View(marcacaoConsultaViewModel);
        }

        // GET: MarcacaoConsulta/Delete/5
        [Route("excluir-marcacao/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {

            var marcacaoConsultaViewModel = await ObterMarcacao(id);
            if (marcacaoConsultaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(marcacaoConsultaViewModel);
        }

        // POST: MarcacaoConsulta/Delete/5
        [Route("excluir-marcacao/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var marcacaoConsultaViewModel = await ObterMarcacao(id);
            if (marcacaoConsultaViewModel == null)
            {
                return HttpNotFound();
            }

            _marcacaoConsultaService.Remover(id);
            return RedirectToAction("Index");
        }


        private async Task<MarcacaoConsultaViewModel> ObterMarcacao(Guid id)
            {
                var marcacaoConsulta = _mapper.Map<MarcacaoConsultaViewModel>(await _marcacaoConsultaRepository.ObterPacienteExame(id));
                return marcacaoConsulta;
            }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _marcacaoConsultaRepository.Dispose();
                _marcacaoConsultaService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
