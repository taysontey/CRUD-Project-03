using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entity.Entities;
using Projeto.Application.Contracts;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Application.AppServices
{
    public class AppServiceJogador : AppServiceBase<Jogador>, IAppServiceJogador
    {
        private IDomainServiceJogador dominio;
    }
}
