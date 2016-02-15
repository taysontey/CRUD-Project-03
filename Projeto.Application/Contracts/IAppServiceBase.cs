using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Contracts
{
    public interface IAppServiceBase<TEntity>
        where TEntity : class
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        List<TEntity> ListarTodos();
        TEntity ObterPorID(int id);
    }
}
