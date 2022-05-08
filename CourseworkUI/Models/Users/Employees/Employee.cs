﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Employees
{
	[Table("Employees")]
	public class Employee : User
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }

		public Employee(string username, string password, string firstName, string lastName, string middleName)
			: base(username, password)
		{
			FirstName = firstName;
			LastName = lastName;
			MiddleName = middleName;
		}
	}
}