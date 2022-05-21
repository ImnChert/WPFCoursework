using CourseworkUI.Models.Employees;
using CourseworkUI.Models.Users.Clients;
using System;
using System.Collections.Generic;
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
		public virtual List<MonthlyPayment> MonthlyPay { get; set; } = new List<MonthlyPayment>();
		public EquineBeast Payment { get; set; } = EquineBeast.Function;
		public decimal AmountPaid { get; set; } = 0;

		public Policy(decimal insuranceAmount, decimal costOfTheInsuranceContract, DateTime dateOfConclusion)
		{
			InsuranceAmount = insuranceAmount;
			CostOfTheInsuranceContract = costOfTheInsuranceContract;
			DateOfConclusion = dateOfConclusion;
			ExpirationDate = dateOfConclusion.AddMonths(12);
			CheckPayment();
		}

		// TODO: сделать уведомление завершения действия полиса

		private void CheckPayment()
		{
			if (DateTime.Now >= ExpirationDate)
			{
				Payment = EquineBeast.Unfunction;
			}

			bool paidFor = false;
			decimal howMuchIsPaid = 0;

			foreach (var item in MonthlyPay)
			{
				howMuchIsPaid += item.PayoutAmount;

				if (item.Month == DateTime.Now.Month)
					paidFor = true;
			}

			if (!paidFor && howMuchIsPaid < CostOfTheInsuranceContract)
				Payment = EquineBeast.Frozen;

			// TODO: рефакторинг
		}
	}

	public enum EquineBeast
	{
		SentRequest,
		Function,
		Unfunction,
		Paid,
		Frozen,
		UnderConsideration
	}
}
