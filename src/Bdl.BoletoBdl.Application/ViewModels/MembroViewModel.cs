using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Application.ViewModels
{
    public class MembroViewModel
    {
        public MembroViewModel()
        {
            MembroId = Guid.NewGuid();
            EnderecoList = new List<EnderecoViewModel>();
            ContatoList = new List<ContatoViewModel>();
        }

        [Key]
        public Guid MembroId { get; set; }

        [Required(ErrorMessage = "Selecione uma Graduação")]
        [DisplayName("Graduação")]
        public Guid GraduacaoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        public string Apelido { get; set; }

        [Required(ErrorMessage = "Preencha o campo RG")]
        [MaxLength(9, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("RG")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNH")]
        [MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("CNH")]
        public string CNH { get; set; }

        [Required(ErrorMessage = "Preencha o campo Categoria da CNH")]
        [MaxLength(5, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Categoria da CNH")]
        public string CategoriaCNH { get; set; }

        [Required(ErrorMessage = "Selecione o Tipo Sanguíneo")]
        [DisplayName("Tipo Sanguíneo")]
        public string TipoSanguineo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Naturalidade")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Naturalidade { get; set; }

        [Required(ErrorMessage = "Selecione o Estado Civil")]
        [DisplayName("Estado Civil")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage = "Preencha o campo Padrinho")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Padrinho { get; set; }

        [Required(ErrorMessage = "Preencha o campo Atividade Profissional")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Atividade Profissional")]
        public string AtividadeProfissional { get; set; }

        [Required(ErrorMessage = "Preencha o campo Pai")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Pai { get; set; }

        [Required(ErrorMessage = "Preencha o campo Mãe")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Mae { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [Display(Name = "Data de Admissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAdmissao { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Nascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public virtual GraduacaoViewModel Graduacao { get; set; }

        public ICollection<EnderecoViewModel> EnderecoList { get; set; }
        public ICollection<ContatoViewModel> ContatoList { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
