using ProjetoEcommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoEcommerce.Domain.ValueObject
{
    public class Email
    {
        public const int EnderecoMaxLenght = 254;
        public string Endereco { get; private set; }

        //construtor do Entity Framework
        protected Email()
        {

        }

        public Email(string endereco)
        {
            Guard.ForNullOrEmptyDefaultMessage(endereco, "E-mail");
            Guard.StringLength("E-mail", endereco, EnderecoMaxLenght);

            if (IsValid(endereco) == false)
                throw new Exception("E-mail inválido");

            Endereco = endereco;
        }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
