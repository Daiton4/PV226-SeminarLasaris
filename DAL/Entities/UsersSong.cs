using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class UsersSong : IEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		[NotMapped]
		public string TableName { get; } = nameof(MusicLibraryDbContext.UsersSongs);

		[ForeignKey(nameof(Song))]
		public Guid SongId { get; set; }

		public virtual Song Song { get; set; }

		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }

		public virtual User User { get; set; }
	}
}
