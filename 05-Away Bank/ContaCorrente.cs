using _05_Away_Bank;
using BankOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ContaCorrente
{
    public int ContadorSaquesNaoPermitidos { get; private set; }
    public int TransferenciasNaoPermitidas { get; private set; }
    public static int TotalContasCriadas { get; private set; } // Pode ser consultada, mas não pode ser definida publicamente
    public static double TaxaOperacao { get; private set; }

    private Cliente _titular; // Campo 'titular' privado e Propriedade 'get' e 'set' atribuída de maneira tradicional
    public Cliente Titular
    {
        get
        {
            return _titular;
        }

        set
        {
            _titular = value;
        }
    }

    public int Agencia { get; } // Propriedade 'Agencia' com apenas 'get' (Só pode ser inicializado pelo construtor e, após, se torna somente leitura)
    public int Numero { get; } // Propriedade 'Numero' com apenas 'get' (Só pode ser inicializado pelo construtor e, após, se torna somente leitura)

    private double _saldo;
    public double Saldo
    {
        get
        {
            return _saldo; // Devolve o valor do saldo do Cliente
        }

        set
        {
            if (value < 0)
            {
                return; // Valor inválido para o saldo
            }

            _saldo = value; // Atribui o valor recebido para a variavel 'saldo' do Cliente
        }
    }

    public ContaCorrente(int agencia, int numero) // Construir um tipo 'ContaCorrente' com atributos obrigatórios
    {
        if (agencia <= 0)
        {
            throw new ArgumentException("Agencia inválida", nameof(agencia)); // Verificar e lançar uma exceção caso numero da agencia seja fornecido errado
        }
        if (numero <= 0)
        {
            throw new ArgumentException("Numero da Conta inválida", nameof(numero)); // Verificar e lançar uma exceção caso numero da conta seja fornecido errado
        }

        Agencia = agencia;
        Numero = numero;

        TotalContasCriadas++; // Incrementar o total de Contas Criadas
       
        TaxaOperacao = 30 / TotalContasCriadas; // Determinar a taxa de Operação a partir da quantidade de contas criadas
    }

    public void Sacar(double valor)
    {
        if (valor < 0)
        {
            throw new ArgumentException("Valor de saque inválido", nameof(valor)); // Retornar erro se informado valor negativo para saque
        }

        if (this.Saldo < valor)
        {
            ContadorSaquesNaoPermitidos++;
            throw new SaldoInsuficienteException(this.Saldo, valor); // Não possui saldo para realizar ação, retorna false
        } 
        
        this.Saldo -= valor; // Operação saque realizada, subtrai valor do saldo do Cliente   
    }

    public void Depositar(double valor)
    {
        this.Saldo += valor; // Acrescenta valor ao valor existente no saldo do Cliente
    }

    public void Transferir(double valor, ContaCorrente contaDestino)
    {
        if (valor < 0)
        {
            throw new ArgumentException("Valor para transferência inválido", nameof(valor)); // Retornar erro se informado valor negativo para tranferencia
        }

        try
        {
            this.Sacar(valor);
        }
        catch (SaldoInsuficienteException ex)
        {
            TransferenciasNaoPermitidas++;
            ContadorSaquesNaoPermitidos--;
            throw new OperacaoFinanceiraException("Operação não realizada", ex);
        }
          
        contaDestino.Depositar(valor); // Acrescenta valor ao saldo do Cliente-Destino  
    }

}