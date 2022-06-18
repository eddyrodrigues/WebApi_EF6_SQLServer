using Blog.Repository.Context;
using Blog.Repository.Contracts;
using Blog.Repository.Repositories;
using Blog.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.LoadConfiguration();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc().ConfigureApiBehaviorOptions(t => { t.SuppressModelStateInvalidFilter = true; });
builder.Services.AddDbContext<BlogDbContext>(opt => {
  opt.UseSqlServer(SystemConfiguration.ConnectionStringSystem, b => b.MigrationsAssembly("Blog"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();
// builder.Services.AddScoped<IBaseRepository, CategoryRepository>();

var app = builder.Build();

// app.Configuration.LoadConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();




public static class SystemConfiguration
{
  public static string ConnectionStringSystem { get; set; } = "";
  public static IConfiguration LoadConfiguration (this IConfiguration configuration)
  {
    ConnectionStringSystem = configuration.GetConnectionString("BlogDBCS");
    return configuration;
  }
}

