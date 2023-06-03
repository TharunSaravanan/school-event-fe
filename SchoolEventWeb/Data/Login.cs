using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolEventWeb.Data
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		public String Email { get; set; }

		[Required]
		public String Password { get; set; }

		[Required]
		public String Type { get; set; }

		public User()
		{
		}
	}
}

