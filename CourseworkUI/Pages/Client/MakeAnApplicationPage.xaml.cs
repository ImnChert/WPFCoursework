using CourseworkUI.Models;
using CourseworkUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CourseworkUI.Pages.Client
{
	/// <summary>
	/// Interaction logic for MakeAnApplicationPage.xaml
	/// </summary>
	public partial class MakeAnApplicationPage : Page
	{
		private ApplicationContext _db = new ApplicationContext();
		public List<TypeOfInsurance> TupesOfInsurance { get; set; }

		public MakeAnApplicationPage()
		{
			InitializeComponent();
			TupesOfInsurance = _db.TypesOfInsurances.Select(x=>x).ToList();
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
	}
}
