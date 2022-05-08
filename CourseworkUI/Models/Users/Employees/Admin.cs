using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Employees
{
	[Table("Admins")]
	public class Admin : Employee
	{
		public Admin(string username, string password, string firstName, string lastName, string middleName)
			: base(username, password, firstName, lastName, middleName)
		{
		}
	}
}
