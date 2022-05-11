using CourseworkUI.Services;
using System.Windows;
using System.Windows.Input;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for RegisterWindow.xaml
	/// </summary>
	public partial class RegisterWindow : Window 
	{
		private ApplicationContext _database = new ApplicationContext();

		public RegisterWindow(ApplicationContext dataBase)
		{
			_database = dataBase;
			InitializeComponent();
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


	}
}
