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
using CourseworkUI.Models.Employees;

namespace CourseworkUI.Pages.InsuranceAgentPages
{
	/// <summary>
	/// Interaction logic for ViewingApplicationsnPage.xaml
	/// </summary>
	public partial class ViewingApplicationsnPage : Page
	{
		private ClientApplication _application { get; set; } = null!;

		private ApplicationContext _db = new ApplicationContext();
		private InsuranceAgent _insuranceAgent;

		public ViewingApplicationsnPage()
		{
			InitializeComponent();

			var window = Application.Current.Windows[0];
			if (window is not InsuranceAgentWindow)
				window = Application.Current.Windows[2];
			var s = (InsuranceAgentWindow)window;
			_insuranceAgent = s.InsuranceAgent;


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
			if (_application != null)
			{
				_application.InsuranceAgent = _insuranceAgent;


				var window = Application.Current.Windows[0];
				if (window is not InsuranceAgentWindow)
					window = Application.Current.Windows[2];
				var s = (InsuranceAgentWindow)window;

				s.ViewModel.OpenCreateMessagePage.Execute("");
				var i = (CreateMessagePage)s.ViewModel.CurPage;
				i.ToTextBox.Text = _application.Client.Username;
			}
			// TODO: открытие мессаджера и поставить агента
		}
	}
}
