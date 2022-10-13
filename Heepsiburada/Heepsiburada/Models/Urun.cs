namespace Heepsiburada.Models
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public decimal UrunFiyat { get; set; }
        public string UrunResim { get; set; }
        public int MarkaId { get; set; }
        public int KategoriId { get; set; }

    }

}