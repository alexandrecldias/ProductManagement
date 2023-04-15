using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Product.Api.ViewModels;
using Product.Domain.ProductRoot.Dto;
using Product.Domain.ProductRoot.Entity;
using Product.Domain.ProductRoot.Service.Interfaces;
using Utils;

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

		[HttpGet("~/ListAll")]
		public ActionResult<IEnumerable<ProductVM>> Get()
		{
			var allProducts = _productService.ObterTodos();
			var productVM = _mapper.Map<IEnumerable<ProductVM>>(allProducts);
			return Ok(JsonConvert.SerializeObject(productVM));
		}

		[HttpGet("~/ListPagination")]
		public ActionResult<IEnumerable<ProductVM>> Get([FromQuery] int skip,
		[FromQuery] int take)
		{
			var allProducts = _productService.ObterTodos().Skip(skip).Take(take);
			var productVM = _mapper.Map<IEnumerable<ProductVM>>(allProducts);
			return Ok(JsonConvert.SerializeObject(productVM));
		}

		[HttpGet("GetById")]
		public ActionResult<IEnumerable<ProductVM>> Get(int idProduto)
		{
			var product = _productService.ObterPorId(idProduto);
			var productVM = _mapper.Map<ProductVM>(product);
			return Ok(JsonConvert.SerializeObject(productVM));
		}

		[HttpPost("persist-product")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public ActionResult PersistirProduto([FromBody] List<ProdutoDto> produto)
		{
			try
			{
				var result = _productService.Persist(produto);
				return StatusCode(result.StatusCode, result.Mensagem);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost("cancel-product")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public ActionResult CancelProduct([FromBody] int idProduto)
		{
			try
			{
				var result = _productService.CancelProduct(idProduto);
				return StatusCode(result.StatusCode, result.Mensagem);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	

	}
}
