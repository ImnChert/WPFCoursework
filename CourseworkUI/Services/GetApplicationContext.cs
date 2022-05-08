using CourseworkUI.Interfaces;
using System.Windows;

namespace CourseworkUI.Services
{
	internal static class GetApplicationContext
	{
		public static ApplicationContext GetAppContext()
		{
			foreach (var item in Application.Current.Windows)
			{
				if (item is IApplicationContext a)
					return a.DataBase;
			}

			return null;
		}
	}
}
