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
using System.Linq;
using CourseworkUI.Windows;

namespace CourseworkUI.Pages.InsuranceAgentPages
{
	/// <summary>
	/// Interaction logic for ViewingApplicationsnPage.xaml
	/// </summary>
	public partial class ViewingApplicationsnPage : Page
	{
		private ClientApplication _application { get; set; } = null!;

		private ApplicationContext _db = new ApplicationContext();
		public ViewingApplicationsnPage()
		{
			InitializeComponent();

			ApplicationListBox.ItemsSource = FindPendingContracts();
		}

		private List<ClientApplication> FindPendingContracts()
			=> _db.ClientApplications.Where(a => a.InsuranceAgent != null)
									.Select(a => a)
									.ToList();

		private void ApplicationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			HiddenGrid.Visibility = Visibility.Visible;

			_application = (ClientApplication)ApplicationListBox.SelectedItem;

			ClientLink.DataContext = _application.Client.Username;
			TypeOfInsuracneLink.DataContext = _application.TypeOfInsurance.Name;

		}

		private void ClientLink_Click(object sender, RoutedEventArgs e)
		{
			var clientInformationWindow = new ClientInformationWindow(_application.Client);

			clientInformationWindow.ShowDialog();
		}

		private void TypeOfInsuracneLink_Click(object sender, RoutedEventArgs e)
		{
			var clientInformationWindow = new TypeOfInsuranceInformationWindow(_application.TypeOfInsurance);

			clientInformationWindow.ShowDialog();
		}

		private void ApproveButton_Click(object sender, RoutedEventArgs e)
		{
			// TODO: открытие мессаджера и поставить агента
		}
	}
}
