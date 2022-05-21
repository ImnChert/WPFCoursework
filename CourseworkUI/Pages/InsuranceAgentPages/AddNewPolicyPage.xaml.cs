using CourseworkUI.Models;
using CourseworkUI.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.InsuranceAgentPages
{
	/// <summary>
	/// Interaction logic for AddNewPolicyPage.xaml
	/// </summary>
	public partial class AddNewPolicyPage : Page
	{
		private ApplicationContext _db = new ApplicationContext();

		public AddNewPolicyPage()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// TODO: проверки

			var application = _db.ClientApplications.First(a => a.Id == Convert.ToInt32(NumberApplicationTextBox.Text));

			if (application != null)
			{
				var policy = new Policy(Convert.ToInt32(InsuranceAmountTextBox.Text), Convert.ToInt32(CostTextBox.Text), DateTime.Now);
				policy.TypeOfInsurance = application.TypeOfInsurance;
				policy.InsuranceAgent = application.InsuranceAgent;
				policy.Client = application.Client;

				_db.Polices.Add(policy);
				_db.SaveChanges();
			}
		}
	}
}
