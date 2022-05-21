using CourseworkUI.Models.Employees;
using System.Windows;
using System.Windows.Input;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for ManagerWindow.xaml
	/// </summary>
	public partial class ManagerWindow : Window
	{
		public Manager Manager;
		public ManagerWindow(Manager manager)
		{
			InitializeComponent();
			Manager = manager;
		}

		private void Cross_MouseDown(object sender, MouseButtonEventArgs e) => this.Close();

		private void Stick_MouseDown(object sender, MouseButtonEventArgs e) => this.WindowState = WindowState.Minimized;
	}
}
