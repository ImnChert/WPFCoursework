using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Employees
{
	[Table("Accountants")]
	public class Accountant : Employee
	{
		public Accountant(string username, string password, string firstName, string lastName, string middleName, decimal salary)
			: base(username, password, firstName, lastName, middleName, salary)
		{
			
		}
	}
}
