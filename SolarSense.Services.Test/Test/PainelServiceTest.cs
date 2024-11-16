using Xunit;
using Moq;
using SolarSense.Services.Services;
using SolarSense.Repository.Interface;
using SolarSense.Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SolarSense.Services.Test.Test
{
    public class PainelServiceTest
    {
        private readonly Mock<IRepository<Painel>> _mockRepository;
        private readonly PainelService _painelService;

        public PainelServiceTest()
        {
            _mockRepository = new Mock<IRepository<Painel>>();
            _painelService = new PainelService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllPaineisAsync_ReturnsAllPaineis()
        {
            // Arrange
            var paineis = new List<Painel>
            {
                new Painel { Id = 1, IdCliente = 1, Nome = "Painel Solar A", Potencia = 5, Localizacao = "Rooftop", TipoPainel = "Monocristalino", DataInstalacao = DateTime.Now },
                new Painel { Id = 2, IdCliente = 2, Nome = "Painel Solar B", Potencia = 3, Localizacao = "Ground", TipoPainel = "Policristalino", DataInstalacao = DateTime.Now }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(paineis);

            // Act
            var result = await _painelService.GetAllPaineisAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetPainelByIdAsync_ReturnsPainel_WhenPainelExists()
        {
            // Arrange
            var painel = new Painel { Id = 1, IdCliente = 1, Nome = "Painel Solar A", Potencia = 5, Localizacao = "Rooftop", TipoPainel = "Monocristalino", DataInstalacao = DateTime.Now };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(painel);

            // Act
            var result = await _painelService.GetPainelByIdAsync(1);

            // Assert
            Assert.Equal(painel, result);
        }

        [Fact]
        public async Task CreatePainelAsync_AddsPainel()
        {
            // Arrange
            var painel = new Painel { Id = 1, IdCliente = 1, Nome = "Painel Solar A", Potencia = 5, Localizacao = "Rooftop", TipoPainel = "Monocristalino", DataInstalacao = DateTime.Now };

            // Act
            await _painelService.CreatePainelAsync(painel);

            // Assert
            _mockRepository.Verify(repo => repo.Add(painel), Times.Once);
        }

        [Fact]
        public async Task UpdatePainelAsync_UpdatesPainel()
        {
            // Arrange
            var painel = new Painel { Id = 1, IdCliente = 1, Nome = "Painel Solar A", Potencia = 5, Localizacao = "Updated Location", TipoPainel = "Monocristalino", DataInstalacao = DateTime.Now };

            // Act
            await _painelService.UpdatePainelAsync(painel);

            // Assert
            _mockRepository.Verify(repo => repo.Update(painel), Times.Once);
        }

        [Fact]
        public async Task DeletePainelAsync_DeletesPainel_WhenPainelExists()
        {
            // Arrange
            var painel = new Painel { Id = 1, IdCliente = 1, Nome = "Painel Solar A", Potencia = 5, Localizacao = "Rooftop", TipoPainel = "Monocristalino", DataInstalacao = DateTime.Now };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(painel);

            // Act
            await _painelService.DeletePainelAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(painel), Times.Once);
        }

        [Fact]
        public async Task DeletePainelAsync_DoesNotDelete_WhenPainelDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Painel)null);

            // Act
            await _painelService.DeletePainelAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(It.IsAny<Painel>()), Times.Never);
        }
    }
}
