using CourseworkUI.Interfaces;
using CourseworkUI.Models.Users.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Employees
{
	[Table("InsuranceAgents")]
	public class InsuranceAgent : Employee 
	{
		public InsuranceAgent(string username, string password, string firstName, string lastName, string middleName, decimal salary)
			: base(username, password, firstName, lastName, middleName, salary)
		{
		}
	}
}
