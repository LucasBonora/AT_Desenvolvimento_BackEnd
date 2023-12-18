using BonosCarrosWeb.Data;
using BonosCarrosWeb.Services;
using BonosCarrosWeb.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => {
	options.Conventions.AuthorizeFolder("/Marcas");
	options.Conventions.AuthorizeFolder("/Designers");
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<ICarroService, CarroService>();
builder.Services.AddDbContext<CarrosDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.
		SignIn.RequireConfirmedAccount = true)
		.AddEntityFrameworkStores<CarrosDbContext>();

builder.Services.Configure<IdentityOptions>(options => {
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 3;
	options.Lockout.MaxFailedAccessAttempts = 30;
	options.Lockout.AllowedForNewUsers = true;
	options.User.RequireUniqueEmail = true;
});

var app = builder.Build();


var context = new CarrosDbContext();
context.Database.Migrate(); 


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
