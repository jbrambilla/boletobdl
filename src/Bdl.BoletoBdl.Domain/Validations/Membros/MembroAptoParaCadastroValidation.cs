using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Interfaces.Repository;
using Bdl.BoletoBdl.Domain.Specifications.Membros;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Validations.Membros
{
    public class MembroAptoParaCadastroValidation : Validator<Membro>
    {
        public MembroAptoParaCadastroValidation(IMembroRepository membroRepository)
        {
            var cpfDuplicado = new MembroDevePossuirCPFUnicoSpecification(membroRepository);
            var emailDuplicado = new MembroDevePossuirEmailUnicoSpecification(membroRepository);
            var membroEndereco = new MembroDeveTerUmEnderecoSpecification();

            base.Add("cpfDuplicado", new Rule<Membro>(cpfDuplicado, "CPF já cadastrado!"));
            base.Add("emailDuplicado", new Rule<Membro>(emailDuplicado, "E-mail já cadastrado!"));
            base.Add("membroEndereco", new Rule<Membro>(membroEndereco, "Endereço não informado!"));
        }
    }
}
