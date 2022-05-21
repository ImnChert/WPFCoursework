using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkUI.Models
{
	public class MonthlyPayment
	{
		public int MonthlyPaymentId { get; set; }
		public decimal PayoutAmount { get; set; }
		public int Month { get; set; }

		public int PolicyId { get; set; }
		public virtual Policy? Policy { get; set; }
	}
}
