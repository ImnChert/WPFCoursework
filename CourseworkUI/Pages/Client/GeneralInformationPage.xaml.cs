using CourseworkUI.Models;
using CourseworkUI.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Controls;

namespace CourseworkUI.Pages.Client
{
	/// <summary>
	/// Interaction logic for GeneralInformationPage.xaml
	/// </summary>
	public partial class GeneralInformationPage : Page
	{
		private ApplicationContext _db = new ApplicationContext();

		public GeneralInformationPage()
		{
			InitializeComponent();
			CreateViews();
		}

		private void CreateViews()
		{
			var views = _db.TypesOfInsurances.Include(p => p.IncludedRisks).Take(4).ToList();

			AddText(FirstText, FirstBox, views[0]);
			AddText(SecondText, SecondBox, views[1]);
			AddText(ThirdText, ThirdBox, views[2]);
			AddText(FourtText, FourthBox, views[3]);
		}

		private void AddText(TextBlock textBlock, TextBox textBox, TypeOfInsurance typeOfInsurance)
		{
			textBlock.Text = typeOfInsurance.Name;
			textBox.Text = typeOfInsurance.Descriprion;
		}
	}
}
