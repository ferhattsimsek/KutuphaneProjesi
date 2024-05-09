namespace kutup.Data
{
    public class Emanet
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public Kitap kitap { get; set; }=new Kitap();
        public int KullanıcıId {  get; set; }
        public Kullanıcı kullanıcı { get; set; }=new Kullanıcı();

        public DateTime AlisTarihi { get; set; }
        public DateTime GetirecegiTarih{  get; set; }
        public DateTime GetirdiğiTarih { get; set; }
        public int KalanGünSayısı { get; set; }
        public bool getirdimi { get; set; }
    }
}
