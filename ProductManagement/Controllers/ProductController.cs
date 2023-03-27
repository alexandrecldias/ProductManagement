using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Product.Api.ViewModels;
using Product.Domain.ProductRoot.Entity;
using Product.Domain.ProductRoot.Service.Interfaces;

namespace Product.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		public readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet(Name = "List")]
		public ActionResult<IEnumerable<ProductVM>> Get()
		{
			var allProducts = _productService.ObterTodos();
			var productVM = _mapper.Map<IEnumerable<ProductVM>>(allProducts);
			return Ok(JsonConvert.SerializeObject(productVM));
		}
	}
}
