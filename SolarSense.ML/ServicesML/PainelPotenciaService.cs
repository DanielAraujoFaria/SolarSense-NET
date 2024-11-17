using SolarSense.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSense.ML.ServicesML
{
    public class PainelPotenciaService
    {
        private readonly PainelPotenciaEngine _engine;

        public PainelPotenciaService()
        {
            _engine = new PainelPotenciaEngine();
        }

        public void TrainModel(IEnumerable<PainelPotencia> painelPotencias)
        {
            _engine.TrainModel(painelPotencias);
        }

        public float Predict(int clienteId, int painelId)
        {
            return _engine.Predict(clienteId, painelId);
        }
    }
}
