using CourseworkUI.Services;

namespace CourseworkUI.Interfaces
{
	internal interface IApplicationContext
	{
		public ApplicationContext DataBase { get; }
	}
}
