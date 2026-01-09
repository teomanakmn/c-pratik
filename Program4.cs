
public class Arac
{
    public string Marka { get; set;  }
    public virtual void Calis()
    {
        Console.WriteLine("Araba çalıştı.");
    }
}
public class Taksi : Arac
{
    public bool TicariPlakaMi {  get; set; }
    public override void Calis()
    {
        Console.WriteLine("Taksi çalıştı, taksimetre açıldı.");
    }
}

public class Kamyon : Arac
{
    public override void Calis()
    {
        Console.WriteLine("KAMYON ÇALIŞTI VINN VINN!!");
    }
}
internal class Program
{
    private static void Main(string[] args)
    {

        List<Arac> araclar = new List<Arac>();
        araclar.Add(new Taksi());
        araclar.Add(new Kamyon());
        foreach(var x in araclar)
        {
            x.Calis();
        }

        Taksi T = new Taksi();
        T.Marka = "Toyota";
        T.TicariPlakaMi = true;
        Console.WriteLine("Marka: " + T.Marka+ " - Ticari mi: " + T.TicariPlakaMi);
        T.Calis();
    }
}