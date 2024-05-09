using System.ComponentModel.DataAnnotations;

namespace kutup.Data
{
    public class Kitap
    {
        [Key]
        public int ISBN { get; set; }
        public string? KitapAdi { get; set; }
        public string? Hakkında { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public int Adet { get; set; }



        public List<Kategori> Kategoriler { get; set; } = new List<Kategori>();

        public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();

        public List<Yazar> Yazarlar { get; set; } = new List<Yazar>();
    }
}
