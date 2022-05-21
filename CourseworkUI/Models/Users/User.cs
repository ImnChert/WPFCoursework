using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseworkUI.Models
{
	public abstract class User : INotifyPropertyChanged
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public bool Hide { get; set; } = false;

		public User(string username, string password)
		{
			Username = username;
			Password = password;
		}

		

		public event PropertyChangedEventHandler? PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

		public override bool Equals(object? obj)
		{
			return obj is User user &&
				   Username == user.Username &&
				   Password == user.Password &&
				   Hide == user.Hide;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Username, Password, Hide);
		}
	}
}
