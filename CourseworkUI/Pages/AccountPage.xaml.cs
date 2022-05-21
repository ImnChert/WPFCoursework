using CourseworkUI.Models;
using System.Windows;
using System.Windows.Controls;
using CourseworkUI.Models.Clients;
using CourseworkUI.Interfaces;
using CourseworkUI.Services;

namespace CourseworkUI.Pages
{
	/// <summary>
	/// Interaction logic for AccountPage.xaml
	/// </summary>
	public partial class AccountPage : Page
	{
		private User _user = null!;
		private ApplicationContext _db = new ApplicationContext();

		public AccountPage()
		{
			InitializeComponent();
		}

		public void Fill(User user)
		{
			_user = user;

			UsernameTextBox.Text = user.Username;
			PasswordTextBox.Text = user.Password;

			if (_user is LegalPerson legalPerson)
			{
				LegalPersonGrid.Visibility = Visibility.Visible;
				NaturalPersonGrid.Visibility = Visibility.Hidden;

				NameOrganizationTextBox.Text = legalPerson.NameOfOrganization;
			}
			else if (_user is IFullName fullNamePerson)
			{
				LegalPersonGrid.Visibility = Visibility.Hidden;
				NaturalPersonGrid.Visibility = Visibility.Visible;

				FirstNameTextBox.Text = fullNamePerson.FirstName;
				LastNameTextBox.Text = fullNamePerson.LastName;
				MiddleNameTextBox.Text = fullNamePerson.MiddleName;
			}
		}

		private void ChangeButton_Click(object sender, RoutedEventArgs e)
		{
			UsernameTextBox.IsReadOnly = false;
			PasswordTextBox.IsReadOnly = false;
			ChangeButton.Visibility = Visibility.Hidden;
			SaveButton.Visibility = Visibility.Visible;
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if (true)
			{
				_user.Username = UsernameTextBox.Text;
				_user.Password = PasswordTextBox.Text;

				_db.Users.Update(_user);
				_db.SaveChanges();

				UsernameTextBox.IsReadOnly = true;
				PasswordTextBox.IsReadOnly = true;
				ChangeButton.Visibility = Visibility.Visible;
				SaveButton.Visibility = Visibility.Hidden;
			}

		}
	}
}
