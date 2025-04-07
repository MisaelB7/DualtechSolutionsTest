using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiDualtechServices.Models.DualtechDB;

[Table("DetalleOrden")]
public partial class DetalleOrden
{
    [Key]
    public long DetalleOrdenId { get; set; }

    public long OrdenId { get; set; }

    public long ProductoId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Impuesto { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }

    [ForeignKey("OrdenId")]
    [InverseProperty("DetalleOrdens")]
    public virtual Orden Orden { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("DetalleOrdens")]
    public virtual Producto Producto { get; set; } = null!;
}
