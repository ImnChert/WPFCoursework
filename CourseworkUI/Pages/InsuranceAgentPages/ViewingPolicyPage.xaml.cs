using CourseworkUI.Models;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.InsuranceAgentPages
{
	/// <summary>
	/// Interaction logic for ViewingPolicyPage.xaml
	/// </summary>
	public partial class ViewingPolicyPage : Page
	{
		private ApplicationContext _db = new ApplicationContext();
		private Policy _policy { get; set; } = null!;

		public ViewingPolicyPage()
		{
			InitializeComponent();
			PolicyListBox.ItemsSource = FindPendingContracts();
		}

		private List<Policy> FindPendingContracts()
		=> _db.Polices.Where(p => p.Payment == EquineBeast.SentRequest)
								.Select(a => a)
								.ToList();

		private void PolicyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_policy = (Policy)PolicyListBox.SelectedItem;

			ClientLink.DataContext = _policy.Client.Username;
			TypeOfInsuranceTextBox.Text = _policy.TypeOfInsurance.Name;
			InsuranceAmountTextBox.Text = _policy.TypeOfInsurance.InsuranceAmount.ToString();
		}

		private void ClientLink_Click(object sender, RoutedEventArgs e)
		{
			var clientInformationWindow = new ClientInformationWindow(_policy.Client);

			clientInformationWindow.ShowDialog();
		}

		private void ApproveButton_Click(object sender, RoutedEventArgs e)
		{
			if (_policy != null)
			{
				_policy.Payment = EquineBeast.UnderConsideration;

				_db.Polices.Update(_policy);
				_db.SaveChanges();

				// TODO: открытие мессаджера
			}
		}
	}
}
