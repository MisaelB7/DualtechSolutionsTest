using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiDualtechServices.Models.DualtechDB;


public partial class ResponseModel
{
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("data")]
    public dynamic? Data { get; set; }

    [JsonProperty("errors")]
    public List<string> Errors { get; set; }

    public ResponseModel()
    {
        this.Success = false;
        this.Message = null;
        this.Data = null;
        this.Errors = [];
        
    }
}
