using AutoMapper;
using Product.Api.ViewModels;
using Product.Domain.ProductRoot.Entity;

namespace Product.Api.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			CreateMap<Produto, ProductVM>();
		}
	}
}