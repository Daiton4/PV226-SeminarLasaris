using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class DatabaseInitializer : DropCreateDatabaseAlways<MusicLibraryDbContext>
	{
		protected override void Seed(MusicLibraryDbContext context)
		{
			var metal = new Genre { Id = Guid.NewGuid(), Name = "Metal" };

			var pop = new Genre { Id = Guid.NewGuid(), Name = "Pop" };

			var electronic = new Genre { Id = Guid.NewGuid(), Name = "Electronic" };

			context.Genres.AddOrUpdate(genre => genre.Id, metal, pop, electronic);


			var taylor = new Artist { Id = Guid.NewGuid(), Name = "Taylor Swift" };

			var crown = new Artist { Id = Guid.NewGuid(), Name = "Aversions Crown" };

			var infant = new Artist { Id = Guid.NewGuid(), Name = "Infant Annihilator" };

			context.Artists.AddOrUpdate(artist => artist.Id, taylor, crown, infant);		
			

			var admin = new User { Id = Guid.NewGuid(), Address = "None 1", Admin = true, Email = "heh@meh.nah", FirstName = "Real", LastName = "Administrator", MobilePhoneNumber = "+456" };

			var pleb = new User { Id = Guid.NewGuid(), Address = "Everywhere 6", Admin = false, Email = "nwm@whtevr.lol", FirstName = "Random", LastName = "Pleb", MobilePhoneNumber = "221306" };

			context.Users.AddOrUpdate(user => user.Id, admin, pleb);


			var red = new Album { Id = Guid.NewGuid(), Artist = taylor, ArtistId = taylor.Id, Cover = "fill_path", Genre = pop, GenreId = pop.Id, Name = "Red", ReleaseDate = new DateTime(2013,12,1) };

			var xenocide =
				new Album { Id = Guid.NewGuid(), ReleaseDate = new DateTime(2016,3,6), Name = "Xenocide", Artist = crown, ArtistId = crown.Id, Cover = "fill_in", Genre = metal, GenreId = metal.Id };

			var palp =
				new Album {
					Id = Guid.NewGuid(),
					GenreId = metal.Id,
					Genre = metal,
					Cover = "not_in_here",
					Artist = infant, ArtistId = infant.Id,
					Name = "The Palpable Leprosy of Polution",
					ReleaseDate = new DateTime(2010,8,12) };

			var tyrant =
				new Album { Id = Guid.NewGuid(), ReleaseDate = new DateTime(2010,1,1), Name = "Tyrant", Artist = crown, ArtistId = crown.Id, Cover = "fill_in", Genre = metal, GenreId = metal.Id };

			context.Albums.AddOrUpdate(album => album.Id, red, xenocide, palp, tyrant);

			var adminsTaylor = new UsersArtist { Id = Guid.NewGuid(), Artist = taylor, ArtistId = taylor.Id, User = admin, UserId = admin.Id };

			var plebsInfant = new UsersArtist { Id = Guid.NewGuid(), UserId = pleb.Id, User = pleb, Artist = infant, ArtistId = infant.Id };

			var plebsCrown = new UsersArtist { Id = Guid.NewGuid(), User = pleb, ArtistId = crown.Id, Artist = crown, UserId = pleb.Id };

			context.UsersArtists.AddOrUpdate(usal => usal.Id, adminsTaylor, plebsCrown, plebsInfant);

			var twenty = new Song { Id = Guid.NewGuid(), Album = red, AlbumId = red.Id, Name = "22" };

			var trouble = new Song { Id = Guid.NewGuid(), Album = red, AlbumId = red.Id, Name = "I knew You were Trouble" };

			var abyss = new Song { Id = Guid.NewGuid(), Name = "Prismatic Abyss", AlbumId = xenocide.Id, Album = xenocide };

			var ccrusher = new Song { Id = Guid.NewGuid(), Album = palp, Name = "CtCrusher", AlbumId = palp.Id };

			context.Songs.AddOrUpdate(song => song.Id, twenty, trouble, ccrusher, abyss);

			var adminnsXeno = new UsersAlbum { Id = Guid.NewGuid(), Album = xenocide, AlbumId = xenocide.Id, User = admin, UserId = admin.Id };

			var plebsRed = new UsersAlbum { Id = Guid.NewGuid(), User = pleb, UserId = pleb.Id, Album = red, AlbumId = red.Id };

			context.UsersAlbums.AddOrUpdate(userAlbum => userAlbum.Id, adminnsXeno, plebsRed);

			var adminsCrusher = new UsersSong { Id = Guid.NewGuid(), User = admin, UserId = admin.Id, Song = ccrusher, SongId = ccrusher.Id };

			context.UsersSongs.AddOrUpdate(userSong => userSong.Id, adminsCrusher);

			context.SaveChanges();

			base.Seed(context);
		}
	}
}
