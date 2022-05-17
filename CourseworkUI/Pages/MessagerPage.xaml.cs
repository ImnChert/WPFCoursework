using CourseworkUI.Models;
using CourseworkUI.Services;
using CourseworkUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseworkUI.Pages
{
	/// <summary>
	/// Interaction logic for MessagerPage.xaml
	/// </summary>
	public partial class MessagerPage : Page
	{
		private User _user = null!;
		private ApplicationContext _db = new ApplicationContext();

		public MessagerPage()
		{
			var window = Application.Current.Windows[2];

			if (window is ClientWindow clientWindow)
				_user = clientWindow.Client;
			else if (window is InsuranceAgentWindow insuranceAgent)
				_user = insuranceAgent.InsuranceAgent;

			 

			InitializeComponent();
			
			ListMessage.ItemsSource = _db.Messages.Where(m => m.FromUsername == _user.Username)
										.OrderByDescending(m => m.DateOfDispatch)
										.ToList();
			ListMessage.DisplayMemberPath = "ToUsername";

		}

		private void CreateMessageButton_Click(object sender, RoutedEventArgs e)
		{
			var window = Application.Current.Windows[0];

			if (window is ClientWindow clientWindow)
				clientWindow.ViewModel.OpenCreateMessagePage.Execute("");
			else if (window is InsuranceAgentWindow insuranceAgent)
				insuranceAgent.ViewModel.OpenCreateMessagePage.Execute("");
		}
		

		private Dictionary<string,Action> GetDictionary()
		{
			return new Dictionary<string, Action>
			{
				{"Client", ()=>{
					var window = (ClientWindow)Application.Current.Windows[0];
					window.ViewModel.OpenCreateMessagePage.Execute("");
					}
				},
				{"InsuranceAgent", ()=>{
					var window = (InsuranceAgentWindow)Application.Current.Windows[0];
					window.ViewModel.OpenCreateMessagePage.Execute("");
					}
				}
			};
		}

		private void OutgoingButton_Click(object sender, RoutedEventArgs e)
		{
			ListMessage.ItemsSource = _db.Messages.Where(m => m.FromUsername == _user.Username)
									.OrderByDescending(m => m.DateOfDispatch)
									.ToList();
			OutgoingButton.IsEnabled = false;
			IncomingButton.IsEnabled = true;
			ListMessage.DisplayMemberPath = "ToUsername";
		}

		private void IncomingButton_Click(object sender, RoutedEventArgs e)
		{
			ListMessage.ItemsSource = _db.Messages.Where(m => m.ToUsername == _user.Username)
									.OrderByDescending(m => m.DateOfDispatch)
									.ToList();
			IncomingButton.IsEnabled = false;
			OutgoingButton.IsEnabled = true;
			ListMessage.DisplayMemberPath = "FromUsername";
			
		}

		private void ListMessage_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var message = (Message)ListMessage.SelectedItem;
			TextBox.Text = message.Text;
		}
	}
}
