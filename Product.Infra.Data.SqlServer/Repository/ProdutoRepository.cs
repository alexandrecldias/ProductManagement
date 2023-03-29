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

			ContarTotalEPaginar(filtro, query);

			return filtro;
		}

		private void ContarTotalEPaginar(FiltroGenericoDtoBase<Produto> filtro, IQueryable<Produto> query)
		{

		}


		private IQueryable<Produto> FiltrarCampoEspecifico(FiltroGenericoDtoBase<Produto> filtro, IQueryable<Produto> query)
		{
			if (!string.IsNullOrEmpty(filtro.ValorParaFiltrar) && filtro.ValorParaFiltrar.Any())
			{
				if (filtro.TipoCampoFiltro == "string")
				{
					List<string> valorParaFiltrarList = new List<string>();

					var valorParaFiltrarSplit = filtro.ValorParaFiltrar.Split(',');
					for (int i = 0; i < valorParaFiltrarSplit.Length; i++)
					{
						valorParaFiltrarList.Add(valorParaFiltrarSplit[i]);
					}

					query = query.Where(x => valorParaFiltrarList.Any(y => y == x.GetType().GetProperty(filtro.CampoFiltro).GetValue(x).ToString()));
				}
				else if (filtro.TipoCampoFiltro == "int")
				{
					List<int> valorParaFiltrarList = new List<int>();

					var valorParaFiltrarSplit = filtro.ValorParaFiltrar.Split(',');
					for (int i = 0; i < valorParaFiltrarSplit.Length; i++)
					{
						valorParaFiltrarList.Add(int.Parse(valorParaFiltrarSplit[i]));
					}

					query = query.Where(x => valorParaFiltrarList.Any(y => y == Convert.ToInt32(x.GetType().GetProperty(filtro.CampoFiltro).GetValue(x))));
				}
			}

			return query;
		}
	}
}
