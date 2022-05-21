using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for ChartWindow.xaml
	/// </summary>
	public partial class ChartWindow : Window
	{
		private List<(object, object)> _list = new List<(object, object)>();
		private string _type;

		public ChartWindow(string type, List<(object, object)> list)
		{
			_list = list;
			_type = type;
			InitializeComponent();
		}

		private void wf_Loaded(object sender, RoutedEventArgs e)
		{
			if (_type == "font")
			{
				chart.ChartAreas.Add(new ChartArea("Default"));
				chart.Titles.Add("Chart");
				chart.Titles[0].Font = new Font("Utopia", 16);

				chart.Series.Add(new Series("ColumnSeries")
				{
					ChartType = SeriesChartType.Pie
				});

				var values = new List<double>();
				var name = new List<string>();

				foreach ((object, object) item in _list)
				{
					name.Add((string)item.Item1);
					values.Add((double)item.Item2);
				}

				chart.Series["ColumnSeries"].Points.DataBindXY(name, values);

				chart.ChartAreas[0].Area3DStyle.Enable3D = true;
			}
			else if (_type == "lines")
			{
				var name = new List<string>();
				var salary = new List<double>();
				var profit = new List<double>();

				foreach ((object, object) item in _list)
				{
					var agent = ((string, double))item.Item1;
					chart.Series.Add(agent.Item1);

					chart.Series[agent.Item1].Color = Color.FromArgb(
																		255 - (int)agent.Item2 % 255,
																		(int)item.Item2 % 255,
																		255 - ((int)agent.Item2 + (int)item.Item2) % 255
																	);
					chart.Series[agent.Item1].ChartType = SeriesChartType.Line;
					chart.Series[agent.Item1].LegendText = agent.Item1;
					chart.Series[agent.Item1].Points.AddXY(0, 0);
					chart.Series[agent.Item1].Points.AddXY(agent.Item2, (double)item.Item2);
				}
			}
		}
	}
}
