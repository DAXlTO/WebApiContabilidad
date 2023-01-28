using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace WebApiContabilidad.Entities
{
    public class Estado 
    {
        [Key]
        public int est_id { get; set; }

        [Required] 
        public string est_nombre { get; set; }
    }
}


