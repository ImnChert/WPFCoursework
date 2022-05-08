using CourseworkUI.Models.Users.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Clients
{
	[Table("NaturalPersons")]
	public class NaturalPerson : Client
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }

		public NaturalPerson(string username, string password, string firstName, string lastName, string middleName, string address)
			: base(username, password, address)

		{
			FirstName = firstName;
			LastName = lastName;
			MiddleName = middleName;
		}

		public override string? ToString() => "NaturalPerson";
	}
}
