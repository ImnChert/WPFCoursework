
using CourseworkUI.Models.Users.Employees;
using CourseworkUI.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models.Employees
{
	[Table("Admins")]
	public class Admin : Employee
	{
		public Admin(string username, string password, string firstName, string lastName, string middleName, decimal salary)
			: base(username, password, firstName, lastName, middleName, salary)
		{
		}

		public void DeleteUser(ApplicationContext db, User user)
		{ 
			user.Hide = true;
			db.Users.Update(user);
			db.SaveChanges();
		}

		public void AddEmployee(ApplicationContext db, string username, string password, string firstName, string lastName, string middleName, string post, decimal salary)
		{
			Employee employee = GetEmployee(username, password, firstName, lastName, middleName, post, salary);
			db.Employees.Add(employee);
			db.SaveChanges();
		}

		public void ChangeEmployee(ApplicationContext db, Employee employee, string firstName, string lastName, string middleName)
		{
			employee.FirstName = firstName;
			employee.LastName = lastName;
			employee.MiddleName = middleName;

			db.Employees.Update(employee);
			db.SaveChanges();
		}

		private Employee GetEmployee(string username, string password, string firstName, string lastName, string middleName, string post, decimal salary)
		{
			Dictionary<string, Employee> employees = new Dictionary<string, Employee>()
			{
				{ "Insurance agent", new InsuranceAgent(username, password, firstName, lastName, middleName, salary)},
				{ "Accountant", new Accountant(username, password, firstName, lastName, middleName, salary)},
				{ "Economist", new Economist(username, password, firstName, lastName, middleName, salary)},
				{ "Manager", new Manager(username, password, firstName, lastName, middleName, salary)},
				{ "Admin", new Admin(username, password, firstName, lastName, middleName, salary)},

			};

			return employees[post];
		}

		public override string? ToString() => "Admin";
	}
}
