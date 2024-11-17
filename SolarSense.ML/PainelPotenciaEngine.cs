using Microsoft.ML;
using SolarSense.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSense.ML
{
    internal class PainelPotenciaEngine
    {
        private readonly MLContext _mlContext;
        private ITransformer? _model;

        public PainelPotenciaEngine()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(IEnumerable<PainelPotencia> painelPotenciaList)
        {
            var data = painelPotenciaList.Select(p => new PainelPotenciaInput
            {
                PainelId = p.IdPainel,
                ClienteId = p.IdCliente,
                Label = p.PotenciaGerada 
            }).ToList();

            var trainingData = _mlContext.Data.LoadFromEnumerable(data);

            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("PainelIdEncoded", nameof(PainelPotenciaInput.PainelId))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("ClienteIdEncoded", nameof(PainelPotenciaInput.ClienteId)))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                    labelColumnName: nameof(PainelPotenciaInput.Label),
                    matrixColumnIndexColumnName: "PainelIdEncoded",
                    matrixRowIndexColumnName: "ClienteIdEncoded"));

            _model = pipeline.Fit(trainingData);
        }

        public float Predict(int clienteId, int painelId)
        {
            if (_model == null)
                throw new InvalidOperationException("O modelo ainda não foi treinado.");

            var predictionEngine = _mlContext.Model.CreatePredictionEngine<PainelPotenciaInput, PainelPotenciaPrediction>(_model);

            var prediction = predictionEngine.Predict(new PainelPotenciaInput
            {
                ClienteId = clienteId,
                PainelId = painelId
            });

            return prediction.Score; 
        }

        public class PainelPotenciaInput
        {
            public int ClienteId { get; set; }
            public int PainelId { get; set; }
            public float Label { get; set; }
        }

        public class PainelPotenciaPrediction
        {
            public float Score { get; set; } 
        }
    }
}
