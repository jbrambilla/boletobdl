using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Specifications.Membros;

namespace Bdl.BoletoBdl.Domain.Tests.Specification
{
    [TestClass]
    public class MaioridadeSpecificationTest
    {
        public Membro Membro { get; set; }

        [TestMethod]
        public void Maioridade_Valid_True()
        {
            Membro = new Membro()
            {
                Nascimento = new DateTime(1990, 12, 14)
            };

            var maioridade = new MembroDeveSerMaiorDeIdadeSpecification();
            Assert.IsTrue(maioridade.IsSatisfiedBy(Membro));
        }

        [TestMethod]
        public void Maioridade_Valid_False()
        {
            Membro = new Membro()
            {
                Nascimento = new DateTime(1999, 12, 14)
            };

            var maioridade = new MembroDeveSerMaiorDeIdadeSpecification();
            Assert.IsFalse(maioridade.IsSatisfiedBy(Membro));
        }
    }
}
