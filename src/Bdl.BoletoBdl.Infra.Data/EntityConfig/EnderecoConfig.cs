using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.EnderecoId);

            HasRequired(e => e.Membro)
                .WithMany(m => m.EnderecoList)
                .HasForeignKey(e => e.MembroId);
        }
    }
}
