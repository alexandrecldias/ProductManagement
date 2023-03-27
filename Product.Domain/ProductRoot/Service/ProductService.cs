using Product.Domain.ProductRoot.Entity;
using Product.Domain.ProductRoot.Repository;
using Product.Domain.ProductRoot.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.ProductRoot.Service
{
	public class ProductService : IProductService 
	{
		private readonly IProdutoRepository _produtoRepository;
		public ProductService(
			IProdutoRepository produtoRepository) { 
			_produtoRepository = produtoRepository;
		}

		public IEnumerable<Produto> ObterTodos()
		{
			var todosProdutos = _produtoRepository.BuscarTodos();

			return todosProdutos;
		}

	}
}
