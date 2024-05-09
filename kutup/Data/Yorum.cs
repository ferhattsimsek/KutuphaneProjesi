using Microsoft.Extensions.Hosting;

namespace kutup.Data
{
    public class Yorum
    {

        public int YorumId { get; set; }
        public string? Text { get; set; }
        public DateTime PublishedOn { get; set; }

  
        public Kitap Kitap { get; set; } = null!;

        public int KullanıcıId { get; set; }
        public Kullanıcı Kullanıcı { get; set; } = null!;


    }
}
