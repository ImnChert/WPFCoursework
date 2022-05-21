using CourseworkUI.Services;
using CourseworkUI.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.ManagerPages
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

		private void EmployeeSalariesButton_Click(object sender, RoutedEventArgs e)
		{
			var employees = _db.Employees.Where(e => e.Hide == false)
										.Select(e => new
										{
											LastName = e.LastName,
											FirstName = e.FirstName,
											MiddleName = e.MiddleName,
											Post = e.ToString(),
											Salary = e.Salary
										})
										.ToList();

			var window = new CreateReportWindow();
			window.Create(employees);
		}

		private void Policybutton_Click(object sender, RoutedEventArgs e)
		{
			var policy = _db.Polices.Where(e => e.Payment == Models.EquineBeast.Function)
									.Select(p => new
									{
										Name = p.TypeOfInsurance.Name,
										Client = p.Client.Id,
										InsuranceAgent = $"{p.InsuranceAgent.FirstName} {p.InsuranceAgent.MiddleName} {p.InsuranceAgent.LastName}",
										InsuranceAmount = p.InsuranceAmount,
										Cost = p.CostOfTheInsuranceContract,
										DateOfConclusion = p.DateOfConclusion,
										ExpirationDate = p.ExpirationDate
									})
									.ToList();
			var window = new CreateReportWindow();
			window.Create(policy);
		}
	}
}
