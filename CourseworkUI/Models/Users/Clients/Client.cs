using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Users.Clients
{
	[Table("Client")]
	public class Client : User
	{
		public string Address { get; set; }

		public Client(string username, string password, string address)
			: base(username, password)
		{
			Address = address;
		}

		public override string? ToString() => "Client";
	}
}
