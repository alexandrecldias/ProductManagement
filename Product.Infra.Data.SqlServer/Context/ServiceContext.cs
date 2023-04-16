using Microsoft.EntityFrameworkCore;
using Product.Domain.ProductRoot.Entity;
using Product.Infra.Data.SqlServer.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infra.Data.SqlServer.Context
{
	public class ServiceContext : DbContext
	{
		public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
		{
		}
		public DbSet<Domain.ProductRoot.Entity.Product> Produto { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProdutoMap());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.
				UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=teste;Integrated Security=True");
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			var result = base.SaveChanges(acceptAllChangesOnSuccess);
			return result;
		}

		public void DetachAllEntities()
		{
			var changedEntriesCopy = ChangeTracker.Entries();

			foreach (var entry in changedEntriesCopy)
				entry.State = EntityState.Detached;
		}



	}
}
