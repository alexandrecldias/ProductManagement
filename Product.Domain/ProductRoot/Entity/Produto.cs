using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.ProductRoot.Entity
{
	public class Produto : EntityBase
	{
		public string descricaoProduto;
		public bool ativo;
		public DateTime dataFabricao;
		public DateTime dataValidade;
		public string cnpj;
		public string descricaoFornecedor;
	}
}
