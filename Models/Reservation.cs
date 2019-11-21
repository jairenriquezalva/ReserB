using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Models
{
	public class Reservation
	{
		public string Id { get; set; }
		public string Space { get; set; }
		public string Customer { get; set; }
		public string CreatedAt { get; set; }
		public int PaymentMethod { get; set; }
		public Tuple<string, int[]> Time{get; set;}
	}
}
