using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolEventWeb.Data
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		public int Email { get; set; }

		[Required]
		public int Password { get; set; }

		[Required]
		public int Type { get; set; }

		public User()
		{
		}
	}
}

