
public class Calisan
{
    public string Ad { get; set; }
    public int Maas { get; set; }

    public virtual void Calis()
    {
        Console.WriteLine("Çalışan göreve başladı.");
    }
}

public class Yazilimci : Calisan
{
    public string BildigiDil { get; set; }

    public override void Calis()
    {
        Console.WriteLine("Yazılımcı kod yazıyor...");
    }
}
public class Yonetici : Calisan
{
    public int PersonelSayisi { get; set; }
    public override void Calis()
    {
        Console.WriteLine("Yönetici toplantı yapıyor...");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Calisan> Calisanlar = new List<Calisan>();
        Yazilimci y1 = new Yazilimci();
        Yonetici  yo1 = new Yonetici();
        y1.Ad = "Ahmet";
        y1.BildigiDil = "C#";
        yo1.Ad = "Ayşe";
        yo1.PersonelSayisi = 10;
        Calisanlar.Add(y1);
        Calisanlar.Add(yo1);

        foreach(var x in Calisanlar)
        {
            Console.WriteLine("Calisan Ad: " + x.Ad);
            x.Calis();
        }
        

    }
}