using CommunityToolkit.Mvvm.Input;
using CourseworkUI.Pages.ManagerPages;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseworkUI.ViewModels
{
	internal class ManagerViewModel : ViewModelBase
	{
		private Page _statisticsPage = new StatisticsPage();
		private Page _reportsPage = new ReportsPage();
		private Page _curPage = new StatisticsPage();

		public Page CurPage
		{
			get => _curPage;
			set => Set(ref _curPage, value);
		}

		public ICommand OpenStatisticsPage
			=> new RelayCommand(() => CurPage = _statisticsPage);
		public ICommand OpenReportsPage
			=> new RelayCommand(() => CurPage = _reportsPage);
	}
}
