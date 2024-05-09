using System.ComponentModel.DataAnnotations;

namespace kutup.Data
{
    public class Kullanıcı
    {
        
        public int KullanıcıId { get; set; }
        public string? UserName { get; set; }
        public string? UserLastName { get; set; }
        public string? Email { get; set;}
        public string? Tel { get; set;}
        public string? Password { get; set; }
        public List<Emanet>Emanetler { get; set; }  = new List<Emanet>();
        public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();



    }
}
