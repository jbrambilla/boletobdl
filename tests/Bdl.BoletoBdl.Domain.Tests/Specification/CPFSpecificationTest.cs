using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Specifications.Membros;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Tests.Specification
{
    [TestClass]
    public class CPFSpecificationTest
    {
        public Membro Membro { get; set; }

        [TestMethod]
        public void CPF_Valido_True()
        {
            Membro = new Membro()
            {
                CPF = "30390600822"
            };

            var cpf = new MembroDeveTerCpfValidoSpecification();
            Assert.IsTrue(cpf.IsSatisfiedBy(Membro));
        }

        [TestMethod]
        public void CPF_Valido_False()
        {
            Membro = new Membro()
            {
                CPF = "30390600821"
            };

            var cpf = new MembroDeveTerCpfValidoSpecification();
            Assert.IsFalse(cpf.IsSatisfiedBy(Membro));
        }
    }
}
