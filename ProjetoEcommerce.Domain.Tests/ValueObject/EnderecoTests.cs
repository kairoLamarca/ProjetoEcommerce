using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoEcommerce.Domain.ValueObject;
using ProjetoEcommerce.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEcommerce.Domain.Tests.ValueObject
{
    [TestClass]
    public class EnderecoTests
    {
        private string Logradouro { get; set; }
        private string Complemento { get; set; }
        private string Numero { get; set; }
        private string Bairro { get; set; }
        private string Cidade { get; set; }
        private Uf? Uf { get; set; }
        private Cep Cep { get; set; }

        public EnderecoTests()
        {
            Logradouro = "Rua Professor Herval Aurélio Marconi";
            Complemento = "N";
            Numero = "2148";
            Bairro = "Jardim do Líbano";
            Cidade = "Franca";
            Uf = Enuns.Uf.SP;
            Cep = new Cep("14.403-530");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Endereco_New_Logradouro_Obrigatorio()
        {
            new Endereco("", Complemento, Numero, Bairro, Cidade, Uf, Cep);
        }
    }
}
