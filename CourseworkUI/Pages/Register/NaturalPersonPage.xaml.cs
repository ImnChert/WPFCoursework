using CourseworkUI.Interfaces;
using CourseworkUI.Models.Clients;
using CourseworkUI.Services;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.Register
{
	/// <summary>
	/// Interaction logic for NaturalPersonPage.xaml
	/// </summary>
	public partial class NaturalPersonPage : Page, IApplicationContext
	{
		public ApplicationContext DataBase { get; } = GetApplicationContext.GetAppContext();

		public NaturalPersonPage()
		{
			InitializeComponent();
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

		private void txtFirstName_GotFocus(object sender, RoutedEventArgs e)
		{
			txtFirstName.ShadowText().CheckGotFocus("First name");
		}

		private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
		{
			txtFirstName.ShadowText().CheckLostFocus("First name");
		}

		private void txtLastName_GotFocus(object sender, RoutedEventArgs e)
		{
			txtLastName.ShadowText().CheckGotFocus("Last name");
		}

		private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
		{
			txtLastName.ShadowText().CheckLostFocus("Last name");
		}

		private void txtMiddleName_LostFocus(object sender, RoutedEventArgs e)
		{
			txtMiddleName.ShadowText().CheckLostFocus("Middle name");
		}

		private void txtMiddleName_GotFocus(object sender, RoutedEventArgs e)
		{
			txtMiddleName.ShadowText().CheckGotFocus("Middle name");
		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			txtFirstName.Rules().MinCharacters(5).Validate();
			txtLastName.Rules().MinCharacters(5).Validate();
			txtMiddleName.Rules().MinCharacters(5).Validate();
			txtUser.Rules().MinCharacters(5).Validate();
			txtPas.Rules().MinCharacters(5).Validate();
			Address.Rules().MinCharacters(5).Validate();

			if (txtFirstName.IsCorrect() &&
				txtLastName.IsCorrect() &&
				txtMiddleName.IsCorrect() &&
				txtUser.IsCorrect() &&
				txtPas.IsCorrect() &&
				Address.IsCorrect())
			{
				var naturalPesron = new NaturalPerson(txtUser.Text, txtPas.Password, txtFirstName.Text, txtLastName.Text, txtMiddleName.Text, Address.Text);

				DataBase.NaturalPersons.Add(naturalPesron);
				DataBase.SaveChanges();

				var window = new MainWindow();
				Application.Current.MainWindow = window;

				window.Show();
				Application.Current.Windows[0].Close();
			}
		}
	}
}
