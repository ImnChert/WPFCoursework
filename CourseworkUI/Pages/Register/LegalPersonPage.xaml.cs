using CourseworkUI.Interfaces;
using CourseworkUI.Models.Clients;
using CourseworkUI.Services;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.Register
{
	/// <summary>
	/// Interaction logic for LegalPersonPage.xaml
	/// </summary>
	public partial class LegalPersonPage : Page, IApplicationContext
	{
		public ApplicationContext DataBase { get; } = GetApplicationContext.GetAppContext();

		public LegalPersonPage()
		{
			InitializeComponent();
		}

		private void TxtNameOfOrganization_GotFocus(object sender, RoutedEventArgs e)
		{
			TxtNameOfOrganization.ShadowText().CheckGotFocus("Name of the organization");
		}

		private void TxtNameOfOrganization_LostFocus(object sender, RoutedEventArgs e)
		{
			TxtNameOfOrganization.ShadowText().CheckLostFocus("Name of the organization");
		}

		private void TxtUser_GotFocus(object sender, RoutedEventArgs e)
		{
			txtUser.ShadowText().CheckGotFocus("Username");
		}

		private void TxtPas_GotFocus(object sender, RoutedEventArgs e)
		{
			txtPas.ShadowText().CheckGotFocus("Password");
		}

		private void Address_GotFocus(object sender, RoutedEventArgs e)
		{
			Address.ShadowText().CheckGotFocus("Address");
		}

		private void TxtUser_LostFocus(object sender, RoutedEventArgs e)
		{
			txtUser.ShadowText().CheckLostFocus("Username");
		}

		private void TxtPas_LostFocus(object sender, RoutedEventArgs e)
		{
			txtPas.ShadowText().CheckLostFocus("Password");
		}

		private void Address_LostFocus(object sender, RoutedEventArgs e)
		{
			Address.ShadowText().CheckLostFocus("Address");
		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			TxtNameOfOrganization.Rules().MinCharacters(5).Validate();
			txtUser.Rules().MinCharacters(5).Validate();
			txtPas.Rules().MinCharacters(5).Validate();
			Address.Rules().MinCharacters(5).Validate();

			if (TxtNameOfOrganization.IsCorrect() &&
				txtUser.IsCorrect() &&
				txtPas.IsCorrect() &&
				Address.IsCorrect())
			{
				var legalPerson = new LegalPerson(txtUser.Text, txtPas.Password, TxtNameOfOrganization.Text, Address.Text);

				DataBase.LegalPersons.Add(legalPerson);
				DataBase.SaveChanges();

				var window = new MainWindow();
				Application.Current.MainWindow = window;

				window.Show();
				Application.Current.Windows[0].Close();
			}
		}
	}
}
