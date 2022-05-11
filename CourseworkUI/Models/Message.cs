using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseworkUI.Models
{
	[Table("Messages")]
	[Keyless]
	public class Message
	{
		public int FromId { get; set; }
		public int ToId { get; set; } 
		public string Text { get; set; }
		public DateTime DateOfDispatch { get; set; }
		public string FromType { get; set; }

		public Message(int fromId, int toId, string text, DateTime dateOfDispatch, string fromType)
		{
			FromId = fromId;
			ToId = toId;
			Text = text;
			DateOfDispatch = dateOfDispatch;
			FromType = fromType;
		}
	}
}
