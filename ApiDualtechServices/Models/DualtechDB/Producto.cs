using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiDualtechServices.Models.DualtechDB;

[Table("Producto")]
public partial class Producto
{
    [Key]
    public long ProductoId { get; set; }

    [StringLength(250)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    public long Existencia { get; set; }

    [InverseProperty("Producto")]
    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();
}
