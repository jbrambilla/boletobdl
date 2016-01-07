using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Infra.Data.EntityConfig
{
    public class ContatoConfig : EntityTypeConfiguration<Contato>
    {
        public ContatoConfig()
        {
            HasKey(c => c.ContatoId);

            HasRequired(c => c.Membro)
                .WithMany(m => m.ContatoList)
                .HasForeignKey(c => c.MembroId);

            HasRequired(c => c.Tipo)
                .WithMany(t => t.ContatoList)
                .HasForeignKey(c => c.ContatoTipoId);
        }
    }
}
