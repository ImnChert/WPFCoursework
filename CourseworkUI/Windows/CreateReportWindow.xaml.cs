using System.Collections.Generic;
using System.Windows;

namespace CourseworkUI.Windows
{
	/// <summary>
	/// Interaction logic for CreateReportWindow.xaml
	/// </summary>
	public partial class CreateReportWindow : System.Windows.Window
	{
		public CreateReportWindow()
		{
			InitializeComponent();
		}

		public void Create<T>(List<T> list)
		{
			ReportDataGrid.ItemsSource = list;
			this.ShowDialog();
		}

		private void ExportButton_Click(object sender, RoutedEventArgs e)
		{
			//var workbook = new XLWorkbook();
			//workbook.AddWorksheet("sheetName");
			//var ws = workbook.Worksheet("sheetName");
			//ws.ColumnWidth = 170;

			//var headerList = new List<string>();

			//for (int i = 0; i < ReportDataGrid.Columns.Count; i++)
			//{
			//	headerList.Add((string)ReportDataGrid.Columns[i].Header);

			//}


			//string[] letterArr = { "A", "B", "C", "D", "E", "F", "G" };

			//for(int i = 0; i < headerList.Count; i++)
			//{
			//	ws.Cell(letterArr[i] + 1).Value = headerList[i];
			//}

			//int row = 2;

			//for (int i = 0; i < headerList.Count; i++)
			//{
			//	ws.Cell(letterArr[i] + 1).Value = headerList[i];
			//}

			/////////////////////////////////////////////////////////////////
			//ReportDataGrid.Columns[1].

			//foreach (var item in ReportDataGrid.Items)
			//{
			//	for (int i = 0; i < headerList.Count; i++)
			//	{
			//		ws.Cell(letterArr[i] + 1).Value = headerList[i];
			//	}

			//	ws.Cell("A" + row.ToString()).Value = item.ToString();
			//	row++;
			//}

			//workbook.SaveAs("yourExcel.xlsx");
		}
	}
}
