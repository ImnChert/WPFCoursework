using CommunityToolkit.Mvvm.Input;
using CourseworkUI.Pages.ClientInforamtionPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseworkUI.ViewModels
{
	internal class ClientInformationViewModel : ViewModelBase
	{
		private Page _naturalPersonInformationPage = new NaturalPersonInformationPage();
		private Page _legalPersonInformationPage = new LegalPersonInformationPage();
		private Page _curPage = new NaturalPersonInformationPage();

		public Page CurPage
		{
			get => _curPage;
			set => Set(ref _curPage, value);
		}

		public ICommand OpenNaturalPersonInformationPage
			=> new RelayCommand(() => CurPage = _naturalPersonInformationPage);
		public ICommand OpenLegalPersonInformationPage
			=> new RelayCommand(() => CurPage = _legalPersonInformationPage);
	}
}
