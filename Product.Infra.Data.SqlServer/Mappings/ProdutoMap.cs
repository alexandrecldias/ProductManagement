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
	public class ProdutoMap : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.ToTable("produto");

			builder.HasKey(x => x.Id);

			builder.Property(p => p.Id)
				.HasColumnName("id")
				.IsRequired(true);

			builder.Property(p => p.descricaoProduto)
				.HasColumnName("descricaoProduto")
				.IsRequired(true);

			builder.Property(p => p.ativo)
				.HasColumnName("ativo")
				.IsRequired(true);
		
			builder.Property(p => p.dataFabricao)
				.HasColumnName("dataFabricao")
				.IsRequired(true);

			builder.Property(p => p.dataValidade)
				.HasColumnName("dataValidade")
				.IsRequired(true);

			builder.Property(p => p.DtAlteracao)
				.HasColumnName("DtAlteracao")
				.IsRequired(true);

			builder.Property(p => p.LgUsuario)
				.HasColumnName("LgUsuario")
				.IsRequired(true);

		}
	}
}
