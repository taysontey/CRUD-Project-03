using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Contracts.Repository;

namespace Projeto.Domain.Services
{
    public abstract class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity>
        where TEntity : class
    {
        private IRepositoryBase<TEntity> repositorio;


        public void Cadastrar(TEntity obj)
        {
            repositorio.Insert(obj);
        }

        public void Atualizar(TEntity obj)
        {
            repositorio.Update(obj);
        }

        public void Excluir(TEntity obj)
        {
            repositorio.Delete(obj);
        }

        public List<TEntity> ListarTodos()
        {
            return repositorio.FindAll();
        }

        public TEntity ObterPorID(int id)
        {
            return repositorio.FindById(id);
        }
    }
}
