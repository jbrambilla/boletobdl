using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Specifications.Membros;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Validations.Membros
{
    public class MembroEstaConsistenteValidation : Validator<Membro>
    {
        public MembroEstaConsistenteValidation()
        {
            var CPFMembro = new MembroDeveTerCpfValidoSpecification();
            var membroEmail = new MembroDeveTerEmailValidoSpecification();
            var membroMaioridade = new MembroDeveSerMaiorDeIdadeSpecification();

            base.Add("CPFMembro", new Rule<Membro>(CPFMembro, "O CPF informado é invalido."));
            base.Add("membroEmail", new Rule<Membro>(membroEmail, "O E-mail informado é invalido."));
            base.Add("membroMaioridade", new Rule<Membro>(membroMaioridade, "O Membro deve possuir mais de 18 anos."));
        }
    }
}
