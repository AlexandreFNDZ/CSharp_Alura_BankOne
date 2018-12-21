using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Away_Bank
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException() // Retornar exception sem argumentos recebidos
        {

        }

        public OperacaoFinanceiraException(string mensagem) // Receber string, e enviar para a classe base uma mensagem de erro
            : base(mensagem)
        {

        }

        public OperacaoFinanceiraException(string mensagem, Exception excessaoInterna) // Receber string e exception, e enviar para a classe base uma mensagem de erro
            : base(mensagem, excessaoInterna)
        {

        }
    }
}
