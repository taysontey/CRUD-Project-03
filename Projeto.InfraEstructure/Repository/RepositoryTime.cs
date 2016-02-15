using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Contracts.Repository;
using Projeto.Entity.Entities;

namespace Projeto.InfraEstructure.Repository
{
    public class RepositoryTime : RepositoryBase<Time>, IRepositoryTime
    {
    }
}
