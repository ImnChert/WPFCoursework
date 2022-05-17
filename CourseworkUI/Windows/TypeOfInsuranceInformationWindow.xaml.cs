using CourseworkUI.Models;
using System.Windows;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for TypeOfInsuranceInformationWindow.xaml
	/// </summary>
	public partial class TypeOfInsuranceInformationWindow : Window
	{
		public TypeOfInsuranceInformationWindow(TypeOfInsurance typeOfInsurance)
		{
			InitializeComponent();
			Fill(typeOfInsurance);
		}

		private void Fill(TypeOfInsurance typeOfInsurance)
		{

		}
	}
}
