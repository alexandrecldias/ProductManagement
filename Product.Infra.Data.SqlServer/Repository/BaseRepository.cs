using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain;
using Product.Infra.Data.SqlServer.Context;
using Utils;

namespace Product.Infra.Data.SqlServer.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
	{
		protected DbSet<TEntity> DbSet;
		public readonly ServiceContext _context;

		public BaseRepository(ServiceContext context)
		{
			_context = context;
			DbSet = _context.Set<TEntity>();
		}

		public void Adicionar(TEntity entity)
		{
			entity.LgUsuario = "teste";
			entity.DtAlteracao = DateTime.Now;
			DbSet.Add(entity);
		}

		public TEntity BuscarPorId(int id)
		{
			return DbSet.Find(id);
		}

		public ICollection<TEntity> BuscarTodos()
		{
			return DbSet.ToList();
		}

		public ICollection<TEntity> BuscarTodosPaginado(FiltroGenericoDto<TEntity> filtro)
		{
			return DbSet.Skip(filtro.Pagina).Take(filtro.QuantidadePorPagina).ToList();
		}


		public ICollection<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public void Update(TEntity entity)
		{
			var entityDB = DbSet.Find(entity.Id);
			_context.Entry(entityDB).CurrentValues.SetValues(entity);
			entity.LgUsuario = "teste";
			entity.DtAlteracao = DateTime.Now;
			DbSet.Update(entityDB);
		}

		public void UpdateCompose(TEntity entity, object[] chaves)
		{
			throw new NotImplementedException();
		}

		public void AdicionarRange(List<TEntity> entities)
		{
			throw new NotImplementedException();
		}

		public void Remove(TEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
