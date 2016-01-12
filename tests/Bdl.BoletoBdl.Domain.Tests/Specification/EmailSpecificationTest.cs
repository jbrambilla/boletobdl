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
    public class EmailSpecificationTest
    {
        public Membro Membro { get; set; }

        [TestMethod]
        public void Email_Valid_True()
        {
            Membro = new Membro()
            {
                Email = "jovem@membro.com"
            };

            var email = new MembroDeveTerEmailValidoSpecification();
            Assert.IsTrue(email.IsSatisfiedBy(Membro));
        }

        [TestMethod]
        public void Email_Valid_False()
        {
            Membro = new Membro()
            {
                Email = "jovem2membro.com"
            };

            var email = new MembroDeveTerEmailValidoSpecification();
            Assert.IsFalse(email.IsSatisfiedBy(Membro));
        }
    }
}
