using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.ProductRoot.Entity
{
	public class Product : EntityBase
	{
		[Key]
		[Required]
		public int id;
		[Required(ErrorMessage = "Product title is required")]
		public string descriptionProduct;
		public bool active;
		public DateTime manufacturingDate;
		public DateTime validadeDate;
		public string cnpj;
		public string descriptionSupplier;
	}
}
