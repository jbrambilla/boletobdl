using Bdl.BoletoBdl.Domain.Validations.Membros;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Entities
{
    public class Membro
    {
        public Membro()
        {
            MembroId = Guid.NewGuid();
            EnderecoList = new List<Endereco>();
            ContatoList = new List<Contato>();
        }

        public Guid MembroId { get; set; }
        public Guid GraduacaoId { get; set; }

        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public string CategoriaCNH { get; set; }
        public string TipoSanguineo { get; set; }
        public string Naturalidade { get; set; }
        public string EstadoCivil { get; set; }
        public string Padrinho { get; set; }
        public string AtividadeProfissional { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        public string Email { get; set; }

        public bool Ativo { get; set; }
        
        public DateTime DataAdmissao { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual Graduacao Graduacao { get; set; }
        public virtual ICollection<Endereco> EnderecoList { get; set; }
        public virtual ICollection<Contato> ContatoList { get; set; }

        public ValidationResult ValidationResult { get; set; }    

        public bool IsValid()
        {
            ValidationResult = new MembroEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
