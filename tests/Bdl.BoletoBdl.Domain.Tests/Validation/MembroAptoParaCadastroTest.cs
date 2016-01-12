using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Interfaces.Repository;
using Bdl.BoletoBdl.Domain.Validations.Membros;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Tests.Validation
{
    [TestClass]
    public class MembroAptoParaCadastroTest
    {
        public Membro Membro { get; set; }

        [TestMethod]
        public void MembroApto_Validation_True()
        {
            Membro = new Membro()
            {
                CPF = "30390600822",
                Email = "edu@edu.com.br"
            };

            Membro.EnderecoList.Add(new Endereco());

            var stubRepo = MockRepository.GenerateStub<IMembroRepository>();
            stubRepo.Stub(s => s.GetByEmail(Membro.Email)).Return(null);
            stubRepo.Stub(s => s.GetByCpf(Membro.CPF)).Return(null);

            var memValidation = new MembroAptoParaCadastroValidation(stubRepo);
            Assert.IsTrue(memValidation.Validate(Membro).IsValid);
        }

        [TestMethod]
        public void MembroApto_Validation_False()
        {
            Membro = new Membro()
            {
                CPF = "30390600822",
                Email = "edu@edu.com.br"
            };

            var stubRepo = MockRepository.GenerateStub<IMembroRepository>();
            stubRepo.Stub(s => s.GetByEmail(Membro.Email)).Return(Membro);
            stubRepo.Stub(s => s.GetByCpf(Membro.CPF)).Return(Membro);

            var memValidation = new MembroAptoParaCadastroValidation(stubRepo);
            var result = memValidation.Validate(Membro);

            Assert.IsFalse(memValidation.Validate(Membro).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "CPF já cadastrado!"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "E-mail já cadastrado!"));
        }
    }
}
