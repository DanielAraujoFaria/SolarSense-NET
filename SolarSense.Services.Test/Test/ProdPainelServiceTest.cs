using Xunit;
using Moq;
using SolarSense.Services.Services;
using SolarSense.Repository.Interface;
using SolarSense.Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSense.Services.Test.Test
{
    public class ProdPainelServiceTest
    {
        private readonly Mock<IRepository<ProducaoPainel>> _mockRepository;
        private readonly ProdPainelService _prodPainelService;

        public ProdPainelServiceTest()
        {
            _mockRepository = new Mock<IRepository<ProducaoPainel>>();
            _prodPainelService = new ProdPainelService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllProducoesAsync_ReturnsAllProducoes()
        {
            // Arrange
            var producoes = new List<ProducaoPainel>
            {
                new ProducaoPainel { Id = 1, IdPainel = 101, DataMedicao = DateTime.Today, Energia = 500, Eficiencia = 90, Alerta = "NAO" },
                new ProducaoPainel { Id = 2, IdPainel = 102, DataMedicao = DateTime.Today.AddDays(-1), Energia = 450, Eficiencia = 85, Alerta = "SIM" }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(producoes);

            // Act
            var result = await _prodPainelService.GetAllProducoesAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetProducaoByIdAsync_ReturnsProducao_WhenProducaoExists()
        {
            // Arrange
            var producao = new ProducaoPainel { Id = 1, IdPainel = 101, DataMedicao = DateTime.Today, Energia = 500, Eficiencia = 90, Alerta = "NAO" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(producao);

            // Act
            var result = await _prodPainelService.GetProducaoByIdAsync(1);

            // Assert
            Assert.Equal(producao, result);
        }

        [Fact]
        public async Task CreateProducaolAsync_AddsProducao()
        {
            // Arrange
            var producao = new ProducaoPainel { Id = 1, IdPainel = 101, DataMedicao = DateTime.Today, Energia = 500, Eficiencia = 90, Alerta = "NAO" };

            // Act
            await _prodPainelService.CreateProducaolAsync(producao);

            // Assert
            _mockRepository.Verify(repo => repo.Add(producao), Times.Once);
        }

        [Fact]
        public async Task UpdateProducaoAsync_UpdatesProducao()
        {
            // Arrange
            var producao = new ProducaoPainel { Id = 1, IdPainel = 101, DataMedicao = DateTime.Today, Energia = 520, Eficiencia = 92, Alerta = "NAO" };

            // Act
            await _prodPainelService.UpdateProducaoAsync(producao);

            // Assert
            _mockRepository.Verify(repo => repo.Update(producao), Times.Once);
        }

        [Fact]
        public async Task DeleteProducaoAsync_DeletesProducao_WhenProducaoExists()
        {
            // Arrange
            var producao = new ProducaoPainel { Id = 1, IdPainel = 101, DataMedicao = DateTime.Today, Energia = 500, Eficiencia = 90, Alerta = "NAO" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(producao);

            // Act
            await _prodPainelService.DeleteProducaoAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(producao), Times.Once);
        }

        [Fact]
        public async Task DeleteProducaoAsync_DoesNotDelete_WhenProducaoDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((ProducaoPainel)null);

            // Act
            await _prodPainelService.DeleteProducaoAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(It.IsAny<ProducaoPainel>()), Times.Never);
        }
    }
}
