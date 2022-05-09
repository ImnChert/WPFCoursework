using CourseworkUI.Models.Users.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Clients
{
	[Table("LegalPersons")]
	public class LegalPerson : Client
	{
		public string NameOfOrganization { get; set; }

		public LegalPerson(string username, string password, string nameOfOrganization, string locality, string houseNumber)
			: base(username, password, locality, houseNumber)
		{
			NameOfOrganization = nameOfOrganization;
		}

		public override string? ToString() => "LegalPerson";
	}
}
