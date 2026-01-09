
using System.Runtime.Serialization.Json;
using System.Security;
using System.Text.Json;
using System.Text.Json.Nodes;

public class Kitap
{
    public string KitapAdi {  get; set; }
    public string OduncAlan { get; set; }
    public bool KiradaMi { get; set; }

    public int TurKodu { get; set; }   

}
internal class Program
{
    static List<Kitap> Kutuphane = new List<Kitap>();
    static Dictionary<int, string> Turler = new Dictionary<int, string>();
    static string dosyaYolu = "veri.json";

    public static void KitapEkle()
    {
        Console.WriteLine("Kitap adı giriniz.");
        string kitapad = Console.ReadLine();
        Console.WriteLine("Lütfen kitap türü giriniz. 1- Roman, 2- Bilim Kurgu");
        int turkod = Convert.ToInt32(Console.ReadLine());
        Kitap k1 = new Kitap();
        k1.KitapAdi = kitapad;
        k1.TurKodu = turkod;
        Kutuphane.Add(k1);
    }

    public static void Listele()
    {
        Console.WriteLine("Liste oluşturuluyor.");
        foreach(var x in Kutuphane)
        {
            string durum = "Rafta";
            if (x.KiradaMi)
            {
                durum = "Kirada(" + x.OduncAlan + ")";
            }

            string turAdi = "Bilinmiyor";
            if (Turler.ContainsKey(x.TurKodu))
            {
                turAdi = Turler[x.TurKodu];
            }
            Console.WriteLine("Kitap adı: " + x.KitapAdi +" - Tür Kodu: " + Turler[x.TurKodu]+ " - Durum: " +durum);
            
        }
    }
    public static void KitapKirala()
    {
        Console.WriteLine("Kitap adı giriniz.");
        string Kad=Console.ReadLine();
        foreach(var x in Kutuphane)
        {
            if(x.KitapAdi == Kad)
            {

                if (x.KiradaMi == true)
                {
                    Console.WriteLine("Bu kitap şu anda" + x.OduncAlan + "kişisinde");
                    return;
                }
                Console.WriteLine("Kiralayan kişinin adı; ");
                x.OduncAlan = Console.ReadLine();
                x.KiradaMi = true;
                Console.WriteLine("Kitap kiralandı.");
                return;
            }
        }
        Console.WriteLine("⚠️ Böyle bir kitap kütüphanede yok.");
    }
    public static void KitapIade()
    {
        Console.WriteLine("İade edilecek kitap adı nedir?");
        string aranan = Console.ReadLine(); 
        foreach(var x in Kutuphane)
        {
            if (x.KitapAdi == aranan)
            {
                if (x.KiradaMi == false)
                {
                    Console.WriteLine("⚠️ Bu kitap zaten kütüphanede (Kirada değil).");
                    return;
                }
                x.KiradaMi = false;
                x.OduncAlan = "";
                Console.WriteLine("✅ Kitap iade alındı, rafa kondu.");
                return;
            }
        }
        Console.WriteLine("⚠️ Böyle bir kitap sistemde yok.");
    }
    public static void VerileriKaydet()
    {
        string json = JsonSerializer.Serialize(Kutuphane);
        File.WriteAllText(dosyaYolu,json);
        Console.WriteLine("✅ Kütüphane kaydedildi!");
    }
    public static void VerileriYukle()
    {
        if (File.Exists(dosyaYolu))
        {
            string veri = File.ReadAllText(dosyaYolu);
            Kutuphane = JsonSerializer.Deserialize<List<Kitap>>(veri);
            Console.WriteLine("✅ Eski kayıtlar yüklendi.");
        }
        else      
        {
            Console.WriteLine("⚠️ Kayıt dosyası bulunamadı, yeni liste ile başlanıyor.");
        }
    }
    private static void Main(string[] args)
    {
        Turler.Add(1, "Roman");
        Turler.Add(2, "Bilim Kurgu");
        Turler.Add(3, "Tarih");

        while (true)
        {
            Console.WriteLine("\n--- MENÜ ---");
            Console.WriteLine("1- Ekle");
            Console.WriteLine("2- Listele");
            Console.WriteLine("3- Kaydet");
            Console.WriteLine("4- Yükle");
            Console.WriteLine("5- Kitap Kirala"); 
            Console.WriteLine("6- Kitap İade");   
            Console.WriteLine("0- Çıkış");

            Console.WriteLine("Seçim: ");
            string secim = Console.ReadLine();

            if (secim == "1") KitapEkle();
            else if (secim == "2") Listele();
            else if (secim == "3") VerileriKaydet();
            else if (secim == "4") VerileriYukle();
            else if (secim == "5") KitapKirala();
            else if (secim == "6") KitapIade();
            else if (secim == "0") return;
            else { Console.WriteLine("Hatalı Seçim! "); }
            
        }

    }
}