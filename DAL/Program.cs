using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	class Program
	{
		static void Main(string[] args)
		{
			IList<Album> albums;
			using (var context = new MusicLibraryDbContext())
			{
				albums = context.Albums.Include(nameof(Album.Genre)).ToList();
			}

			foreach (var album in albums)
			{
				Console.WriteLine(album.Name);				
			}

			Console.ReadLine();
		}
	}
}
