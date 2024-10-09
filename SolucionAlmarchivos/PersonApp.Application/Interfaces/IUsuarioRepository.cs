using PersonApp.Domain.DTO;

namespace PersonApp.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<RespuestaDto> Login(LoginDto dto);
        Task<List<UsuarioDto>> Listar();
        Task<UsuarioDto> ObtenerXId(int id);
        Task<RespuestaDto> Insertar(UsuarioDto newUsuario);
        Task<RespuestaDto> Actualizar(UsuarioDto objUsuario);
        Task<RespuestaDto> Borrar(int id);
    }
}
