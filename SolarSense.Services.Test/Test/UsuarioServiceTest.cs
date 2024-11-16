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
    public class UsuarioServiceTest
    {
        private readonly Mock<IRepository<Usuario>> _mockRepository;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTest()
        {
            _mockRepository = new Mock<IRepository<Usuario>>();
            _usuarioService = new UsuarioService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllUsuariosAsync_ReturnsAllUsuarios()
        {
            // Arrange
            var usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nome = "Usuario 1", Email = "usuario1@email.com", Senha = "senha123", Tipo = "ADMIN", Notificacoes = "SIM", DataCadastro = DateTime.Now },
                new Usuario { Id = 2, Nome = "Usuario 2", Email = "usuario2@email.com", Senha = "senha456", Tipo = "CLIENTE", Notificacoes = "NAO", DataCadastro = DateTime.Now }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(usuarios);

            // Act
            var result = await _usuarioService.GetAllUsuariosAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetUsuarioByIdAsync_ReturnsUsuario_WhenUsuarioExists()
        {
            // Arrange
            var usuario = new Usuario { Id = 1, Nome = "Usuario 1", Email = "usuario1@email.com", Senha = "senha123", Tipo = "ADMIN", Notificacoes = "SIM", DataCadastro = DateTime.Now };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(usuario);

            // Act
            var result = await _usuarioService.GetUsuarioByIdAsync(1);

            // Assert
            Assert.Equal(usuario, result);
        }

        [Fact]
        public async Task CreateUsuarioAsync_AddsUsuario()
        {
            // Arrange
            var usuario = new Usuario { Id = 1, Nome = "Usuario 1", Email = "usuario1@email.com", Senha = "senha123", Tipo = "ADMIN", Notificacoes = "SIM", DataCadastro = DateTime.Now };

            // Act
            await _usuarioService.CreateUsuariolAsync(usuario);

            // Assert
            _mockRepository.Verify(repo => repo.Add(usuario), Times.Once);
        }

        [Fact]
        public async Task UpdateUsuarioAsync_UpdatesUsuario()
        {
            // Arrange
            var usuario = new Usuario { Id = 1, Nome = "Usuario Atualizado", Email = "usuario@atualizado.com", Senha = "novaSenha123", Tipo = "ADMIN", Notificacoes = "NAO", DataCadastro = DateTime.Now };

            // Act
            await _usuarioService.UpdateUsuarioAsync(usuario);

            // Assert
            _mockRepository.Verify(repo => repo.Update(usuario), Times.Once);
        }

        [Fact]
        public async Task DeleteUsuarioAsync_DeletesUsuario_WhenUsuarioExists()
        {
            // Arrange
            var usuario = new Usuario { Id = 1, Nome = "Usuario 1", Email = "usuario1@email.com", Senha = "senha123", Tipo = "ADMIN", Notificacoes = "SIM", DataCadastro = DateTime.Now };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(usuario);

            // Act
            await _usuarioService.DeleteUsuarioAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(usuario), Times.Once);
        }

        [Fact]
        public async Task DeleteUsuarioAsync_DoesNotDelete_WhenUsuarioDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Usuario)null);

            // Act
            await _usuarioService.DeleteUsuarioAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(It.IsAny<Usuario>()), Times.Never);
        }
    }
}
