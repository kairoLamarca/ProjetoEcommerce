using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoEcommerce.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEcommerce.Domain.Tests.ValueObject
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Em_Branco()
        {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Null()
        {
            var email = new Email(null);
        }

        [TestMethod]
        public void Email_New_Email_Valido()
        {
            var endereco = "lamarca.kairo@gmail.com";
            var email = new Email(endereco);
            Assert.AreEqual(endereco, email.Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Invalido()
        {
            var email = new Email("dfsdfsdsa");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_MaxLenght()
        {
            var endereco = "lamarca.kairo@gmail.com";
            while(endereco.Length < Email.EnderecoMaxLenght + 1)
            {
                endereco = endereco + "lamarca.kairo@gmail.com";
            }
            var email = new Email(endereco);
        }
    }
}
