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
	/// Interaction logic for NaturalPersonInformationPage.xaml
	/// </summary>
	public partial class NaturalPersonInformationPage : Page
	{
		public NaturalPersonInformationPage()
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

			if (s.Client is NaturalPerson client)
			{
				LastNameText.Text = client.LastName;
				FirstNameText.Text = client.FirstName;
				MiddleNameText.Text = client.MiddleName;
				LocalityText.Text = client.Locality;
				HouseNumberText.Text = client.HouseNumber;
				AppartmentNumberText.Text = client.ApartmentNumber;
			}
		}

		// TODO: рефакторинг
	}
}
