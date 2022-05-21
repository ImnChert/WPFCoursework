using CourseworkUI.Services;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;
using CourseworkUI.Models;
using System;

namespace CourseworkUI.Pages.EconomistPages
{
	/// <summary>
	/// Interaction logic for AddTypeOfInsurancePage.xaml
	/// </summary>
	public partial class AddTypeOfInsurancePage : Page
	{
		private ApplicationContext _db = new ApplicationContext();

		public AddTypeOfInsurancePage()
		{
			InitializeComponent();
			ListAllRisk.ItemsSource = Fill();
			ListAllRisk.DisplayMemberPath = "Name";
			ListAddRisk.DisplayMemberPath = "Name";
		}

		private List<InsuranceRisk> Fill()
			=> _db.InsuranceRisks.Select(r => r).ToList();
		

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			// TODO: добавить проверки
			string name = NameTextBox.Text;
			string description = DescriptionTextBox.Text;
			decimal cost = Convert.ToDecimal(CoastTextBox.Text);
			decimal insuranceAmount = Convert.ToDecimal(InsuranceAmountTextBox.Text);
			string type = TypeComboBox.SelectedIndex == 0 ? "Natural" : "Legal";

			var typeOfInsurance = new TypeOfInsurance(name, description, insuranceAmount, cost, type);
			typeOfInsurance.IncludedRisks = (ICollection<InsuranceRisk>)ListAddRisk.ItemsSource;
			// TODO: не хочет присваивать элементы
			_db.TypesOfInsurances.Add(typeOfInsurance);
			_db.SaveChanges();
		}

		private void AddListButton_Click(object sender, RoutedEventArgs e)
		{
			if (ListAllRisk.SelectedItem != null)
			{
				ListAddRisk.Items.Add(ListAllRisk.SelectedItem);
				//ListAllRisk.Items.Remove(ListAllRisk.SelectedItem);
			}
		}

		private void RemoveListButton_Click(object sender, RoutedEventArgs e)
		{
			if (ListAddRisk.SelectedItem != null)
			{
				ListAllRisk.Items.Add(ListAddRisk.SelectedItem);
				//ListAddRisk.Items.Remove(ListAddRisk.SelectedItem);
			}
		}

		private void RebootButton_Click(object sender, RoutedEventArgs e)
			=> ListAllRisk.ItemsSource = Fill();
	}
}
