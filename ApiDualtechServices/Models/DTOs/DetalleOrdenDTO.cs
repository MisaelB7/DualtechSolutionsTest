using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiDualtechServices.Models.DualtechDB;


public partial class DetalleOrdenDTO
{
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

    public DetalleOrdenDTO()
    {
        this.DetalleOrdenId = 0;
        this.OrdenId = 0;
        this.ProductoId = 0;
        this.Cantidad = 0;
        this.Impuesto = 0;
        this.Subtotal = 0;
        this.Total = 0;

    }
}
