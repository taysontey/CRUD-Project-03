using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entity.Entities;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Contracts.Repository;

namespace Projeto.Domain.Services
{
    public class DomainServiceTime : DomainServiceBase<Time>, IDomainServiceTime
    {
        //Se comunicando com o projeto.infraestructure
        private IRepositoryTime repositorio;

        public DomainServiceTime(IRepositoryTime repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
