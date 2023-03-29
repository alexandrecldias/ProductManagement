using Product.Api.ViewModels;
using Product.Domain.ProductRoot.Dto;
using Product.Domain.ProductRoot.Entity;
using AutoMapper;

namespace Product.Api.AutoMapper
{
	public class DtoToDomainMappingProfile : Profile
	{
		public DtoToDomainMappingProfile()
		{
			CreateMap<Produto, ProdutoDto>();
			CreateMap<ProdutoDto, Produto>();
		}
	}
}
