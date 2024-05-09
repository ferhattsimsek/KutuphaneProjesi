namespace kutup.Data
{
    public class Yazar
    {
        public int YazarId { get; set; }
        public string? YazarAdi { get; set; }
        public string? YazarSoyadi { get; set; }
        public string? AdSoyad {
            get
            {
                return this.YazarAdi +" "+this.YazarSoyadi;
            }
                
                
                
                
                }
        public List<Kitap> Kitaplar { get; set; }=new List<Kitap>();

    }
}
