using PruebaTecnica.WebApi.DataAccess.Core.Model;

namespace PruebaTecnica.WebApi.DataAccess.Models
{
    public class Cliente : BaseModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public System.DateTime FechaDeNacimiento { get; set; }
        public int IdGenero { get; set; }
        public int IdTipoDeIdentificacion { get; set; }
        public string NumeroDeIdentificacion { get; set; }
        public bool Maneja { get; set; }
        public bool UsaLentes { get; set; }
        public bool TieneDiabetes { get; set; }
        public bool TieneOtrasEnfermedades { get; set; }
        public string OtrasEnfermedades { get; set; }
        public bool ActivoActualmente { get; set; }
    }
}
