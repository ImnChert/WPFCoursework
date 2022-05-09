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
		public string ApartmentNumber { get; set; }

		public NaturalPerson(string username, string password, string firstName, string lastName, string middleName, string locality, string houseNumber, string apartmentNumber)
			: base(username, password, locality,houseNumber)

		{
			FirstName = firstName;
			LastName = lastName;
			MiddleName = middleName;
			ApartmentNumber = apartmentNumber;
		}

		public override string? ToString() => "NaturalPerson";
	}
}
