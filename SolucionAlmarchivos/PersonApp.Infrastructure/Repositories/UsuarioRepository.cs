using PersonApp.Domain.DTO;
using PersonApp.Application.Interfaces;


namespace PersonApp.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Task<RespuestaDto> IUsuarioRepository.Actualizar(UsuarioDto objUsuario)
        {
            throw new NotImplementedException();
        }

        Task<RespuestaDto> IUsuarioRepository.Borrar(int id)
        {
            throw new NotImplementedException();
        }

        Task<RespuestaDto> IUsuarioRepository.Insertar(UsuarioDto newUsuario)
        {
            throw new NotImplementedException();
        }

        Task<List<UsuarioDto>> IUsuarioRepository.Listar()
        {
            throw new NotImplementedException();
        }

        Task<RespuestaDto> IUsuarioRepository.Login(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        Task<UsuarioDto> IUsuarioRepository.ObtenerXId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
