namespace PersonApp.Domain.DTO
{
    public class RespuestaDto
    {
        public bool EsValido { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public dynamic Respuesta { get; set; } = string.Empty;
    }
}
