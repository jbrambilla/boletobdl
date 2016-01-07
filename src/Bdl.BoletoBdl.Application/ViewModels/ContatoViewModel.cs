using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Application.ViewModels
{
    public class ContatoViewModel
    {
        public ContatoViewModel()
        {
            ContatoId = Guid.NewGuid();
        }

        [Key]
        public Guid ContatoId { get; set; }

        [Required(ErrorMessage = "Selecione um Tipo de Contato")]
        [DisplayName("Tipo de Contato")]
        public Guid ContatoTipoId { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Número")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [ScaffoldColumn(false)]
        public Guid MembroId { get; set; }
    }
}
