using CourseworkUI.Models;
using CourseworkUI.Services;
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

namespace CourseworkUI.Pages.EconomistPages
{
	/// <summary>
	/// Interaction logic for AddInsuranceRiskPage.xaml
	/// </summary>
	public partial class AddInsuranceRiskPage : Page
	{
		ApplicationContext _db = new ApplicationContext();

		public AddInsuranceRiskPage()
		{
			InitializeComponent();
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			string name = NameTextBox.Text;
			var risk = new InsuranceRisk(name);
			_db.InsuranceRisks.Add(risk);
			_db.SaveChanges();
		}
	}
}
