using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
  public class Estacionamento
  {
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
      this.precoInicial = precoInicial;
      this.precoPorHora = precoPorHora;
    }

    public static bool ValidarPlaca(string placa)
    {
      placa = placa.Replace("-", "").Trim();

      if (string.IsNullOrEmpty(placa) || placa.Length != 7)
      {
        return false;
      }

      if (char.IsLetter(placa, 4))
      {
        var placaMercosul = new Regex("[a-zA-Z]{3}[1-9]{1}[a-zA-Z]{1}[1-9]{2}");
        return placaMercosul.IsMatch(placa);
      }
      else
      {
        var placaNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
        return placaNormal.IsMatch(placa);
      }

    }

    public void AdicionarVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo para estacionar:");
      string placa = Console.ReadLine().ToUpper();
      bool valida = ValidarPlaca(placa);
      var validado = valida ? $"Placa {placa} cadastrada." : $"Digite uma placa válida. Ex: ABC1234 / ABC1D23";

      if (valida == true)
      {
        veiculos.Add(placa);
      }

      Console.WriteLine(validado);
    }

    public void RemoverVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");
      string placaConsulta = Console.ReadLine().ToUpper();
      bool valida = ValidarPlaca(placaConsulta);

      if (valida == false)
      {
        Console.WriteLine("Placa inválida");
        return;
      }

      if (veiculos.Any(x => x.ToUpper() == placaConsulta.ToUpper()))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
        int horas = Convert.ToInt32(Console.ReadLine());
        decimal valorTotal = precoInicial + precoPorHora * horas;

        veiculos.Remove(placaConsulta);

        Console.WriteLine($"O veículo {placaConsulta} foi removido e o preço total foi de: R$ {valorTotal}");
      }
      else
      {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
      }
    }

    public void ListarVeiculos()
    {
      if (veiculos.Any())
      {
        Console.WriteLine("Os veículos estacionados são:");

        foreach (string veiculo in veiculos)
        {
          Console.WriteLine($"{veiculo}");
        }
      }
      else
      {
        Console.WriteLine("Não há veículos estacionados.");
      }
    }
  }
}