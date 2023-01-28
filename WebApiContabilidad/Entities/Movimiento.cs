using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace WebApiContabilidad.Entities
{
    public class Movimiento 
    {
        [Key]
        public int mov_id { get; set; }

        [Required] 
        public DateTime mov_fec { get; set; }
        [Required] 
        public decimal mov_cantidad { get; set; }
        [Required] 
        public int mov_est_id { get; set; }
        
        public int? mov_tie_id { get; set; }
        
        public int? mov_mar_id { get; set; }
        [Required] 
        public int mov_cat_id { get; set; }
        [Required] 
        public int mov_tmo_id { get; set; }
        public string? mov_comentario { get; set; }
        
        public int mov_usu_id { get; set; }
    }

    public class MovimientoDetallado
    {
        public int mov_id { get; set; }
        public DateTime mov_fec { get; set; }
        public decimal mov_cantidad { get; set; }
        public int mov_est_id { get; set; }
        public string? mov_tie_id { get; set; }
        public string? mov_mar_id { get; set; }
        public string mov_cat_id { get; set; }
        public string mov_tmo_id { get; set; }
    }
}