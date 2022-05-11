using CourseworkUI.Models.Clients;
using CourseworkUI.Services;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.Register
{
	/// <summary>
	/// Interaction logic for LegalPersonPage.xaml
	/// </summary>
	public partial class LegalPersonPage : Page
	{
		private ApplicationContext _database { get; } = new ApplicationContext();

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

		private void TxtUser_LostFocus(object sender, RoutedEventArgs e)
		{
			txtUser.ShadowText().CheckLostFocus("Username");
		}

		private void TxtPas_LostFocus(object sender, RoutedEventArgs e)
		{
			txtPas.ShadowText().CheckLostFocus("Password");
		}

		private void HouseNumber_GotFocus(object sender, RoutedEventArgs e)
		{
			HouseNumber.ShadowText().CheckGotFocus("House number");
		}

		private void HouseNumber_LostFocus(object sender, RoutedEventArgs e)
		{
			HouseNumber.ShadowText().CheckLostFocus("House number");
		}

		private void LocalityText_LostFocus(object sender, RoutedEventArgs e)
		{
			LocalityText.ShadowText().CheckLostFocus("Locality");
		}

		private void LocalityText_GotFocus(object sender, RoutedEventArgs e)
		{
			LocalityText.ShadowText().CheckGotFocus("Locality");
		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			TxtNameOfOrganization.Rules().MinCharacters(5).Validate();
			txtUser.Rules().MinCharacters(5).Validate();
			txtPas.Rules().MinCharacters(5).Validate();
			LocalityText.Rules().MinCharacters(5).Validate();
			HouseNumber.Rules().MinCharacters(5).Validate();

			if (TxtNameOfOrganization.IsCorrect() &&
				txtUser.IsCorrect() &&
				txtPas.IsCorrect() &&
				HouseNumber.IsCorrect() &&
				LocalityText.IsCorrect())
			{
				var legalPerson = new LegalPerson(txtUser.Text, txtPas.Password, TxtNameOfOrganization.Text, LocalityText.Text, HouseNumber.Text);

				_database.LegalPersons.Add(legalPerson);
				_database.SaveChanges();

				var window = new MainWindow();
				Application.Current.MainWindow = window;

				window.Show();
				Application.Current.Windows[0].Close();
			}
		}
	}
}
