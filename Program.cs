using System.Text.Json;

public class Siparis
{
    public string MusteriAdi { get; set; }
    public string UrunAdi { get; set; }
    public int Miktar {  get; set; }
    public DateTime SiparisTarihi { get; set; }

}


internal class Program
{

    static List<Siparis> Siparisler = new List<Siparis>();
    static string dosyaYolu="veri.json";

    static void SiparisEkle()
    {
        Console.WriteLine("Müşteri adı giriniz: ");
        string MusteriAd = Console.ReadLine();
        Console.WriteLine("Ürün adı giriniz: ");
        string UrunAd = Console.ReadLine();
        Console.WriteLine("Miktar bilgisi giriniz: ");
        int miktar = Convert.ToInt32(Console.ReadLine());
        Siparis s1 = new Siparis();
        s1.MusteriAdi = MusteriAd;
        s1.UrunAdi = UrunAd;
        s1.Miktar = miktar;
        s1.SiparisTarihi = DateTime.Now;
        Siparisler.Add(s1);
        Console.WriteLine("Sipariş Alındı.");
        VerileriKaydet();
        Console.WriteLine("Veriler Kaydediliyor");
        Thread.Sleep(1500);
        Console.WriteLine(".");
    }

    static void MusteriSiparisleri()
    {
        Console.WriteLine("Aranacak müşteri ismini giriniz.");
        string aranan=Console.ReadLine();
        int toplamAdet = 0;
        foreach(var x in Siparisler)
        {
            if (aranan == x.MusteriAdi)
            {
                Console.WriteLine("Müsteri Adı: "+x.MusteriAdi+" - Ürün Adı: "+x.UrunAdi+" - Ürün Miktarı: "+x.Miktar);
                toplamAdet += x.Miktar;              
            }
        }
        Console.WriteLine("Bu müşterinin toplam sipariş adedi: "+toplamAdet + "Adet.");
    }
    static void UrunAnalizi()
    {
        Dictionary<string, int> urunRapor = new Dictionary<string, int>();
        foreach(var x in Siparisler)
        {
            if (urunRapor.ContainsKey(x.UrunAdi))
            {
                urunRapor[x.UrunAdi] += x.Miktar;
            }
            else
            {
                urunRapor.Add(x.UrunAdi,x.Miktar);
            }
        }
        foreach(var kayit in urunRapor)
        {
            Console.WriteLine($"Ürün: {kayit.Key} -> Toplam: {kayit.Value} adet satıldı.");
        }
    }

    static void VerileriKaydet()
    {
        string json = JsonSerializer.Serialize(Siparisler);
        File.WriteAllText(dosyaYolu, json);
    }
    static void VerileriYukle()
    {
        if (File.Exists(dosyaYolu))
        {
            string okunan= File.ReadAllText(dosyaYolu);
            Siparisler = JsonSerializer.Deserialize<List<Siparis>>(okunan);
        }
    }
    private static void Main(string[] args)
    {
        VerileriYukle();

        while (true)
        {
            Console.WriteLine("\n=============================");
            Console.WriteLine("   SİPARİŞ TAKİP SİSTEMİ");
            Console.WriteLine("=============================");
            Console.WriteLine("1- Yeni Sipariş Ekle");
            Console.WriteLine("2- Müşteri Siparişlerini Gör");
            Console.WriteLine("3- Ürün Analizi (En Çok Ne Satıldı?)");
            Console.WriteLine("0- Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();
            if (secim == "1") SiparisEkle();
            else if (secim == "2") MusteriSiparisleri();
            else if (secim == "3") UrunAnalizi();
            else if (secim == "0") return;
            else Console.WriteLine("Hatalı seçim");
        }
    }
}