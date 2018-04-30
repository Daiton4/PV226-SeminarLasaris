using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class UsersAlbum : IEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		[NotMapped]
		public string TableName { get; } = nameof(MusicLibraryDbContext.UsersAlbums);

		[ForeignKey(nameof(Album))]
		public Guid AlbumId { get; set; }

		public virtual Album Album { get; set; }

		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }

		public virtual User User { get; set; }
	}
}
