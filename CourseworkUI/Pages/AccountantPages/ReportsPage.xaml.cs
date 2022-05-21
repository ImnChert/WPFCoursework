using CourseworkUI.Services;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using OxyPlot;
using System.Collections.Generic;
using CourseworkUI.Windows;
using CourseworkUI.Models.Employees;

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
			//Chart chart;
			
		}

		private void EmployeeSalariesButton_Click(object sender, RoutedEventArgs e)
		{
			var employees = _db.Employees.Where(e => e.Hide == false)
										.Select(e => new { LastName = e.LastName,
											FirstName = e.FirstName,
											MiddleName = e.MiddleName,
											Post = e.ToString(),
											Salary = e.Salary
										})
										.ToList();

			var window = new CreateReportWindow();
			window.Create(employees);
		}
	}
}
