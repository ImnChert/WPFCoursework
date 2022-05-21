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

namespace CourseworkUI.Pages.ManagerPages
{
	/// <summary>
	/// Interaction logic for StatisticsPage.xaml
	/// </summary>
	public partial class StatisticsPage : Page
	{
		private ApplicationContext _db = new ApplicationContext();

		public StatisticsPage()
		{
			InitializeComponent();
		}

		private void CustomerInformationButten_Click(object sender, RoutedEventArgs e)
		{
			var customer = _db.Clients.Select(c => c)
									  .ToList();

			var list = new List<(object, object)>();

			customer.GroupBy(c => c.ToString())
									  .Where(c => c.Key != null)
									  .Select(c => new
									  {
										  Key = c.Key,
										  Count = c.Count()
									  })
									  .ToList()
									  .ForEach(c => list.Add((c.Key, Convert.ToDouble(c.Count))));



			var window = new ChartWindow("font", list);
			window.ShowDialog();
		}

		private void PopularityInformationButten_Click(object sender, RoutedEventArgs e)
		{
			var polices = _db.Polices.Select(t => t)
											.ToList();

			var list = new List<(object, object)>();

			polices.GroupBy(p => p.TypeOfInsurance)
				   .ToList()
				   .ForEach(c => list.Add((c.Key, Convert.ToDouble(c.Count()))));

			var window = new ChartWindow("font", list);
			window.ShowDialog();
		}

		private void ProductivityInformationButten_Click(object sender, RoutedEventArgs e)
		{
			var polices = _db.Polices.Select(t => t)
											.ToList();

			var list = new List<(object, object)>();

			polices.GroupBy(p => p.InsuranceAgent)
				   .ToList()
				   .ForEach(c => list.Add(
					   (
						   ($"{c.Key.FirstName} {c.Key.MiddleName} {c.Key.LastName}", Convert.ToDouble(c.Key.Salary)),
						   Convert.ToDouble(c.Sum(p => p.CostOfTheInsuranceContract - p.AmountPaid))
				   )));

			var window = new ChartWindow("lines", list);
			window.ShowDialog();
		}
	}
}
