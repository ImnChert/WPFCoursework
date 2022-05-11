using CourseworkUI.Models.Employees;
using CourseworkUI.Models.Users.Clients;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models
{
	[Table("Polices")]
	public class Policy
	{
		public int Id { get; set; }
		public virtual Client Client { get; set; }
		public virtual InsuranceAgent InsuranceAgent { get; set; } 
		public virtual TypeOfInsurance TypeOfInsurance { get; set; }
		public decimal InsuranceAmount { get; set; }
		public decimal CostOfTheInsuranceContract { get; set; }
		public DateTime DateOfConclusion { get; set; }
		public DateTime ExpirationDate { get; set; }
	}
}
