using CourseworkUI.Models;
using CourseworkUI.Models.Clients;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 

namespace CourseworkUI.Pages.Client
{
	/// <summary>
	/// Interaction logic for GeneralInformationPage.xaml
	/// </summary>
	public partial class GeneralInformationPage : Page
	{
		private ApplicationContext _database = new ApplicationContext();
		private User _client;

		public GeneralInformationPage()
		{
			InitializeComponent();

			// TODO: бред
			var window = Application.Current.Windows[0];
			if (window is not ClientWindow)
				window = Application.Current.Windows[2];
			var s = (ClientWindow)window;
			_client = s.Client;
			CreateViews();
			InitializeComponent();
		}

		private void CreateViews()
		{
			List<TypeOfInsurance> views = new List<TypeOfInsurance>();

			if( _client is NaturalPerson )
			{
				views = _database.TypesOfInsurances.Where(x => x.Type == "Natural").Include(p => p.IncludedRisks).Take(4).ToList();
			}
			else if( _client is LegalPerson )
			{
				views = _database.TypesOfInsurances.Where(x => x.Type == "Legal").Include(p => p.IncludedRisks).Take(4).ToList();
			}
			 
			// TODO: убрать коммент

			//AddText(FirstText, FirstBox, views[0]);
			//AddText(SecondText, SecondBox, views[1]);
			//AddText(ThirdText, ThirdBox, views[2]);
			//AddText(FourtText, FourthBox, views[3]);
		}

		private void AddText(TextBlock textBlock, TextBox textBox, TypeOfInsurance typeOfInsurance)
		{
			textBlock.Text = typeOfInsurance.Name;
			textBox.Text = typeOfInsurance.Descriprion;
		}
	}
}
