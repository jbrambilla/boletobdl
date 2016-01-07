using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Interfaces.Repository
{
    public interface IMembroRepository : IRepositoryBase<Membro>
    {
        Membro GetByCpf(string cpf);
        Membro GetByEmail(string email);
    }
}
