namespace PruebaTecnica.WebApi.Business.Managers.Authorization.Models
{
    public class DtoLogin
    {
        public string NombreDeUsuario { get; set; }
        public string Contraseña { get; set; }

        public int IdUsuario { get; set; } = 0;
        public string NombreCompleto { get; set; } = string.Empty;
        public bool EsSesionvalida { get; set; } = false;
    }
}
