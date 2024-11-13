using SolarSense.Database.Models;
using SolarSense.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarSense.Services.Services
{
    public class PainelService : IPainelService
    {
        private readonly IRepository<Painel> _painelRepository;

        public PainelService(IRepository<Painel> painelRepository)
        {
            _painelRepository = painelRepository;
        }

        public Task<IEnumerable<Painel>> GetAllPaineisAsync()
        {
            return Task.Run(() => _painelRepository.GetAll());
        }

        public Task<Painel> GetPainelByIdAsync(int id)
        {
            return Task.Run(() => _painelRepository.GetById(id));
        }

        public Task<Painel> CreatePainelAsync(Painel painel)
        {
            return Task.Run(() => {
                _painelRepository.Add(painel);
                return painel;
            });
        }

        public Task UpdatePainelAsync(Painel painel)
        {
            return Task.Run(() => _painelRepository.Update(painel));
        }

        public Task DeletePainelAsync(int id)
        {
            return Task.Run(() => {
                var painel = _painelRepository.GetById(id);
                if (painel != null)
                {
                    _painelRepository.Delete(painel);
                }
            });
        }
    }
}
