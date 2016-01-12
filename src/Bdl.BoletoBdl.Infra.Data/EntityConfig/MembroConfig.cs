using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Infra.Data.EntityConfig
{
    public class MembroConfig : EntityTypeConfiguration<Membro>
    {
        public MembroConfig()
        {
            HasKey(m => m.MembroId);

            HasRequired(m => m.Graduacao)
                .WithMany(g => g.MembroList)
                .HasForeignKey(m => m.GraduacaoId);

            Ignore(m => m.ValidationResult);

        }
    }
}
