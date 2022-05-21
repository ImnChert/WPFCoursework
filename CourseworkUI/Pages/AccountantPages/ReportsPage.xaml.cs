using CourseworkUI.Services;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using CourseworkUI.Windows;

namespace CourseworkUI.Pages.AccountantPages
{
	/// <summary>
	/// Interaction logic for ReportsPage.xaml
	/// </summary>
	public partial class ReportsPage : Page
	{
		private ApplicationContext _db = new ApplicationContext();

		public ReportsPage()
		{
			InitializeComponent();
		}

		private void CommissionPoliciesButton_Click(object sender, RoutedEventArgs e)
		{
			var policy = _db.Polices.Where(p => p.Payment == Models.EquineBeast.UnderConsideration)
									.Select(p => new
									{
										Name = p.TypeOfInsurance.Name,
										InsuranceAmount = p.InsuranceAmount,
										CostOfTheInsuranceContract = p.CostOfTheInsuranceContract,
										InsuranceAgent = $"{p.InsuranceAgent.FirstName} {p.InsuranceAgent.MiddleName} {p.InsuranceAgent.LastName}",
										Client = p.Client.Id
									})
									.ToList();
			var window = new CreateReportWindow();
			window.Create(policy);
		}

		private void FrozzenPoliciesButton_Click(object sender, RoutedEventArgs e)
		{
			var policy = _db.Polices.Where(p => p.Payment == Models.EquineBeast.Frozen)
									.Select(p => new
									{
										Name = p.TypeOfInsurance.Name,
										InsuranceAmount = p.InsuranceAmount,
										CostOfTheInsuranceContract = p.CostOfTheInsuranceContract,
										InsuranceAgent = $"{p.InsuranceAgent.FirstName} {p.InsuranceAgent.MiddleName} {p.InsuranceAgent.LastName}",
										Client = p.Client.Id,
										HowMuchHasBeenDeposited = p.MonthlyPay.Sum(m => m.PayoutAmount)
									})
									.ToList();
			var window = new CreateReportWindow();
			window.Create(policy);
		}

		private void PaidPoliciesButton_Click(object sender, RoutedEventArgs e)
		{
			var policy = _db.Polices.Where(p => p.Payment == Models.EquineBeast.Paid)
									.Select(p => new
									{
										Name = p.TypeOfInsurance.Name,
										CostOfTheInsuranceContract = p.CostOfTheInsuranceContract,
										InsuranceAgent = $"{p.InsuranceAgent.FirstName} {p.InsuranceAgent.MiddleName} {p.InsuranceAgent.LastName}",
										Client = p.Client.Id,
										PayoutAmount = p.AmountPaid
									})
									.ToList();
			var window = new CreateReportWindow();
			window.Create(policy);
		}
	}
}