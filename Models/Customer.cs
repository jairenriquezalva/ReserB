using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Models
{
	public class Customer
	{
		public string Id { get; set; }
		public string EMail { get; set; }
		public string Password { get; set; }
		public string Forenames { get; set; }
		public string Surnames { get; set; }
		public DateTime Birthdate { get; set; }

	}
}
