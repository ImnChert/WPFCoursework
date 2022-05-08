using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Employees
{
	[Table("Managers")]
	public class Manager : Employee
	{
		public Manager(string username, string password, string firstName, string lastName, string middleName)
			: base(username, password, firstName, lastName, middleName)
		{
		}
	}
}
