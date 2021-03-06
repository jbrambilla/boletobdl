﻿using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Validations.Documentos;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Specifications.Membros
{
    public class MembroDeveTerCpfValidoSpecification : ISpecification<Membro>
    {
        public bool IsSatisfiedBy(Membro membro)
        {
            return CPFValidation.Validar(membro.CPF);
        }
    }
}
