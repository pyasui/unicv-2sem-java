using Microsoft.EntityFrameworkCore;
using Unicv.Eventos.Api.Data.Entities;

namespace Unicv.Eventos.Api.Data.Context;

public class DataContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<PaymentMethod> DbPaymentMethods { get; set; }
    public DbSet<State> DbStates { get; set; }
}
