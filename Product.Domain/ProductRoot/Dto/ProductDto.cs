using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.ProductRoot.Dto
{
	public class ProductDto
	{
		[Required(ErrorMessage = "Description Product is required")]
		private string descriptionProduct;
		private bool active;
		private DateTime manufacturingDate;
		private DateTime validadeDate;
		private string descriptionSupplier;
		private string cnpj;
		private int id;

		public string DescriptionProduct { get => descriptionProduct; set => descriptionProduct = value; }
		public bool Active { get => active; set => active = value; }
		public DateTime ManufacturingDate { get => manufacturingDate; set => manufacturingDate = value; }
		public DateTime ValidadeDate { get => validadeDate; set => validadeDate = value; }
		public string DescriptionSupplier { get => descriptionSupplier; set => descriptionSupplier = value; }
		public string Cnpj { get => cnpj; set => cnpj = value; }
		public int Id { get => id; set => id = value; }
	}
}
