using Product.Domain.ProductRoot.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Product.Domain.ProductRoot.Repository
{
	public interface IProdutoRepository : IBaseRepository<Entity.Product>
	{
		FiltroGenericoDtoBase<Entity.Product> Filtrar(FiltroGenericoDtoBase<Entity.Product> filtro);
	}
}
