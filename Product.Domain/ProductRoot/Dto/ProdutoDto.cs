using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.ProductRoot.Dto
{
	public class ProdutoDto
	{
		private string descricaoProduto;
		private bool ativo;
		private DateTime dataFabricao;
		private DateTime dataValidade;
		private string descricaoFornecedor;
		private string cnpj;
		private int id;

		public string DescricaoProduto { get => descricaoProduto; set => descricaoProduto = value; }
		public bool Ativo { get => ativo; set => ativo = value; }
		public DateTime DataFabricao { get => dataFabricao; set => dataFabricao = value; }
		public DateTime DataValidade { get => dataValidade; set => dataValidade = value; }
		public string DescricaoFornecedor { get => descricaoFornecedor; set => descricaoFornecedor = value; }
		public string Cnpj { get => cnpj; set => cnpj = value; }
		public int Id { get => id; set => id = value; }
	}
}
