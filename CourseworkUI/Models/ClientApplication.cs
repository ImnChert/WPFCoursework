using CourseworkUI.Models.Employees;
using CourseworkUI.Models.Users.Clients;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CourseworkUI.Models
{
	[Table("ClientApplications")]
	public class ClientApplication : INotifyPropertyChanged
	{
		public int Id { get; set; }
		public virtual Client Client { get; set; } = null!;
		public virtual InsuranceAgent InsuranceAgent { get; set; } = null!;
		public virtual TypeOfInsurance TypeOfInsurance { get; set; } = null!;

		public event PropertyChangedEventHandler? PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
