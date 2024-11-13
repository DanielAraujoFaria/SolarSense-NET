using SolarSense.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSense.Services.Services
{
    public interface IProdPainelService
    {
        Task<IEnumerable<ProducaoPainel>> GetAllProducoesAsync();
        Task<ProducaoPainel> GetProducaoByIdAsync(int id);
        Task<ProducaoPainel> CreateProducaolAsync(ProducaoPainel producao);
        Task UpdateProducaoAsync(ProducaoPainel producao);
        Task DeleteProducaoAsync(int id);
    }
}
