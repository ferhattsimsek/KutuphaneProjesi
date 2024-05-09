using kutup.Data;

namespace kutup.Models
{
    public class EmanetViewModel
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
       
        public int KullanıcıId { get; set; }

        public DateTime AlisTarihi { get; set; }
        public DateTime GetirecegiTarih { get; set; }
        public DateTime GetirdiğiTarih { get; set; }
        public int KalanGünSayısı { get; set; }
        public bool getirdimi { get; set; }
    }
}
