using SolarSense.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarSense.Services.Services
{
    public interface IPainelService
    {
        Task<IEnumerable<Painel>> GetAllPaineisAsync();
        Task<Painel> GetPainelByIdAsync(int id);
        Task<Painel> CreatePainelAsync(Painel painel);
        Task UpdatePainelAsync(Painel painel);
        Task DeletePainelAsync(int id);
    }
}
