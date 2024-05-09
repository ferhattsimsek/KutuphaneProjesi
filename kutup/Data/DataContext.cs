using Microsoft.EntityFrameworkCore;

namespace kutup.Data
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
               
        }
        public DbSet<Kategori> Kategoriler => Set<Kategori>();
        public DbSet<Kitap> Kitaplar => Set<Kitap>();
        public DbSet<Yazar> Yazarlar => Set<Yazar>();
        public DbSet<Kullanıcı> Kullanıcılar => Set<Kullanıcı>();
        public DbSet<Emanet> Emanetler => Set<Emanet>();
        public DbSet<Yorum> Yorumlar => Set<Yorum>();



    }
}
