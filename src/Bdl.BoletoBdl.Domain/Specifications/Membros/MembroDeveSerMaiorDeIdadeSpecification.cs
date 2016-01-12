using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Validations.Datas;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Specifications.Membros
{
    public class MembroDeveSerMaiorDeIdadeSpecification : ISpecification<Membro>
    {
        public bool IsSatisfiedBy(Membro membro)
        {
            return MaioridadeValidation.Validar(membro.Nascimento);
        }
    }
}
