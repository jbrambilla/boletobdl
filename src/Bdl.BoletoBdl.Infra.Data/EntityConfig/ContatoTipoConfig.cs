using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Infra.Data.EntityConfig
{
    public class ContatoTipoConfig : EntityTypeConfiguration<ContatoTipo>
    {
        public ContatoTipoConfig()
        {
            HasKey(ct => ct.ContatoTipoId);
        }
    }
}
