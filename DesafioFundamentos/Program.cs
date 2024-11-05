using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.Clear();
Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
"Digite o preço inicial:");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
	Console.Clear();
	Console.WriteLine("Digite a sua opção:");
	Console.WriteLine("1 - Cadastrar veículo");
	Console.WriteLine("2 - Remover veículo");
	Console.WriteLine("3 - Listar veículos");
	Console.WriteLine("4 - Encerrar");

	switch (Console.ReadLine())
	{
		case "1":
			es.AdicionarVeiculo();
			break;

		case "2":
			es.RemoverVeiculo();
			break;

		case "3":
			es.ListarVeiculos();
			break;

		case "4":
			Console.Clear();
			Console.WriteLine("Tem certeza que deseja sair?");
      			Console.WriteLine("1 - Sim");
      			Console.WriteLine("2 - Não");
      			string confirma = Console.ReadLine();

			if (confirma == "1")
			{
				exibirMenu = false;
				break;
			}
			break;

		default:
			Console.WriteLine("Opção inválida");
			break;
	}

	Console.WriteLine("Pressione uma tecla para continuar.");
	Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
