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

        [HttpPost]
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

        public JsonResult Editar(TimeModelEdicao model)
        {
            try
            {
                Time t = appTime.ObterPorID(model.IdTime);

                if (t != null)
                {
                    model.Nome = t.Nome;
                    model.DataFundacao = t.DataFundacao;
                }

                return Json(model);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Edicao(TimeModelEdicao model)
        {
            try
            {
                Time t = new Time();
                t.IdTime = model.IdTime;
                t.Nome = model.Nome;
                t.DataFundacao = model.DataFundacao;

                appTime.Atualizar(t);

                return Json("Time editado com sucesso, atualizando...");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Consultar()
        {
            try
            {
                var list = new List<TimeModelConsulta>();

                foreach (Time t in appTime.ListarTodos())
                {
                    var model = new TimeModelConsulta();

                    model.IdTime = t.IdTime;
                    model.Nome = t.Nome;
                    model.DataFundacao = t.DataFundacao.ToString("dd/MM/yyyy");

                    list.Add(model);
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Excluir(TimeModelEdicao model)
        {
            try
            {
                Time t = appTime.ObterPorID(model.IdTime);

                if (t != null)
                {
                    appTime.Excluir(t);

                    return Json("Time excluído, atualizando...");
                }
                else
                {
                    return Json("Time não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}