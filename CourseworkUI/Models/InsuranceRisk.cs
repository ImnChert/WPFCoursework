using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseworkUI.Models
{
	public class InsuranceRisk : INotifyPropertyChanged
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<TypeOfInsurance> ConnectedTypesOfInsurance { get; } = new List<TypeOfInsurance>();

		public InsuranceRisk(string name)
		{
			Name = name;
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
