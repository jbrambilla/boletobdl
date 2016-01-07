using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Entities
{
    public class ContatoTipo
    {
        public ContatoTipo()
        {
            ContatoTipoId = Guid.NewGuid();
            ContatoList = new List<Contato>();
        }

        public Guid ContatoTipoId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Contato> ContatoList { get; set; }
    }
}
