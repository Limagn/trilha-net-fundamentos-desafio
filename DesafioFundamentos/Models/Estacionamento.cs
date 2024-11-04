using System;
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
        var placaMercosul = new Regex("[a-zA-Z]{3}[1-9]{1}[a-zA-Z{1}[1-9]{2}");
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
      // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
      Console.WriteLine("Digite a placa do veículo para estacionar:");

      string placa = Console.ReadLine();
      bool valida = ValidarPlaca(placa);
      var validado = valida ? $"Placa {placa} cadastrada." : $"Digite uma placa válida. Ex: ABC1234 / ABC1D23";

      Console.WriteLine(validado);

      if (valida == true)
      {
        veiculos.Add(placa);
      }
    }

    public void RemoverVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");

      // Pedir para o usuário digitar a placa e armazenar na variável placa
      // *IMPLEMENTE AQUI*
      string placa = "";

      // Verifica se o veículo existe
      if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

        // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
        // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
        // *IMPLEMENTE AQUI*
        int horas = 0;
        decimal valorTotal = 0;

        // TODO: Remover a placa digitada da lista de veículos
        // *IMPLEMENTE AQUI*

        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
      }
      else
      {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
      }
    }

    public void ListarVeiculos()
    {
      // Verifica se há veículos no estacionamento
      if (veiculos.Any())
      {
        Console.WriteLine("Os veículos estacionados são:");
        // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
        // *IMPLEMENTE AQUI*
      }
      else
      {
        Console.WriteLine("Não há veículos estacionados.");
      }
    }
  }
}
