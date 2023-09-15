using System;

namespace SecuestroBienes.Models.Entities
{
    public class BandejaTrabajo
    {
        public string TipoObligacion { get; set; }

        public string FkNumResolucionEmbargo { get; set; }

        public string EtapaMc { get; set; }

        public string NoProcesoGc { get; set; }

        public string NombreCiudadanoEmpresa { get; set; }

        public string TipoDocCiudadanoEmpresa { get; set; }

        public string NroDocCiudadanoEmpresa { get; set; }

        public DateTime FechaPreinscripcion { get; set; }

        public int Id { get; set; }
    }
}
