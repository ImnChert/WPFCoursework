using CourseworkUI.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CourseworkUI.Models.Employees;
using CourseworkUI.Windows;
using System;

namespace CourseworkUI.Pages.AdminPages
{
	/// <summary>
	/// Interaction logic for AddEmployeePage.xaml
	/// </summary>
	public partial class AddEmployeePage : Page
	{
		private Admin _admin;
		private ApplicationContext _db = new ApplicationContext();

		public AddEmployeePage()
		{
			var window = Application.Current.Windows[0];
			if (window is not AdminWindow)
				window = Application.Current.Windows[2];
			var s = (AdminWindow)window;

			_admin = s.Admin;
			InitializeComponent();
			AddPostsToComboBox();
		}

		private void AddPostsToComboBox()
		{
			var listPost = new List<string>()
			{
				"Admin",
				"Accountant",
				"Economist",
				"Maanger",
				"Insurance agent"
			};

			PostComboBox.Items.Add(listPost);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
			=> _admin.AddEmployee(_db, UsernameTextBox.Text, PasswordTextBox.Text, FirstNameTextBox.Text, 
				LastNameTextBox.Text, MiddleNameTextBox.Text, PostComboBox.Text, Convert.ToDecimal(SalaryTextBox.Text));
	}
}
