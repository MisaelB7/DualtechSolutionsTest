using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiDualtechServices.Models.DualtechDB;


public partial class ProductosDTO
{
    public long? ProductoId { get; set; }

    [StringLength(250)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    public long Existencia { get; set; }

    public ProductosDTO()
    {
        this.ProductoId = 0;
        this.Nombre = string.Empty;
        this.Descripcion = string.Empty;
        this.Precio = 0;
        this.Existencia = 0;

    }
}
