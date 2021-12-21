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
using Desafio.Intelectah.Business.Models.Pacientes;
using Desafio.Intelectah.Business.Models.Pacientes.Services;
using AutoMapper;

namespace Desafio.Intelectah.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository pacienteRepository,
                                  IPacienteService pacienteService,
                                  IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        // GET: Pacientes
        [Route("lista-de-pacientes")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PacienteViewModel>>(await _pacienteRepository.ObterTodos()));
        }

        // GET: Pacientes/Details/5
        [Route("dados-do-paciente/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var pacienteViewModel = await ObterPaciente(id);

            if (pacienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pacienteViewModel);
        }

        // GET: Pacientes/Create
        [Route("novo-paciente")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("novo-paciente")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PacienteViewModel pacienteViewModel)
        {


            if (ModelState.IsValid)
            {
                await _pacienteService.Adicionar(_mapper.Map<Paciente>(pacienteViewModel));

                return RedirectToAction("Index");
            }

            return View(pacienteViewModel);
            //if (ModelState.IsValid)
            //{
            //    try
            //    {

            //        await _pacienteRepository.Adicionar(_mapper.Map<Paciente>(pacienteViewModel));
            //    }
            //    catch (Exception e)
            //    {
            //        return View(pacienteViewModel);
            //    }


            //    return RedirectToAction("Index");
            //}

            //return View(pacienteViewModel);
        }

        // GET: Pacientes/Edit/5
        [Route("editar-paciente/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {

            var pacienteViewModel = await ObterPaciente(id);
             if (pacienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pacienteViewModel);
        }

        // POST: Pacientes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("editar-paciente/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PacienteViewModel pacienteViewModel)
        {
            if (ModelState.IsValid)
            {
                await _pacienteService.Atualizar(_mapper.Map<Paciente>(pacienteViewModel));
                return RedirectToAction("Index");
            }
            return View(pacienteViewModel);
        }

        // GET: Pacientes/Delete/5
        [Route("excluir-paciente/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {

            var pacienteViewModel = await ObterPaciente(id);
            if (pacienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pacienteViewModel);
        }

        // POST: Pacientes/Delete/5
        [Route("excluir-paciente/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var pacienteViewModel = await ObterPaciente(id);
            if (pacienteViewModel == null)
            {
                return HttpNotFound();
            }

            _pacienteService.Remover(id);
            return RedirectToAction("Index");
        }

        private async Task<PacienteViewModel> ObterPaciente(Guid id)
        {
            var paciente = _mapper.Map<PacienteViewModel>(await _pacienteRepository.ObterPacienteExame(id));
            return paciente;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pacienteRepository.Dispose();
                _pacienteService.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
