using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Entities
{
    public class Contato
    {
        public Contato()
        {
            ContatoId = Guid.NewGuid();
        }

        public Guid ContatoId { get; set; }
        public Guid ContatoTipoId { get; set; }
        public Guid MembroId { get; set; }

        public string Descricao { get; set; }
        public string Telefone { get; set; }

        public virtual ContatoTipo Tipo { get; set; }
        public virtual Membro Membro { get; set; }
    }
}
