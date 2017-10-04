﻿using ProjetoEcommerce.Domain.ValueObject;
using ProjetoEcommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEcommerce.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }

        public const int LoginMinValue = 6;
        public const int LoginMaxValue = 30;
        public string Login { get; private set; }

        public Endereco Endereco { get; private set; }

        public const int SenhaMinValue = 6;
        public const int SenhaMaxValue = 30;
        public byte[] Senha { get; private set; }

        public Guid TokenAlteracaoDeSenha { get; private set; }

        //Construtor EntityFramework
        protected Usuario()
        {

        }

        public Usuario(string login, Cpf cpf, Email email, string senha, string senhaConfirmacao)
        {
            SetLogin(login);
            SetCpf(cpf);
            SetEmail(email);
            SetSenha(senha, senhaConfirmacao);
        }

        public void SetLogin(string login)
        {
            Guard.ForNullOrEmptyDefaultMessage(login, "Login");
            Guard.StringLength("Login", login, LoginMinValue, LoginMaxValue);
            Login = login;
        }

        public void SetCpf(Cpf cpf)
        {
            if (cpf == null)
                throw new Exception("Cpf Obrigatório");
            Cpf = cpf;
        }

        public void SetEmail(Email email)
        {
            if (email == null)
                throw new Exception("E-mail Obrigatório");
            Email = email;
        }

        private void SetSenha(string senha, string senhaConfirmacao)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage(senhaConfirmacao, "Confirmação de Senha");
            Guard.StringLength("Senha", senha, SenhaMinValue, SenhaMaxValue);
            //Guard.AreEqual(senha, senhaConfirmacao, "As senhas não conferem!");

            Senha = CriptografiaHelper.CriptografarSenha(senha);
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmacaoDeSenha)
        {
            ValidarSenha(senhaAtual);
            SetSenha(novaSenha, confirmacaoDeSenha);
        }

        public void ValidarSenha(string senha)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            var senhaCriptografada = CriptografiaHelper.CriptografarSenha(senha);
            if (!Senha.SequenceEqual(senhaCriptografada))
                throw new Exception("Senha inválida!");
        }

        public Guid GerarNovoTokenAlterarSenha()
        {
            TokenAlteracaoDeSenha = Guid.NewGuid();
            return TokenAlteracaoDeSenha;
        }

        public void AlterarSenha(Guid token, string novaSenha, string confirmacaoDeSenha)
        {
            if (!TokenAlteracaoDeSenha.Equals(token))
                throw new Exception("token para alteração de senha inválido!");
            SetSenha(novaSenha, confirmacaoDeSenha);
            GerarNovoTokenAlterarSenha();
        }
    }
}
