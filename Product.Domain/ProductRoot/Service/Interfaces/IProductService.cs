using Product.Domain.ProductRoot.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.ProductRoot.Service.Interfaces
{
	public interface IProductService
	{
		IEnumerable<Produto> ObterTodos();
	}
}
