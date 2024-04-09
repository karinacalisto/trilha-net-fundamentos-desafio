using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class VeiculoEstacionado
    {
        public string Placa { get; }
        public DateTime HorarioEntrada { get; }

        public VeiculoEstacionado(string placa)
        {
            Placa = placa;
            HorarioEntrada = DateTime.Now;
        }
    }

    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<VeiculoEstacionado> veiculosEstacionados = new List<VeiculoEstacionado>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            VeiculoEstacionado novoVeiculo = new VeiculoEstacionado(placa);
            veiculosEstacionados.Add(novoVeiculo);
            Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            VeiculoEstacionado veiculo = veiculosEstacionados.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());
            if (veiculo != null)
            {
                DateTime horarioSaida = DateTime.Now;
                TimeSpan tempoEstacionado = horarioSaida - veiculo.HorarioEntrada;
                decimal valorTotal = precoInicial + (precoPorHora * (decimal)tempoEstacionado.TotalHours);
                veiculosEstacionados.Remove(veiculo);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculosEstacionados.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculosEstacionados)
                {
                    TimeSpan tempoEstacionado = DateTime.Now - veiculo.HorarioEntrada;
                    Console.WriteLine($"Placa: {veiculo.Placa}, Tempo estacionado: {tempoEstacionado}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
