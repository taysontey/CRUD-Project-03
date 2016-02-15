using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entity.Entities;
using Projeto.Domain.Contracts.Repository;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Domain.Services
{
    public class DomainServiceJogador : DomainServiceBase<Jogador>, IDomainServiceJogador
    {
        private IRepositoryTime repositorio;
    }
}
