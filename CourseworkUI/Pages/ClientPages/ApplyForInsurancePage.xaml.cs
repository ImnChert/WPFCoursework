using CourseworkUI.Models;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using System.Windows;
using System.Windows.Controls;
 

namespace CourseworkUI.Pages.Client
{
	/// <summary>
	/// Interaction logic for ApplyForInsurancePage.xaml
	/// </summary>
	public partial class ApplyForInsurancePage : Page
	{
		private TypeOfInsurance _typeOfInsurance = null;
		private ApplicationContext _db = new ApplicationContext();

		public ApplyForInsurancePage()
		{
			InitializeComponent();
			var window = Application.Current.Windows[0];
			if (window is not ClientWindow)
				window = Application.Current.Windows[2];
			var s = (ClientWindow)window;
			_typeOfInsurance = s.TypeOfInsurance;

			Fill();

			// TODO: рефакторинг
		}

		private void Fill()
		{
			ComboBox1.Text = _typeOfInsurance.Name;
			InsuranceAmountTextBox.Text = _typeOfInsurance.InsuranceAmount.ToString();
			CostOfTheInsuranceContractTextBox.Text = _typeOfInsurance.CostOfTheInsuranceContract.ToString();
		}
	}
}
