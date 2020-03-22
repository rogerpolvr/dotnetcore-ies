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
                InstituicaoID = 1,
                Nome = "Unisinos",
                Endereco = "Av Unisinos - São Leopoldo"
            },
            new Instituicao()
            {
                InstituicaoID = 1,
                Nome = "Ulbra",
                Endereco = "Av Ulbra - Canoas"
            }
        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }


    }
}