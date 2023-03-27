using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain
{
	public interface IUnitOfWork
	{
		bool Commit();
		void Dispose();
		void DetachAllEntities();
	}
}
