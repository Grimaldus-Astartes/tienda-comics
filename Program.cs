using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tienda_comics;
using tienda_comics.Data_Context;
using tienda_comics.Services;
using tienda_comics.Services.Implementation;

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

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICatalogoService, CatalogoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
