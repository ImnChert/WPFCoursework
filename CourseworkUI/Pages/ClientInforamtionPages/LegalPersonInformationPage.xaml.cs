using CourseworkUI.Models.Clients;
using CourseworkUI.Windows;
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

namespace CourseworkUI.Pages.ClientInforamtionPages
{
	/// <summary>
	/// Interaction logic for LegalPersonInformationPage.xaml
	/// </summary>
	public partial class LegalPersonInformationPage : Page
	{
		public LegalPersonInformationPage()
		{
			InitializeComponent();
			Fill();
		}

		private void Fill()
		{
			var window = Application.Current.Windows[0];
			if (window is not ClientInformationWindow)
				window = Application.Current.Windows[2];
			var s = (ClientInformationWindow)window;

			if (s.Client is LegalPerson client)
			{
				NameOfOrganizationText.Text = client.NameOfOrganization;
				LocalityText.Text = client.Locality;
				HouseNumberText.Text = client.HouseNumber;
			}
		}

		// TODO: рефакторинг
	}
}
