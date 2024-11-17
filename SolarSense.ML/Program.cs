using SolarSense.Database.Models;
using SolarSense.ML.ServicesML;
using System;
using System.Collections.Generic;

namespace SolarSense.ML
{
    public class Program
    {
        public static void Main()
        {
            var historicoPainelPotencia = new List<PainelPotencia>
            {
                new PainelPotencia { Id = 1, IdPainel = 1, IdCliente = 1, CondicaoClimatica = "Ensolarado", Localizacao = "São Paulo", PotenciaGerada = 250f, DataRegistro = DateTime.Now },
                new PainelPotencia { Id = 2, IdPainel = 2, IdCliente = 2, CondicaoClimatica = "Nublado", Localizacao = "Rio de Janeiro", PotenciaGerada = 180f, DataRegistro = DateTime.Now },
                new PainelPotencia { Id = 3, IdPainel = 3, IdCliente = 3, CondicaoClimatica = "Chuvoso", Localizacao = "Curitiba", PotenciaGerada = 120f, DataRegistro = DateTime.Now },
            };

            var painelPotenciaService = new PainelPotenciaService();

            painelPotenciaService.TrainModel(historicoPainelPotencia);

            int clienteId = 1;
            int painelId = 2;
            float score = painelPotenciaService.Predict(clienteId, painelId);

            Console.WriteLine($"Potência prevista para o painel {painelId}, considerando as condições do cliente {clienteId}: {score} W");
        }
    }
}
