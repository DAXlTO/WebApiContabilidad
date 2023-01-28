using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace WebApiContabilidad.Entities
{
    public class Marca 
    {
        [Key]
        public int mar_id { get; set; }

        [Required] 
        public string mar_nombre { get; set; }
        [Required] 
        public int mar_est_id { get; set; }
     
        public string mar_comentario { get; set; }
    }
}