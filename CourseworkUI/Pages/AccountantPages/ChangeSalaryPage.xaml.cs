using CourseworkUI.Models.Employees;
using CourseworkUI.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.AccountantPages
{
	/// <summary>
	/// Interaction logic for ChangeSalaryPage.xaml
	/// </summary>
	public partial class ChangeSalaryPage : Page
	{
		private ApplicationContext _db = new ApplicationContext();

		public ChangeSalaryPage()
		{
			InitializeComponent();
			ListEmployee.ItemsSource = _db.Employees.Where(e => e.Hide == false)
													.Select(e=>e)
													.ToList();
			ListEmployee.DisplayMemberPath = "LastName";
			// TODO: нормально не выводится
			// может сделать в employee ФИО
		}

		private void ChangeButton_Click(object sender, RoutedEventArgs e)
		{
			var employee = (Employee)ListEmployee.SelectedItem;

			if (SalaryTextBox.Text != employee.Salary.ToString())
			{
				employee.Salary = Convert.ToDecimal(SalaryTextBox.Text);
				_db.Employees.Update(employee);
				_db.SaveChanges();
			}
		}

		private void ListEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var employee = (Employee)ListEmployee.SelectedItem;
			PostTextBox.Text = employee.ToString();
			SalaryTextBox.Text = employee.Salary.ToString();
		}
	}
}
