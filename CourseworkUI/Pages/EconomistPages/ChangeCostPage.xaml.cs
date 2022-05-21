using CourseworkUI.Models;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages.EconomistPages
{
	/// <summary>
	/// Interaction logic for ChangeCostPage.xaml
	/// </summary>
	public partial class ChangeCostPage : Page
	{
		private ApplicationContext _database = new ApplicationContext();

		public ChangeCostPage()
		{
			InitializeComponent();
			List<TypeOfInsurance>  TypesOfInsurance = _database.TypesOfInsurances.Where(t=>t.Hide == false).Select(x => x).ToList();
			ListTypeOfInsutrance.ItemsSource = TypesOfInsurance;
			ListTypeOfInsutrance.DisplayMemberPath = "Name";
		}

		private void ListTypeOfInsutrance_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var item = (TypeOfInsurance)ListTypeOfInsutrance.SelectedItem;
			NameText.Text = item.Name;
			DescriprionText.Text = item.Descriprion;
			CostText.Text = item.CostOfTheInsuranceContract.ToString();
			InsuranceAmount.Text = item.InsuranceAmount.ToString();
			FirstBox.SelectedItem = item.IncludedRisks;
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			if (ListTypeOfInsutrance.SelectedItem != null)
			{
				var type = (TypeOfInsurance)ListTypeOfInsutrance.SelectedItem;

				_database.TypesOfInsurances.Update(type);
				_database.SaveChanges();
			}
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			var type = (TypeOfInsurance)ListTypeOfInsutrance.SelectedItem;
			type.Hide = true;

			_database.TypesOfInsurances.Update(type);
			_database.SaveChanges();
		}

		private void RebootButton_Click(object sender, RoutedEventArgs e)
		{
			ListTypeOfInsutrance.ItemsSource = _database.TypesOfInsurances.Where(t => t.Hide == false).Select(x => x).ToList();
		}
	}
}
