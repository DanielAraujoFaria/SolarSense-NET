using SolarSense.Database.Models;
using SolarSense.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarSense.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return Task.Run(() => _usuarioRepository.GetAll());
        }

        public Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return Task.Run(() => _usuarioRepository.GetById(id));
        }

        public Task<Usuario> CreateUsuariolAsync(Usuario usuario)
        {
            return Task.Run(() => {
                _usuarioRepository.Add(usuario);
                return usuario;
            });
        }

        public Task UpdateUsuarioAsync(Usuario usuario)
        {
            return Task.Run(() => _usuarioRepository.Update(usuario));
        }

        public Task DeleteUsuarioAsync(int id)
        {
            return Task.Run(() => {
                var usuario = _usuarioRepository.GetById(id);
                if (usuario != null)
                {
                    _usuarioRepository.Delete(usuario);
                }
            });
        }
    }
}
