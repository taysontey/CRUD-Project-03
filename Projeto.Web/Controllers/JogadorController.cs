using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Web.Models;
using Projeto.Application.Contracts;

namespace Projeto.Web.Controllers
{
    public class JogadorController : Controller
    {
        //Se comunicando com o projeto.application
        private IAppServiceJogador appJogador;

        public JogadorController(IAppServiceJogador appJogador)
        {
            this.appJogador = appJogador;
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            return View();
        }
    }
}