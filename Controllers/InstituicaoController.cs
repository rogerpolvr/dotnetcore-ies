using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IES.Models;
using Microsoft.AspNetCore.Mvc;

namespace IES.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao()
            {
                InstituicaoID = 1,
                Nome = "PUCRS",
                Endereco = "Av Ipiranga - Porto Alegre"
            },
            new Instituicao()
            {
                InstituicaoID = 2,
                Nome = "Unisinos",
                Endereco = "Av Unisinos - São Leopoldo"
            },
            new Instituicao()
            {
                InstituicaoID = 3,
                Nome = "Ulbra",
                Endereco = "Av Ulbra - Canoas"
            }
        };

        //GET: Create
        public IActionResult Index()
        {
            return View(instituicoes.OrderBy(i => i.InstituicaoID));
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }  
        
        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)
        {
            instituicoes.Add(instituicao);
            instituicao.InstituicaoID = instituicoes.Select(i => i.InstituicaoID).Max() + 1;
            return RedirectToAction("Index");
        }

        //GET: Edit
        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

        //GET: Details
        public ActionResult Details(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        //GET: Delete
        public ActionResult Delete(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            return RedirectToAction("Index");
        }


    }
}