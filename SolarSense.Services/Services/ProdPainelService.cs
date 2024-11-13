using SolarSense.Database.Models;
using SolarSense.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarSense.Services.Services
{
    public class ProdPainelService : IProdPainelService
    {
        private readonly IRepository<ProducaoPainel> _producaoRepository;

        public ProdPainelService(IRepository<ProducaoPainel> producaoRepository)
        {
            _producaoRepository = producaoRepository;
        }

        public Task<IEnumerable<ProducaoPainel>> GetAllProducoesAsync()
        {
            return Task.Run(() => _producaoRepository.GetAll());
        }

        public Task<ProducaoPainel> GetProducaoByIdAsync(int id)
        {
            return Task.Run(() => _producaoRepository.GetById(id));
        }

        public Task<ProducaoPainel> CreateProducaolAsync(ProducaoPainel producao)
        {
            return Task.Run(() => {
                _producaoRepository.Add(producao);
                return producao;
            });
        }

        public Task UpdateProducaoAsync(ProducaoPainel producao)
        {
            return Task.Run(() => _producaoRepository.Update(producao));
        }

        public Task DeleteProducaoAsync(int id)
        {
            return Task.Run(() => {
                var producao = _producaoRepository.GetById(id);
                if (producao != null)
                {
                    _producaoRepository.Delete(producao);
                }
            });
        }
    }
}
