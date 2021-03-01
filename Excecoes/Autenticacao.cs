using System;
using System.Collections.Generic;
using System.Text;

namespace Excecoes
{
    // Gerando uma classe genérica para qualquer criação de uma Exception
    public class AutenticacaoException : Exception
    {
        public AutenticacaoException(string Message) : base(Message) { }
    }

    public class UsuarioInvalidoException : AutenticacaoException
    {
        public UsuarioInvalidoException(string Message) : base(Message) { }

    }

    public class SenhaInvalidaException : AutenticacaoException
    {
        public SenhaInvalidaException(string Message) : base(Message) { }
    }
    class Autenticacao
    {
        public void Autenticar(string login, string senha)
        {
            if (login != "admin")
            {
                throw new UsuarioInvalidoException("Usuario invalido");
            }
            if (senha != "admin")
            {
                throw new SenhaInvalidaException("Senha invalida");
            }
        }

    }
}
