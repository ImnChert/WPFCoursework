using CourseworkUI.Models.Employees;
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
	/// Interaction logic for InsuranceAgentWindow.xaml
	/// </summary>
	public partial class InsuranceAgentWindow : Window
	{
		public InsuranceAgent InsuranceAgent;

		public InsuranceAgentWindow(InsuranceAgent insuranceAgent)
		{
			InsuranceAgent = insuranceAgent;
			InitializeComponent();
		}
		// TODO: сделать меню страх агента
		private void Cross_MouseDown(object sender, MouseButtonEventArgs e) => this.Close();

		private void Stick_MouseDown(object sender, MouseButtonEventArgs e) => this.WindowState = WindowState.Minimized;

		// TODO: сделать страхового агента
	}
}
