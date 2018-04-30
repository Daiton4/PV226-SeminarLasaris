using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Album : IEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		[NotMapped]
		public string TableName { get; } = nameof(MusicLibraryDbContext.Albums);

		[MaxLength(64)]
		public string Name { get; set; }

		[MaxLength(64)]
		public string Cover { get; set; }

		public DateTime ReleaseDate { get; set; }

		[ForeignKey(nameof(Genre))]
		public Guid GenreId { get; set; }

		public virtual Genre Genre { get; set; }

		[ForeignKey(nameof(Artist))]
		public Guid ArtistId { get; set; }

		public virtual Artist Artist { get; set; }
	}
}
