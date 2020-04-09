using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IES.Data;
using IES.Data.DAL.Cadastros;
using IES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Cadastros;

namespace IES
{
    public class DepartamentoController : Controller
    {
        private readonly IESContext _context;
        private readonly DepartamentoDAL departamentoDAL;
        private readonly InstituicaoDAL instituicaoDAL;


        public DepartamentoController(IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
        }

        private async Task<IActionResult> ObterVisaoDepartamentoPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await departamentoDAL.ObterDepartamentoPorId((long)id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        private async Task<bool> DepartamentoExists(long? id)
        {
            return await departamentoDAL.ObterDepartamentoPorId((long)id) != null;
        }

        public async Task<IActionResult> Index()
        {
            return View(await departamentoDAL
                .ObterDepartamentosClassificadosPorNome().ToListAsync());

        }

        //GET: Departamento/Create
        public IActionResult Create()
        {
            var instituicoes = instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList();
            instituicoes.Insert(0, new Instituicao() { InstituicaoID = 0, Nome = "Selecione a instituicão" });
            ViewBag.Instituicoes = instituicoes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, InstituicaoID")] Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await departamentoDAL.GravarDepartamento(departamento);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }

            return View(departamento);
        }

        //GET: Departamento/Edit/?
        public async Task<IActionResult> Edit(long? id)
        {
            ViewResult visaoDepartamento =
                (ViewResult)await ObterVisaoDepartamentoPorId(id);

            Departamento departamento =
                (Departamento)visaoDepartamento.Model;

            ViewBag.Instituicoes =
                new SelectList(instituicaoDAL
                .ObterInstituicoesClassificadasPorNome(), "InstituicaoID", "Nome", departamento.InstituicaoID);


            return visaoDepartamento;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DepartamentoID,Nome, InstituicaoID")] Departamento departamento)

        {
            if (id != departamento.DepartamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await departamentoDAL.GravarDepartamento(departamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DepartamentoExists(departamento.DepartamentoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Instituicoes =
                new SelectList(_context.Instituicoes.OrderBy(b => b.Nome), "InstituicaoID", "Nome", departamento.InstituicaoID);

            return View(departamento);
        }

        //GET: Departamento/Details/?
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoDepartamentoPorId(id);
        }

        // GET: Departamento/Delete/?
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoDepartamentoPorId(id);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            await departamentoDAL.EliminarDepartamentoPorId((long)id);
            return RedirectToAction(nameof(Index));
        }

    }
}