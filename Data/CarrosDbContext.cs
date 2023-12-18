using BonosCarrosWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BonosCarrosWeb.Data;

public class CarrosDbContext : IdentityDbContext
{
    public  DbSet<Carro> Carro { get; set; }
	public DbSet<Marca> Marca { get; set; }
    public DbSet<Designer> Designer { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		string conn = config.GetConnectionString("Conn");

		optionsBuilder.UseSqlServer(conn);
	}
}
