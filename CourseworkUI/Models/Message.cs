using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models
{
	[Table("Messages")]
	[Keyless]
	public class Message
	{
		public string FromUsername { get; set; }
		public string ToUsername { get; set; } 
		public string Text { get; set; }
		public DateTime DateOfDispatch { get; set; }

		public Message(string fromUsername, string toUsername, string text, DateTime dateOfDispatch)
		{
			FromUsername = fromUsername;
			ToUsername = toUsername;
			Text = text;
			DateOfDispatch = dateOfDispatch;
		}
	}
}
