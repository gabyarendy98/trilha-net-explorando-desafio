﻿using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

try
{
    Console.WriteLine("🏨 Bem-vindo ao sistema de hospedagem!\n");

    // Cadastro da suíte
    Console.Write("Digite o tipo da suíte: ");
    string tipo = Console.ReadLine();

    Console.Write("Digite a capacidade da suíte: ");
    int capacidade = Convert.ToInt32(Console.ReadLine());

    Console.Write("Digite o valor da diária: ");
    decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());

    Suite suite = new Suite(tipo, capacidade, valorDiaria);

    // Cadastro da reserva
    Console.Write("\nDigite a quantidade de dias reservados: ");
    int dias = Convert.ToInt32(Console.ReadLine());

    Reserva reserva = new Reserva(dias);
    reserva.CadastrarSuite(suite);

    // Cadastro de hóspedes
    Console.Write("\nQuantos hóspedes deseja cadastrar? ");
    int qtdHospedes = Convert.ToInt32(Console.ReadLine());

    List<Pessoa> hospedes = new List<Pessoa>();

    for (int i = 1; i <= qtdHospedes; i++)
    {
        Console.Write($"Digite o nome do hóspede {i}: ");
        string nome = Console.ReadLine();

        Console.Write($"Digite o sobrenome do hóspede {i} (opcional): ");
        string sobrenome = Console.ReadLine();

        hospedes.Add(new Pessoa(nome, sobrenome));
    }

    reserva.CadastrarHospedes(hospedes);

    // Exibe resumo
    Console.WriteLine("\n===== RESUMO DA RESERVA =====");
    Console.WriteLine($"Suíte: {suite.TipoSuite} (Capacidade: {suite.Capacidade})");
    Console.WriteLine($"Hóspedes ({reserva.ObterQuantidadeHospedes()}):");
    foreach (var h in hospedes)
    {
        Console.WriteLine($"- {h.NomeCompleto}");
    }
    Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
    Console.WriteLine($"Valor total: R$ {reserva.CalcularValorDiaria():F2}");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Erro: {ex.Message}");
}
