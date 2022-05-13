using CourseworkUI.Pages;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace CourseworkUI.ViewModels
{
	internal class InsuranceAgentViewModel : ViewModelBase
	{
		private Page _message = new MessagerPage();
		private Page _createMessage = new CreateMessagePage();
		private Page _curPage = new MessagerPage()!;

		public Page CurPage
		{
			get => _curPage;
			set => Set(ref _curPage, value);
		}

		public ICommand OpenMessagePage
			   => new RelayCommand(() => CurPage = _message);
		public ICommand OpenCreateMessagePage
			   => new RelayCommand(() => CurPage = _createMessage);
	}
}
