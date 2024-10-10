using Microsoft.EntityFrameworkCore;
using PersonApp.Application.Interfaces;
using PersonApp.Infrastructure.Context;
using PersonApp.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IPersonaRepository, PersonaRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddDbContext<RegistrosDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"))
);
builder.Services.AddSession(options => {
	options.IdleTimeout = TimeSpan.FromMinutes(20); // Tiempo de expiración   
    options.IOTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.Name = ".PersonApp.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Path = "/";
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
