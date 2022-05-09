using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Users.Clients
{
	[Table("Client")]
	public class Client : User
	{
		public string Locality { get; set; }
		public string HouseNumber { get; set; }

		public Client(string username, string password, string locality, string houseNumber)
			: base(username, password)
		{
			Locality = locality;
			HouseNumber = houseNumber;	
		}

		public override string? ToString() => "Client";
	}
}
