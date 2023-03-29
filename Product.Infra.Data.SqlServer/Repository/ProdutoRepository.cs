using Microsoft.EntityFrameworkCore;
using Product.Domain.ProductRoot.Entity;
using Product.Domain.ProductRoot.Repository;
using Product.Infra.Data.SqlServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Product.Infra.Data.SqlServer.Repository
{
	public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
	{
		public ProdutoRepository(ServiceContext context) : base(context)
		{
		}

		public FiltroGenericoDtoBase<Produto> Filtrar(FiltroGenericoDtoBase<Produto> filtro)
		{
			var query = DbSet.AsQueryable().AsNoTracking();

			return filtro;
		}
	}
}
