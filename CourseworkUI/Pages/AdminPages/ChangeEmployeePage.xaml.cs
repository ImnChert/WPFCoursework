using CourseworkUI.Models.Employees;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseworkUI.Pages.AdminPages

{
	/// <summary>
	/// Interaction logic for ChangeEmployeePage.xaml
	/// </summary>
	public partial class ChangeEmployeePage : Page
	{
		private Admin _admin;
		private Employee _employee = null!;
		private ApplicationContext _db = new ApplicationContext();

		public ChangeEmployeePage()
		{
			var window = Application.Current.Windows[0];
			if (window is not AdminWindow)
				window = Application.Current.Windows[2];
			var s = (AdminWindow)window;

			_admin = s.Admin;
			InitializeComponent();
		}
		 

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var window = Application.Current.Windows[0];
			if (window is not AdminWindow)
				window = Application.Current.Windows[2];
			var s = (AdminWindow)window;

			_employee = s.ListUsers.SelectedItem as Employee;
			_admin.ChangeEmployee(_db, _employee, FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text);
		}
	}
}
