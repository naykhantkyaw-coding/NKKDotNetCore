using Microsoft.EntityFrameworkCore;
using NKKDotNetCore.RestApiWithNLayer.EFAppDbContextModels;
using NKKDotNetCore.RestApiWithNLayer.Features.Blog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Adding CustomSetting

builder.Configuration.AddJsonFile("customsetting.json", true,true);

#endregion

#region AddDbContext

//var testing = builder.Configuration.GetSection("CustomSetting:ConnectionStrings:DbConnection").Value;
builder.Services.AddDbContext<AppDbContext>(
opt => opt.UseSqlServer(builder.Configuration.GetSection("CustomSetting:ConnectionStrings:DbConnection").Value),
ServiceLifetime.Transient,
ServiceLifetime.Transient
);

#endregion

#region Add DI

builder.Services.AddScoped<BL_Blog>();
builder.Services.AddScoped<DA_Blog>();

#endregion

var app = builder.Build();

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
