using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Away_Bank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo { get; }
        public double ValorSaque { get; }

        public SaldoInsuficienteException() // Retornar exception sem argumentos recebidos
        {

        }

        public SaldoInsuficienteException(string mensagem) // Receber string, e enviar para a classe base uma mensagem de erro
            : base(mensagem)
        {

        }

        public SaldoInsuficienteException(string mensagem, Exception excessaoInterna) // Receber string e exception, e enviar para a classe base uma mensagem de erro
            : base(mensagem, excessaoInterna)
        {

        }

        public SaldoInsuficienteException(double saldo, double valorSaque) // Receber valores de saldo e saque, e enviar para a classe base uma mensagem de erro
            : this("Tentativa de Saque no valor de R$" + valorSaque + " inválida. Saldo Disponível: R$" + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
    }
}
