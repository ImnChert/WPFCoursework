
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

namespace CourseworkUI.Pages
{
	/// <summary>
	/// Interaction logic for CreateMessagePage.xaml
	/// </summary>
	public partial class CreateMessagePage : Page
	{
		private int _fromId = 0;
		private ApplicationContext _db = new ApplicationContext();

		public CreateMessagePage()
		{
			var window = Application.Current.Windows[0];

			if (window is ClientWindow clientWindow)
				_fromId = clientWindow.Client.Id;
			else if (window is InsuranceAgentWindow insuranceAgent)
				_fromId = insuranceAgent.InsuranceAgent.Id;

			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(TextBox.Text != "")
			{
				var message = new Message(_fromId, Convert.ToInt32(ToTextBox.Text), TextBox.Text, DateTime.Now);

				_db.Messages.Add(message);
				_db.SaveChanges();
			}

			// TODO: проверку
		}
	}
}
