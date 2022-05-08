using CourseworkUI.Models.Clients;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CourseworkUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ApplicationContext DataBase = new ApplicationContext();

		public MainWindow()
		{
			InitializeComponent();
		}

		public MainWindow(ApplicationContext dataBase)
		{
			DataBase = dataBase;
			InitializeComponent();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
				DragMove();
		}

		private void Cross_MouseDown(object sender, MouseButtonEventArgs e) => this.Close();

		private void Stick_MouseDown(object sender, MouseButtonEventArgs e) => this.WindowState = WindowState.Minimized;

		private void Register_Click(object sender, RoutedEventArgs e)
		{
			RegisterWindow window = new RegisterWindow(DataBase);
			Application.Current.MainWindow = window;

			window.Show();
			this.Close();

		}

		private void TxtUser_GotFocus(object sender, RoutedEventArgs e)
		{
			txtUser.ShadowText().CheckGotFocus("Username");
		}

		private void TxrPas_GotFocus(object sender, RoutedEventArgs e)
		{
			txrPas.ShadowText().CheckGotFocus("Password");
		}

		private void TxtUser_LostFocus(object sender, RoutedEventArgs e)
		{
			txtUser.ShadowText().CheckLostFocus("Username");
		}

		private void TxrPas_LostFocus(object sender, RoutedEventArgs e)
		{
			txrPas.ShadowText().CheckLostFocus("Password");
		}

		private void Login_Click(object sender, RoutedEventArgs e)
		{
			var user = DataBase.Users.FirstOrDefault(p => p.Username == txtUser.Text && p.Password == txrPas.Password);

			if (user != null)
			{
				Dictionary<string, Action> dictionary = GetDictionary();
				dictionary[user.ToString()]();
			}
			else
			{
				// ошибка
			}
		}

		private void OpenNewWindow(Window window)
		{
			window.Show();
			this.Close();
		}

		private Dictionary<string, Action> GetDictionary()
		{
			return new Dictionary<string, Action>()
			{
				{ "NaturalPerson", () => { OpenNewWindow(new ClientWindow(DataBase)); } },
				{ "LegalPerson", () => { OpenNewWindow(new ClientWindow(DataBase)); } },
				{ "Accountant", () => { OpenNewWindow(new ClientWindow(DataBase)); } },
				{ "Accountant", () => { OpenNewWindow(new ClientWindow(DataBase)); } },
				{ "InsuranceAgent", () => { OpenNewWindow(new ClientWindow(DataBase)); }},
				{ "Manager", () => { OpenNewWindow(new ClientWindow(DataBase)); }},
				{ "Admin", () => { OpenNewWindow(new ClientWindow(DataBase)); }},
			};
		}
	}
}
