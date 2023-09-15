using System;

namespace SecuestroBienes.Models.Entities
{
    public class SecuestroBiene
    {
        public string NoResolucionEmbargo { get; set; }
        public DateTime FechaResolucionEmbargo { get; set; }

        public string TipoBien { get; set; }

        public string Entidad { get; set; }

        public string NoProcesoGc { get; set; }

        public string TipoObligacion { get; set; }

        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string NombreCiudadano { get; set; }

        public decimal ValorNominal { get; set; }

        public decimal Interes { get; set; }

        public decimal Saldo { get; set; }

        public decimal Total { get; set; }
        public DateTime FechaCalculada { get; set; }

        public bool Diligencia { get; set; }
    }
}