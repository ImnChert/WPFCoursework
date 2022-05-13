using CourseworkUI.Models.Employees;
using CourseworkUI.Services;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using CourseworkUI.Models;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for AdminWindow.xaml
	/// </summary>
	public partial class AdminWindow : Window
	{
		public Admin Admin;
		private ApplicationContext _db = new ApplicationContext();

		public AdminWindow(Admin admin)
		{
			Admin = admin;
			InitializeComponent();
			FillingOutListBox();
		}

		private void FillingOutListBox()
		{
			ListUsers.ItemsSource = _db.Users.Where(u => u.Hide == false && u.Username != Admin.Username)
											.ToList();
			ListUsers.DisplayMemberPath = "Username";
		}

		private void Cross_MouseDown(object sender, MouseButtonEventArgs e) => this.Close();

		private void Stick_MouseDown(object sender, MouseButtonEventArgs e) => this.WindowState = WindowState.Minimized;

		private void Top_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
				DragMove();
		}

		private void Frame_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
				DragMove();
		}

		private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
		{
			var user = (User)ListUsers.SelectedItem;
			Admin.DeleteUser(_db, user);
			ListUsers.SelectedItem = null;

			// TODO: убиралось в ListBox 
		}

		private void ListUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			DeleteUserButton.IsEnabled = true;

			if (ListUsers.SelectedItem is Employee)
				ChangeEmployee.IsEnabled = true;
			else
				ChangeEmployee.IsEnabled = false;
		}
	}
}
