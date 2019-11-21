using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Models
{
	public class Space
	{
		public string Id { get; set; }
		public string Provider { get; set; }
		public string Category { get; set; }
		public string Name { get; set; }
		public string[] Photos { get; set; }
		public float Price { get; set; }
		public int[][] Schedule { get; set; }
		public List<Tuple<string, int[]>> BookingSchedule { get; set; }
	}
}
