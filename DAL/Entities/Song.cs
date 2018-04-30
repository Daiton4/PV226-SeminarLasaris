using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Song : IEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		[NotMapped]
		public string TableName { get; } = nameof(MusicLibraryDbContext.Songs);

		[MaxLength(64)]
		public string Name { get; set; }

		[ForeignKey(nameof(Album))]
		public Guid AlbumId { get; set; }

		public virtual Album Album { get; set; }
	}
}
