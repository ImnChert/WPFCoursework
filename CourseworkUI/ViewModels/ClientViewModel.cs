using CourseworkUI.Pages.Client;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using CourseworkUI.Pages;
using CourseworkUI.Pages.ClientPages;

namespace CourseworkUI.ViewModels
{
	internal class ClientViewModel : ViewModelBase
	{
		private Page _generalInformationPage = new GeneralInformationPage();
		private Page _makeAnApplicationPage = new MakeAnApplicationPage();
		private Page _accountPage = new AccountPage();
		public Page _applyForInsurancePage = new ApplyForInsurancePage();
		public Page Message = new MessagerPage();
		public Page CreateMessage = new CreateMessagePage();
		private Page _policesPage = new IssuedPoliciesPage();
		private Page _curPage = new GeneralInformationPage();

		public Page CurPage
		{
			get => _curPage;
			set => Set(ref _curPage, value);
		}

		public ICommand OpenGeneralInformationPage
			=> new RelayCommand(() => CurPage = _generalInformationPage);
		public ICommand OpenMakeAnApplicationPage
			=> new RelayCommand(() => CurPage = _makeAnApplicationPage);
		public ICommand OpenAccountPage
			=> new RelayCommand(() => CurPage = _accountPage);
		public ICommand OpenApplyForInsurancePage
			   => new RelayCommand(() => CurPage = _applyForInsurancePage);
		public ICommand OpenMessagePage
			   => new RelayCommand(() => CurPage = Message);
		public ICommand OpenCreateMessagePage
			   => new RelayCommand(() => CurPage = CreateMessage);
		public ICommand OpenIssuedPoliciesPage
			   => new RelayCommand(() => CurPage = _policesPage);
	}
}
