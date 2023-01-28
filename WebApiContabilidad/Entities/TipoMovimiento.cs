using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace WebApiContabilidad.Entities
{
    public class TipoMovimiento 
    {
        [Key]
        public int tmo_id { get; set; }

        [Required] 
        public string tmo_nombre { get; set; }
        
        [Required]
        public int tmo_est_id { get; set; }

    }
}