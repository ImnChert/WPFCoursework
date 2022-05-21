using CourseworkUI.Models;
using CourseworkUI.Services;
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

namespace CourseworkUI.Pages.ClientPages
{
	/// <summary>
	/// Interaction logic for IssuedPoliciesPage.xaml
	/// </summary>
	public partial class IssuedPoliciesPage : Page
	{
		private ApplicationContext _db = new ApplicationContext();

		public IssuedPoliciesPage()
		{
			InitializeComponent();
			var window = Application.Current.Windows[0];
			if (window is not ClientWindow)
				window = Application.Current.Windows[2];
			var s = (ClientWindow)window;
			var client = s.Client;
			PolicyList.ItemsSource = _db.Polices.Where(p => p.Client.Id == client.Id && p.Payment != Models.EquineBeast.Unfunction)
												.Select(p => p)
												.ToList();
			PolicyList.DisplayMemberPath = "Id";
		}

		private void InsuranceButton_Click(object sender, RoutedEventArgs e)
		{
			var policy = (Policy)PolicyList.SelectedItem;

			if (policy.Payment == EquineBeast.Function)
			{
				policy.Payment = EquineBeast.SentRequest;
				_db.Polices.Update(policy);
				_db.SaveChanges();
			}
		}
	}
}
