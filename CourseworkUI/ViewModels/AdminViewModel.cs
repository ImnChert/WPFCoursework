using CommunityToolkit.Mvvm.Input;
using CourseworkUI.Pages.AdminPages;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseworkUI.ViewModels
{
	internal class AdminViewModel : ViewModelBase
	{
		private Page _addEmployeePage = new AddEmployeePage();
		private Page _changeEmployeePage = new ChangeEmployeePage();
		private Page _curPage = null;
		
		public Page CurPage
		{
			get => _curPage;
			set => Set(ref _curPage, value);
		}

		public ICommand OpenAddEmployeePage
			=> new RelayCommand(() => CurPage = _addEmployeePage);
		public ICommand OpenChangeEmployeePage
			=> new RelayCommand(() => CurPage = _changeEmployeePage);
	}
}
