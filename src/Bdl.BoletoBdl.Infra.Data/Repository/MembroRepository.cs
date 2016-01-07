using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Interfaces.Repository;
using Bdl.BoletoBdl.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Infra.Data.Repository
{
    public class MembroRepository : RepositoryBase<Membro>, IMembroRepository
    {
        public MembroRepository(BoletoBdlContext context)
            :base(context)
        {
        }

        public Membro GetByCpf(string cpf)
        {
            return Search(c => c.CPF == cpf).FirstOrDefault();
        }

        public Membro GetByEmail(string email)
        {
            return Search(c => c.Email == email).FirstOrDefault();
        }

        public override void Remove(Guid id)
        {
 	        var membro = GetById(id);
            membro.Ativo = false;
            Update(membro);
        }
    }
}
