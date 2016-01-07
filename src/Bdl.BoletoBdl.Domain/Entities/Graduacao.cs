using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Entities
{
    public class Graduacao
    {
        public Graduacao()
        {
            GraduacaoId = Guid.NewGuid();
            MembroList = new List<Membro>();
        }

        public Guid GraduacaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual ICollection<Membro> MembroList { get; set; }
    }
}
