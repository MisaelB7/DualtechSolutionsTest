using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiDualtechServices.Models.DualtechDB;


public partial class ClientesDTO
{
    public long? ClienteId { get; set; }

    [StringLength(250)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string Identidad { get; set; } = null!;

    public ClientesDTO()
    {
        this.ClienteId = 0;
        this.Nombre = string.Empty;
        this.Identidad = string.Empty;
        
    }
}
