using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiDualtechServices.Models.DualtechDB;


public partial class OrdenDTO
{
    public long? OrdenId { get; set; }

    public long ClienteId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Impuesto { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }

    public List<DetalleOrdenDTO> Detalle { get; set; } = new List<DetalleOrdenDTO>();

    public OrdenDTO()
    {
        this.OrdenId = 0;
        this.ClienteId = 0;
        this.Detalle = new List<DetalleOrdenDTO>();
        this.Impuesto = 0;
        this.Subtotal = 0;
        this.Total = 0;

    }
}
