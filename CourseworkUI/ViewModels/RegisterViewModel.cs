using CommunityToolkit.Mvvm.Input;
using CourseworkUI.Pages.Register;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseworkUI.ViewModels
{
	public class RegisterViewModel : ViewModelBase
	{
		private Page _naturalPersonPage = new NaturalPersonPage();
		private Page _legalPersonPage = new LegalPersonPage();
		private Page _curPage = new NaturalPersonPage();

		public Page CurPage
		{
			get => _curPage;
			set => Set(ref _curPage, value);
		}
		public ICommand OpenNaturalPersonPage
		{
			get
			{
				return new RelayCommand(() => CurPage = _naturalPersonPage);
			}
		}
		public ICommand OpenLegalPersonPage
		{
			get
			{
				return new RelayCommand(() => CurPage = _legalPersonPage);
			}
		}
	}
}
