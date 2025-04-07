using Microsoft.EntityFrameworkCore;
using ApiDualtechServices.Models;

namespace ApiDualtechServices.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public required DbSet<Event> Cliente { get; set; }
    }
}
