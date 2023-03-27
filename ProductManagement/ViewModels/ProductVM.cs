using System.ComponentModel.DataAnnotations;

namespace Product.Api.ViewModels
{
	public class ProductVM
	{
		public int id;
		public string descricaoProduto;
		public bool ativo;
		public DateTime dataFabricao;
		public DateTime dataValidade;
		public int idFornecedor;
	}
}
