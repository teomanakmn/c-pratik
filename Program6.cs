
using System.Text.Json;
using System.Text.Json.Nodes;

public class Urun
{
    public string Ad {  get; set; }
    public double Fiyat { get; set; }

    public virtual double OdenecekTutar()
    {
        return Fiyat * 1.20;
    }
}

public class Teknoloji : Urun
{
    public override double OdenecekTutar()
    {
        return Fiyat * 1.50;
    }
}

public class Gida : Urun
{
    public override double OdenecekTutar()
    {
        return Fiyat * 1.08;
    }
}

internal class Program
{

    static List<Urun> Sepet = new List<Urun>();
    static string dosyaYolu = "sepet.json";

    static void TeknolojiEkle()
    {
        Console.WriteLine("Ürün adı giriniz.");
        string urunad = Console.ReadLine();
        Console.WriteLine("Ürün fiyatı giriniz.");
        double urunfiyat = Convert.ToDouble( Console.ReadLine());
        Teknoloji urun1 = new Teknoloji();
        urun1.Ad = urunad;
        urun1.Fiyat = urunfiyat;
        Sepet.Add(urun1);
    }

    static void GidaEkle()
    {
        Console.WriteLine("Ürün adı giriniz.");
        string urunad = Console.ReadLine();
        Console.WriteLine("Ürün fiyatı giriniz.");
        double urunfiyat = Convert.ToDouble(Console.ReadLine());
        Gida urun1 = new Gida();
        urun1.Ad = urunad;
        urun1.Fiyat=urunfiyat;
        Sepet.Add(urun1);
    }

    static void Listele()
    {
        Console.WriteLine("------URUN LISTESI------");
        foreach(var x in Sepet)
        {
            Console.WriteLine("Ürün Ad: " + x.Ad + " - Ürün Fiyat: " + x.Fiyat + " - OdeneceTutar(KDVLI): " + x.OdenecekTutar());
        }
    }

    static void Kaydet()
    {
        string json=JsonSerializer.Serialize(Sepet);
        File.WriteAllText(dosyaYolu, json);
        Console.WriteLine("Kayıt Başarılı...");
    }

    static void Yukle()
    {
        if (File.Exists(dosyaYolu))
        {
            string json=File.ReadAllText(dosyaYolu);
            Sepet = JsonSerializer.Deserialize < List<Urun>>(json);
            Console.WriteLine("Dosyalar yüklendi.");
        }
        else
        {
            Console.WriteLine("Dosya bulunamadı.");
        }
    }
    private static void Main(string[] args)
    {
     
        while (true)
        {
            Console.WriteLine("----ANA SAYFA---");
            Console.WriteLine("1. Teknoloji ürünü Ekle: ");
            Console.WriteLine("2. Gida ürünü Ekle: ");
            Console.WriteLine("3. Listele: ");
            Console.WriteLine("4. Kaydet: ");
            Console.WriteLine("5. Yükle: ");
            Console.WriteLine("0. Çıkış: ");

            string secim = Console.ReadLine();

            if (secim == "1") TeknolojiEkle();
            else if (secim == "2") GidaEkle();
            else if (secim == "3") Listele();
            else if (secim == "4") Kaydet();
            else if (secim == "5") Yukle();
            else if (secim == "0") break;
        }

    }
}