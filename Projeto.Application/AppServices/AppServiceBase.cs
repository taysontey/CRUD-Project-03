using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Application.Contracts;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Application.AppServices
{
    public abstract class AppServiceBase<TEntity> : IAppServiceBase<TEntity>
        where TEntity : class
    {
        //Se comunicando com o projeto.domain
        private IDomainServiceBase<TEntity> dominio;

        public AppServiceBase(IDomainServiceBase<TEntity> dominio)
        {
            this.dominio = dominio;
        }

        public void Cadastrar(TEntity obj)
        {
            dominio.Cadastrar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            dominio.Atualizar(obj);
        }

        public void Excluir(TEntity obj)
        {
            dominio.Excluir(obj);
        }

        public List<TEntity> ListarTodos()
        {
            return dominio.ListarTodos();
        }

        public TEntity ObterPorID(int id)
        {
            return dominio.ObterPorID(id);
        }
    }
}
