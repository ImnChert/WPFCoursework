using CourseworkUI.Models.Employees;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using System.Windows;
using System.Windows.Controls;

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

			_employee = (Employee)s.ListUsers.SelectedItem;
			_admin.ChangeEmployee(_db, _employee, FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text);
		}
	}

	// TODO: Админ может менять только Post
}
