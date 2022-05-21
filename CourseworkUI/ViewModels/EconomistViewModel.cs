using CommunityToolkit.Mvvm.Input;
using CourseworkUI.Pages.EconomistPages;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseworkUI.ViewModels
{
	internal class EconomistViewModel : ViewModelBase
	{
		private Page _changeCostPage = new ChangeCostPage();
		private Page _addTypeOfInsurancePage = new AddTypeOfInsurancePage();
		private Page _addInsuranceRiskButton  = new AddInsuranceRiskPage();
		private Page _curPage = new ChangeCostPage();

		public Page CurPage
		{
			get => _curPage;
			set => Set(ref _curPage, value);
		}

		public ICommand OpenChangeCostPage
			=> new RelayCommand(() => CurPage = _changeCostPage);
		public ICommand OpenAddTypeOfInsurancePage
			=> new RelayCommand(() => CurPage = _addTypeOfInsurancePage);
		public ICommand OpenAddInsuranceRiskPage
			=> new RelayCommand(() => CurPage = _addInsuranceRiskButton);
	}
}
