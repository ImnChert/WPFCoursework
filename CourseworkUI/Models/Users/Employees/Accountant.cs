using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Employees
{
	[Table("Accountants")]
	public class Accountant : Employee
	{
		public string S { get; set; }
		public Accountant(string username, string password, string firstName, string lastName, string middleName, string s)
			: base(username, password, firstName, lastName, middleName)
		{
			S = s;
		}
	}
}
