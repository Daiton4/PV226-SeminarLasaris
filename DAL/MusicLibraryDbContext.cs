using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class MusicLibraryDbContext : DbContext
	{
		private const string ConnectionString = "Data source=(localdb)\\mssqllocaldb;Database=MusicLibraryDbContext;Trusted_Connection=True;MultipleActiveResultSets=true";

		public MusicLibraryDbContext() : base(ConnectionString)
        {
			Database.SetInitializer(new DatabaseInitializer());
		}

		public MusicLibraryDbContext(DbConnection connection) : base(connection, true)
        {
			Database.CreateIfNotExists();
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<Artist> Artists { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Song> Songs { get; set; }
		public DbSet<UsersAlbum> UsersAlbums { get; set; }
		public DbSet<UsersSong> UsersSongs { get; set; }
		public DbSet<UsersArtist> UsersArtists { get; set; }

	}
}
