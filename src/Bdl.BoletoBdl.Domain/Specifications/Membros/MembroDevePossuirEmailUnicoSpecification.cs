﻿using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Interfaces.Repository;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Specifications.Membros
{
    public class MembroDevePossuirEmailUnicoSpecification : ISpecification<Membro>
    {
        private readonly IMembroRepository _membroRepository;

        public MembroDevePossuirEmailUnicoSpecification(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        public bool IsSatisfiedBy(Membro membro)
        {
            return _membroRepository.GetByEmail(membro.Email) == null;
        }
    }
}
