using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiDualtechServices.Models.DualtechDB;

[Table("Orden")]
public partial class Orden
{
    [Key]
    public long OrdenId { get; set; }

    public long ClienteId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Impuesto { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Ordens")]
    public virtual Cliente Cliente { get; set; } = null!;

    [InverseProperty("Orden")]
    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();
}
