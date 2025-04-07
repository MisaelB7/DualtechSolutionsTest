using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApiDualtechServices.Models
{
    [PrimaryKey("ClienteId")]
    public class Event
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }="";
        public string Identidad { get; set; }= "";  

    }
}
