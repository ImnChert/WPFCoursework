using CourseworkUI.Models;
using CourseworkUI.Models.Users.Clients;
using CourseworkUI.Services;
using System.Windows;
using System.Windows.Input;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for ClientWindow.xaml
	/// </summary>
	public partial class ClientWindow : Window
	{
		private ApplicationContext _database { get; } = null!;
		public Client Client { get; } 
		public TypeOfInsurance TypeOfInsurance { get; set; }

		public ClientWindow(Client client)
		{
			Client = client;
			InitializeComponent();
		//clientView.CurPage
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

		public void SuccessfulRegistration()
		{
			MainWindow window = new MainWindow();
			Application.Current.MainWindow = window;

			window.Show();
			this.Close();
		}
	}
}

