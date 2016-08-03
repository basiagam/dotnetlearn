using System;

namespace MvcMusicStore.Models
{
    public class MusicStoreEmusicntities : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}