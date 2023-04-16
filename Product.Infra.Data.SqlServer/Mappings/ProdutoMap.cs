using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.ProductRoot.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infra.Data.SqlServer.Mappings
{
	public class ProdutoMap : IEntityTypeConfiguration<Domain.ProductRoot.Entity.Product>
	{
		public void Configure(EntityTypeBuilder<Domain.ProductRoot.Entity.Product> builder)
		{
			builder.ToTable("produto");

			builder.HasKey(x => x.Id);

			builder.Property(p => p.Id)
				.HasColumnName("id")
				.IsRequired(true);

			builder.Property(p => p.descriptionProduct)
				.HasColumnName("descricaoProduto")
				.IsRequired(true);

			builder.Property(p => p.active)
				.HasColumnName("ativo")
				.IsRequired(true);
		
			builder.Property(p => p.manufacturingDate)
				.HasColumnName("dataFabricao")
				.IsRequired(true);

			builder.Property(p => p.validadeDate)
				.HasColumnName("dataValidade")
				.IsRequired(true);

			builder.Property(p => p.DtAlteracao)
				.HasColumnName("DtAlteracao")
				.IsRequired(true);

			builder.Property(p => p.LgUsuario)
				.HasColumnName("LgUsuario")
				.IsRequired(true);

			builder.Property(p => p.descriptionSupplier)
				.HasColumnName("descricaoFornecedor")
				.IsRequired(true);

			builder.Property(p => p.cnpj)
				.HasColumnName("cnpjFornecedor")
				.IsRequired(true);
		}
	}
}
