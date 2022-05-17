using CourseworkUI.Models.Clients;
using CourseworkUI.Models.Users.Clients;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for ClientInformationWindow.xaml
	/// </summary>
	public partial class ClientInformationWindow : Window
	{

		public Client Client;

		public ClientInformationWindow(Client client)
		{
			Client = client;
			InitializeComponent();
			OpenPage();
		}

		private void OpenPage()
		{
			if(Client is NaturalPerson)
			{
				ViewModel.CurPage = (Page)ViewModel.OpenNaturalPersonInformationPage;
			}
			else if(Client is LegalPerson)
			{
				ViewModel.CurPage = (Page)ViewModel.OpenLegalPersonInformationPage;
			}
		}
	}
}
