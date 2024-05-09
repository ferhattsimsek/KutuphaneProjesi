namespace kutup.Data
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string? KategoriAdi { get; set; }

        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();

    }
}
