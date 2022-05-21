using CommunityToolkit.Mvvm.Input;
using CourseworkUI.Pages.AccountantPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseworkUI.ViewModels
{
	internal class AccountantViewModel : ViewModelBase
	{
		private Page _changeSalaryPage = new ChangeSalaryPage();
		private Page _reportsPage = new ReportsPage();
		private Page _curPage = new ChangeSalaryPage();

		public Page CurPage
		{
			get => _curPage;
			set => Set(ref _curPage, value);
		}

		public ICommand OpenChangeSalaryPage
			=> new RelayCommand(() => CurPage = _changeSalaryPage);
		public ICommand OpenReportsPage
			=> new RelayCommand(() => CurPage = _reportsPage);
	
	}
}
