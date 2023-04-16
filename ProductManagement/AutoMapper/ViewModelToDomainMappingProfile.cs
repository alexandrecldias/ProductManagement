using AutoMapper;
using Product.Api.ViewModels;
using Product.Domain.ProductRoot.Entity;

namespace Product.Api.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			CreateMap<ProductVM, Domain.ProductRoot.Entity.Product>();
		}
	}
}