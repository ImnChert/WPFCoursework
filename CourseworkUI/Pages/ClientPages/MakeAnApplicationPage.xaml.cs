using CourseworkUI.Models;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.Client
{
	/// <summary>
	/// Interaction logic for MakeAnApplicationPage.xaml
	/// </summary>
	public partial class MakeAnApplicationPage : Page
	{
		private ApplicationContext _database = new ApplicationContext();
		public List<TypeOfInsurance> TupesOfInsurance { get; set; }

		public MakeAnApplicationPage()
		{
			InitializeComponent();
			TupesOfInsurance = _database.TypesOfInsurances.Select(x=>x).ToList();
			ListTypeOfInsutrance.ItemsSource = TupesOfInsurance;
			ListTypeOfInsutrance.DisplayMemberPath = "Name";
		}

		private void ListTypeOfInsutrance_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var item = (TypeOfInsurance)ListTypeOfInsutrance.SelectedItem;
			NameText.Text = item.Name;
			DescriprionText.Text = item.Descriprion;
			CostText.Text = item.InsuranceAmount.ToString();
			FirstBox.Text = OutputText(item.IncludedRisks);
		}

		private string OutputText(ICollection<InsuranceRisk> insuranceRisks)
		{
			var s = "";

			foreach(var i in insuranceRisks)
			{
				s += i.Name + "\n";
			}

			return s;
		}

		private void ApplyButton_Click(object sender, RoutedEventArgs e)
		{
			var window = (ClientWindow)Application.Current.Windows[0];
			window.ViewModel.OpenApplyForInsurancePage.Execute("");
		}
	}
}
