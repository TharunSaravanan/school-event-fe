using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolEventWeb.Data
{
	public class Point
	{
		public int Id { get; set; }

		[Required]
		public int EventId { get; set; }

		[Required]
		public int StudentId { get; set; }

		[Required]
		public int StudentGrade { get; set; }

		[Required]
		public bool IsParticipant { get; set; }

		[Required]
		public int Points { get; set; }

		public Point()
		{
		}
	}
}

