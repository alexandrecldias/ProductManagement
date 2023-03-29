using AutoMapper;
using Product.Api.AutoMapper;

namespace Product.Api.Configuration
{
	public static class MapperInitialize
	{
		public static IMapper mapper;
		public static void AddMapper(this IServiceCollection services)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new DomainToViewModelMappingProfile());
				cfg.AddProfile(new ViewModelToDomainMappingProfile());
				cfg.AddProfile(new DtoToDomainMappingProfile());
			});

			mapper = config.CreateMapper();

			services.AddSingleton(mapper);
		}
	}
}
