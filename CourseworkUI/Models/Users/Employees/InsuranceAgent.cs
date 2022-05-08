using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Employees
{
	[Table("InsuranceAgents")]
	public class InsuranceAgent : Employee
	{
		public InsuranceAgent(string username, string password, string firstName, string lastName, string middleName)
			: base(username, password, firstName, lastName, middleName)
		{
		}
	}
}
