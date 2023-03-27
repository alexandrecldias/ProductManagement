using Microsoft.Extensions.DependencyInjection;
using Product.Domain;
using Product.Domain.ProductRoot.Repository;
using Product.Infra.Data.SqlServer.Repository;
using Product.Infra.Data.SqlServer.UoW;

namespace Product.Infra.CrossCutting.IoC
{
	public class Injector
	{
		public static IServiceProvider ServiceProvider { get; set; }

		public static void RegisterServices(IServiceCollection services)
		{

			services.AddTransient<IUnitOfWork, UnitOfWork>();

			//Infra Data
			services.AddScoped<IProdutoRepository, ProdutoRepository>();


			ServiceProvider = services.BuildServiceProvider();

		}
	}
}