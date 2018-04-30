using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class UsersArtist : IEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		[NotMapped]
		public string TableName { get; } = nameof(MusicLibraryDbContext.UsersSongs);

		[ForeignKey(nameof(Artist))]
		public Guid ArtistId { get; set; }

		public virtual Artist Artist { get; set; }

		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }

		public virtual User User { get; set; }
	}
}
