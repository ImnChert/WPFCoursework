using CourseworkUI.Models;
using CourseworkUI.Models.Users.Employees;
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
using System.Windows.Shapes;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for EconomistWindow.xaml
	/// </summary>
	public partial class EconomistWindow : Window
	{
		public TypeOfInsurance TypeOfInsurance { get; set; } = null!;
		public Economist Economist { get; set; }
		public EconomistWindow(Economist economist)
		{
			Economist = economist;
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
