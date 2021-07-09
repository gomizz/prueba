using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.ComponentModel.DataAnnotations;

namespace howarts1.Models
{
    public class Usuario
    {
        [Range(0, 999)]
        public int Id {get; set;}
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", 
         ErrorMessage = "Sólo se permite 20 caracrteres y sólo pueden ser letras.")] 
        public string? Nombre { get; set; } 
         [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", 
         ErrorMessage = "Sólo se permite 20 caracrteres y sólo pueden ser letras.")]     
        public string? Apellido { get; set; }
        [Range(4000000, 9999999999)]
        public int identificacion { get; set; }
        [Range(18, 99)]
        public int edad {get; set;}
        public string? casa {get;set;}
    }
}