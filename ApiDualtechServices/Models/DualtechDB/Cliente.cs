using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiDualtechServices.Models.DualtechDB;

[Table("Cliente")]
public partial class Cliente
{
    [Key]
    public long ClienteId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string Identidad { get; set; } = null!;

    [InverseProperty("Cliente")]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
