using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEcommerce.Domain.ValueObject
{
    public class Email
    {
        public const int EnderecoMaxLenght = 254;
        public string Endereco { get; private set; }
    }
}
