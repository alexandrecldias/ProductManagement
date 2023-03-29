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

		[HttpGet(Name = "List")]
		public ActionResult<IEnumerable<ProductVM>> Get()
		{
			var allProducts = _productService.ObterTodos();
			var productVM = _mapper.Map<IEnumerable<ProductVM>>(allProducts);
			return Ok(JsonConvert.SerializeObject(productVM));
		}

		[HttpGet("ObterPorId")]
		public ActionResult<IEnumerable<ProductVM>> Get(int idProduto)
		{
			var product = _productService.ObterPorId(idProduto);
			var productVM = _mapper.Map<ProductVM>(product);
			return Ok(JsonConvert.SerializeObject(productVM));
		}

		[HttpPost("persistir-produto")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public ActionResult PersistirProduto([FromBody] List<ProdutoDto> produto)
		{
			try
			{
				var result = _productService.Persistir(produto);
				return StatusCode(result.StatusCode, result.Mensagem);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost("cancelar-produto")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public ActionResult CancelarProduto([FromBody] int idProduto)
		{
			try
			{
				var result = _productService.CancelarProduto(idProduto);
				return StatusCode(result.StatusCode, result.Mensagem);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	

	}
}
