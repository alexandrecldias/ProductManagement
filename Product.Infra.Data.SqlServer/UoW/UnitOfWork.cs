using Product.Domain;
using Product.Infra.Data.SqlServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infra.Data.SqlServer.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ServiceContext _context;

		public UnitOfWork(ServiceContext context)
		{
			_context = context;
		}

		public bool Commit()
		{
			var changes = _context.SaveChanges() > 0;
			//_context.DetachAllEntities();

			return changes;
		}

		public void DetachAllEntities()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			_context.Dispose();
		}

	}
}
