using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace WebApiContabilidad.Entities
{
    public class Tienda 
    {
        [Key]
        public int tie_id { get; set; }

        [Required] 
        public string tie_nombre { get; set; }
        [Required] 
        public int tie_est_id { get; set; }
     
        public string? tie_comentario { get; set; }
    }
}