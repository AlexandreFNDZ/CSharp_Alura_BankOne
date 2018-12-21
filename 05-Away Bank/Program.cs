using _05_Away_Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOne
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente contaUm = new ContaCorrente(055, 445520); // Construtor com dois argumentos obrigatórios
                ContaCorrente contaDois = new ContaCorrente(055, 455663);

                Console.WriteLine(contaUm.Numero);
                Console.WriteLine(contaUm.Agencia);

                contaUm.Depositar(50);
                contaDois.Depositar(50);
                Console.WriteLine("\n\nSaldo Conta Um: R$" + contaUm.Saldo);
                Console.WriteLine("Saldo Conta Dois: R$" + contaDois.Saldo);

                contaDois.Transferir(60, contaUm);

                Console.WriteLine("\n\nSaldo Conta Um: R$" + contaUm.Saldo);
                Console.WriteLine("Saldo Conta Dois: R$" + contaDois.Saldo);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message); // Capturar a Exceção e mostrar a mensagem no console
            }
            catch (OperacaoFinanceiraException ex)
            {
                Console.WriteLine(ex.Message); // Capturar Exceção e mostrar mensagem no console
                Console.WriteLine(ex.InnerException.Message); // Capturar a Exceção e mostrar a mensagem da Exceção mais interna
            }

            Console.ReadLine();
        }
    }
}
