using Product.Domain.ProductRoot.Dto;
using Product.Domain.ProductRoot.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Product.Domain.ProductRoot.Service.Interfaces
{
	public interface IProductService
	{
		IEnumerable<Entity.Product> ObterTodos();
		Entity.Product ObterPorId(int idProduto);
		RetornoDto Persist(List<ProductDto> produtoDto);
		RetornoDto CancelProduct(int idProduto);
	}
}
