
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Service;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieDbConnection>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("MovieApplication"));
});

builder.Services.AddScoped<IMoviesRepositoryAsync, MoviesRepositoryAsync>();
builder.Services.AddScoped<IMoviesServiceAsync, MoviesServiceAsync>();
builder.Services.AddScoped<IGenresRepositoryAsync, GenresRepositoryAsync>();
builder.Services.AddScoped<IGenresServiceAsync, GenresServiceAsync>();
builder.Services.AddScoped<IUsersRepositoryAsync, UsersRepositoryAsync>();
builder.Services.AddScoped<IUsersServiceAsync, UsersServiceAsync>(); 
builder.Services.AddScoped<IMovieGenresRepositoryAsync, MovieGenresRepositoryAsync>();
builder.Services.AddScoped<IMovieGenresServiceAsync, MovieGenresServiceAsync>();
builder.Services.AddScoped<IMovieCastsRepositoryAsync, MovieCastsRepositoryAsync>();
builder.Services.AddScoped<IMovieCastsServiceAsync, MovieCastsServiceAsync>();
builder.Services.AddScoped<ICastsRepositoryAsync, CastsRepositoryAsync>();
builder.Services.AddScoped<ICastsServiceAsync, CastsServiceAsync>();


//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Log/Movie.txt").CreateLogger();
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Log/Movie.txt", rollingInterval:RollingInterval.Day).CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The function starting with "use" is middleware.
    
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
