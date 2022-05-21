using CourseworkUI.Models.Employees;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Users.Employees
{
	[Table("Economists")]
	public class Economist : Employee
	{
		public Economist(string username, string password, string firstName, string lastName, string middleName, decimal salary)
		: base(username, password, firstName, lastName, middleName, salary)
		{
		}

		public override string? ToString() => "Economist";
	}
}
