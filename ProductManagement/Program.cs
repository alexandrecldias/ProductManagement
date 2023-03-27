using Product.Domain;
using Product.Domain.ProductRoot.Repository;
using Product.Domain.ProductRoot.Service;
using Product.Domain.ProductRoot.Service.Interfaces;
using Product.Infra.Data.SqlServer.Context;
using Product.Infra.Data.SqlServer.Repository;
using Product.Infra.Data.SqlServer.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using AutoMapper;
using Product.Api.AutoMapper;
using Product.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=teste;Integrated Security=True");
builder.Services.AddDbContext<ServiceContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMapper();

builder.Services.AddControllers(options =>
{
	options.RespectBrowserAcceptHeader = true;
});

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNamingPolicy = null;
	});

//var config = new MapperConfiguration(cfg =>
//{
//	cfg.AddProfile(new DomainToViewModelMappingProfile());
//	cfg.AddProfile(new ViewModelToDomainMappingProfile());
//});

//mapper = config.CreateMapper();

//builder.Services.AddSingleton(mapper);


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