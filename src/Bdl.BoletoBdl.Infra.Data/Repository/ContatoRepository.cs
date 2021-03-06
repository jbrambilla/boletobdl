﻿using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Interfaces.Repository;
using Bdl.BoletoBdl.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Infra.Data.Repository
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(BoletoBdlContext context)
            :base(context)
        {
        }
    }
}
