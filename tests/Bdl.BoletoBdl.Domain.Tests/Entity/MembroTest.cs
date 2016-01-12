using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bdl.BoletoBdl.Domain.Entities;
using System.Linq;

namespace Bdl.BoletoBdl.Domain.Tests.Entity
{
    [TestClass]
    public class MembroTest
    {
        public Membro Membro { get; set; }

        [TestMethod]
        public void MembroConsistente_Valid_True()
        {
            Membro = new Membro()
            {
                CPF = "02646324600",
                Nascimento = new DateTime(1982, 01, 01),
                Email = "jorge@bol.com"
            };

            Assert.IsTrue(Membro.IsValid());
        }

        [TestMethod]
        public void MembroConsistente_Valid_False()
        {
            Membro = new Membro()
            {
                CPF = "02646324111",
                Nascimento = new DateTime(2000, 01, 01),
                Email = "jorge2bol.com"
            };

            Assert.IsFalse(Membro.IsValid());
            Assert.IsTrue(Membro.ValidationResult.Erros.Any(e => e.Message == "O CPF informado é invalido."));
            Assert.IsTrue(Membro.ValidationResult.Erros.Any(e => e.Message == "O E-mail informado é invalido."));
            Assert.IsTrue(Membro.ValidationResult.Erros.Any(e => e.Message == "O Membro deve possuir mais de 18 anos."));

        }
    }
}
