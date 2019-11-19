using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Models
{
	public class Provider
	{
		public string Id { get; set; }
		public string EMail { get; set; }
		public string Password { get; set; }
		public string Forenames { get; set; }
		public string Surnames { get; set; }
		public string BusinessName { get; set; }
		public string Tradename { get; set; }
		public string Image { get; set; }
		public double[] Address { get; set; }
		public string RUC { get; set; }
		public string Phone { get; set; }
		public string Sector { get; set; }
		public int[][] Schedule { get; set; }
	}
}
