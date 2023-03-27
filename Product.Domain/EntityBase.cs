using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain
{
	public class EntityBase
	{
		public int Id { get; set; }
		public DateTime? DtAlteracao { get; set; }
		public string LgUsuario { get; set; }
	}
}
