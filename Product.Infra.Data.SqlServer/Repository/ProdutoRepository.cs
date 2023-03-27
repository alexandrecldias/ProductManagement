using Product.Domain.ProductRoot.Entity;
using Product.Domain.ProductRoot.Repository;
using Product.Infra.Data.SqlServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infra.Data.SqlServer.Repository
{
	public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
	{
		public ProdutoRepository(ServiceContext context) : base(context)
		{
		}

	}
}
