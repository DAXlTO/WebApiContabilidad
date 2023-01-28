using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace WebApiContabilidad.Entities
{
    public class Categoria 
    {
        [Key]
        public int cat_id { get; set; }

        [Required] 
        public string cat_nombre { get; set; }
        [Required] 
        public int cat_est_id { get; set; }
     
        public string? cat_comentario { get; set; }
    }
    
    public class CategoriaEstado
    {
        public int cat_id { get; set; }
        public int cat_est_id { get; set; }
     

    }
}