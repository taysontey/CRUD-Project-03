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
    public class JogadorController : Controller
    {
        //Se comunicando com o projeto.application
        private IAppServiceJogador appJogador;

        private IAppServiceTime appTime;

        public JogadorController(IAppServiceJogador appJogador, IAppServiceTime appTime)
        {
            this.appJogador = appJogador;
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

        public JsonResult CarregarTimes()
        {
            try
            {
                var list = new List<TimeModelDropDown>();

                foreach (Time t in appTime.ListarTodos())
                {
                    var model = new TimeModelDropDown();

                    model.IdTime = t.IdTime;
                    model.Nome = t.Nome;

                    list.Add(model);
                }

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Cadastrar(JogadorModelCadastro model)
        {

            try
            {
                Jogador j = new Jogador();
                j.Nome = model.Nome;
                j.Apelido = model.Apelido;
                j.Posicao = model.Posicao;
                j.DataNascimento = model.DataNascimento;
                j.IdTime = model.IdTime;

                appJogador.Cadastrar(j);

                return Json("Jogador " + j.Nome + ", cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Editar(JogadorModelEdicao model)
        {
            try
            {
                Jogador j = appJogador.ObterPorID(model.IdJogador);

                if (j != null)
                {
                    model.Nome = j.Nome;
                    model.Apelido = j.Apelido;
                    model.Posicao = j.Posicao;
                    model.DataNascimento = j.DataNascimento;
                    model.IdTime = j.Time.IdTime;
                }

                return Json(model);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Edicao(JogadorModelEdicao model)
        {
            try
            {
                Jogador j = new Jogador();
                j.IdJogador = model.IdJogador;
                j.Nome = model.Nome;
                j.Apelido = model.Apelido;
                j.Posicao = model.Posicao;
                j.DataNascimento = model.DataNascimento;

                j.Time = new Time();
                j.Time.IdTime = model.IdTime;

                appJogador.Atualizar(j);

                return Json("Jogador editado com sucesso, atualizando...");
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
                var list = new List<JogadorModelConsulta>();

                foreach (Jogador j in appJogador.ListarTodos())
                {
                    var model = new JogadorModelConsulta();

                    model.IdJogador = j.IdJogador;
                    model.Nome = j.Nome;
                    model.Apelido = j.Apelido;
                    model.Posicao = j.Posicao;
                    model.DataNascimento = j.DataNascimento.ToString("dd/MM/yyyy");
                    model.Time = j.Time.Nome;

                    list.Add(model);
                }

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Excluir(JogadorModelEdicao model)
        {
            try
            {
                Jogador j = appJogador.ObterPorID(model.IdJogador);

                if (j != null)
                {
                    appJogador.Excluir(j);

                    return Json("Jogador excluído, atualizando...");
                }
                else
                {
                    return Json("Jogador não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}