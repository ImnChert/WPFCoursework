using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseworkUI.Models
{
	public class TypeOfInsurance : INotifyPropertyChanged
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Descriprion { get; set; }
		public decimal InsuranceAmount { get; set; }
		public decimal CostOfTheInsuranceContract { get; set; }
		public decimal CoefficientOfIncrease { get; set; }
		public virtual ICollection<InsuranceRisk> IncludedRisks { get; set; } = new List<InsuranceRisk>();

		public TypeOfInsurance(string name, string descriprion, decimal insuranceAmount, decimal costOfTheInsuranceContract, decimal coefficientOfIncrease)
		{
			Name = name;
			Descriprion = descriprion;
			InsuranceAmount = insuranceAmount;
			CostOfTheInsuranceContract = costOfTheInsuranceContract;
			CoefficientOfIncrease = coefficientOfIncrease;	
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
