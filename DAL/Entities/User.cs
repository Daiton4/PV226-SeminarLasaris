using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
	public class User : IEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		[NotMapped]
		public string TableName { get; } = nameof(MusicLibraryDbContext.Users);

		[MaxLength(64)]
		public string FirstName { get; set; }

		[MaxLength(64)]
		public string LastName { get; set; }

		[EmailAddress]
		public string Email { get; set; }
		
		public bool Admin { get; set; }

		[Phone]
		public string MobilePhoneNumber { get; set; }

		[MaxLength(1024)]
		public string Address { get; set; }
	}
}
