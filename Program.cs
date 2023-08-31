using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tienda_comics;
using tienda_comics.Data_Context;
using tienda_comics.Services;
using tienda_comics.Services.Implementation;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Acoplar base de datos
builder.Services.AddDbContext<TiendaComics>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"))
        .EnableSensitiveDataLogging(true).UseLazyLoadingProxies();
    });
#endregion
#region Configurar Mapper
builder.Services.AddSingleton(provider =>
{
    return new MapperConfiguration(config =>
    {
        config.AddProfile<AutoMapperProfile>();
        config.ConstructServicesUsing(type => 
        ActivatorUtilities.GetServiceOrCreateInstance(provider, type));
    }).CreateMapper();
});
#endregion

#region Especificar Corps
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
#endregion

builder.Services.AddControllersWithViews();

#region registerServices
builder.Services.AddScoped<ICatalogoService, CatalogoService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
