using SolarSense.Database.Models;
using SolarSense.ML;
using SolarSense.ML.ServicesML;
using System;
using System.Collections.Generic;
using Xunit;

namespace SolarSense.Services.Test
{
    public class PainelPotenciaServiceTest
    {
        [Fact]
        public void TestTrainAndPredict()
        {
            var painelPotenciaService = new PainelPotenciaService();

            var listaPainelPotencia = new List<PainelPotencia>
            {
                new PainelPotencia { Id = 1, IdPainel = 1, IdCliente = 1, CondicaoClimatica = "Ensolarado", Localizacao = "São Paulo", PotenciaGerada = 250f, DataRegistro = DateTime.Now },
                new PainelPotencia { Id = 2, IdPainel = 2, IdCliente = 1, CondicaoClimatica = "Nublado", Localizacao = "São Paulo", PotenciaGerada = 180f, DataRegistro = DateTime.Now },
                new PainelPotencia { Id = 3, IdPainel = 3, IdCliente = 2, CondicaoClimatica = "Chuvoso", Localizacao = "Curitiba", PotenciaGerada = 120f, DataRegistro = DateTime.Now },
            };

            painelPotenciaService.TrainModel(listaPainelPotencia);

            int clienteId = 1;
            int painelId = 2;
            float score = painelPotenciaService.Predict(clienteId, painelId);

            Assert.True(score >= 0, $"A potência prevista para o painel {painelId} deveria ser maior ou igual a 0, mas foi {score}");
        }
    }
}
