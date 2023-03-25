using Microsoft.AspNetCore.Mvc;
using ProductManagement;

namespace Product.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		[HttpGet(Name = "List")]
		public List<int> Get()
		{
			List<int> list = new List<int>();
			list.Add(1);

			return list;
		}
	}
}
