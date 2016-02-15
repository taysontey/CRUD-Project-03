using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Web.Models;
using Projeto.Application.Contracts;
using Projeto.Entity.Entities;

namespace Projeto.Web.Controllers
{
    public class TimeController : Controller
    {
        //Se comunicando com o projeto.application
        private IAppServiceTime appTime;

        public TimeController(IAppServiceTime appTime)
        {
            this.appTime = appTime;
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            return View();
        }

        public JsonResult Cadastrar(TimeModelCadastro model)
        {
            try
            {
                Time t = new Time();
                t.Nome = model.Nome;
                t.DataFundacao = model.DataFundacao;

                appTime.Cadastrar(t);

                return Json("Time " + t.Nome + ", cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}