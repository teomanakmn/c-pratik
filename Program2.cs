
using System.Text.Json;

class Ogrenci
{
    public string Ad { get; set; }
    public int Numara { get; set; }
    public int Notu { get; set; }
}
internal class Program
{

    static List<Ogrenci> sinifListesi = new List <Ogrenci>();
    static string dosyaYolu = "notlar.json";

    static void VerileriKaydet()
    {
        string json = JsonSerializer.Serialize(sinifListesi);
        File.WriteAllText(dosyaYolu, json);
    }

    static void VerileriYukle()
    {
        if (File.Exists(dosyaYolu))
        {
            string json = File.ReadAllText(dosyaYolu);
            sinifListesi = JsonSerializer.Deserialize<List<Ogrenci>>(json);
        }
    }

    static void OgrenciEkle()
    {
        Console.WriteLine("Öğrenci adı giriniz.");
        string ad = Console.ReadLine();

        Console.WriteLine("Öğrenci Numarası giriniz.");
        int numara = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Öğrenci notu giriniz.");
        int not = Convert.ToInt32(Console.ReadLine());

        Ogrenci yeniOğrenci = new Ogrenci();
        yeniOğrenci.Ad = ad;
        yeniOğrenci.Numara = numara;
        yeniOğrenci.Notu= not;

        sinifListesi.Add(yeniOğrenci);
        VerileriKaydet();
        Console.WriteLine("Öğrenci kaydedildi.");
    }

    static void Listele()
    {
        Console.WriteLine("\n--- SINIF LİSTESİ ---");
        foreach(var x in sinifListesi)
        {
            Console.WriteLine("Ad: " + x.Ad + " - Numara: " + x.Numara + " - Not: " + x.Notu);        
        }
    }

    static void EnBasariliyiBul()
    {
        if (sinifListesi.Count == 0)
        {
            Console.WriteLine("Hiç öğrenci yok!");
            return;
        }

        Ogrenci enIyi = sinifListesi[0];

        foreach(var x in sinifListesi)
        {
            if(x.Notu > enIyi.Notu)
            {
                enIyi = x;
            }
        }

        Console.WriteLine("\n*** EN BAŞARILI ÖĞRENCİ ***");
        Console.WriteLine("Adı: " + enIyi.Ad + " - Notu: " + enIyi.Notu);

    }

    private static void Main(string[] args)
    {
        VerileriYukle();
        while (true)
        {
            Console.WriteLine("1. Öğrenci Ekle");
            Console.WriteLine("2. Öğrenci Listele");
            Console.WriteLine("3. En Başarılıyı Bul");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçim: ");
            string secim = Console.ReadLine();

            if (secim == "1") OgrenciEkle();
            else if (secim == "2") Listele();
            else if (secim == "3") EnBasariliyiBul();
            else if (secim == "4") break;
            else Console.WriteLine("Hatalı seçim");
         }
    }
}