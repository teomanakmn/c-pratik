using System.Text.Json;

internal class Program
{

    static Dictionary<int, string> Plaka = new Dictionary<int, string>();
    static string dosyaYolu = "plakalar.json";

    static void VerileriKaydet()
    {
        string json = JsonSerializer.Serialize(Plaka);
        File.WriteAllText(dosyaYolu, json);
    }

    static void VerileriYukle()
    {
        if (File.Exists(dosyaYolu))
        {
            string json = File.ReadAllText(dosyaYolu);
            Plaka = JsonSerializer.Deserialize<Dictionary<int, string>>(json);
        }
    }
    private static void Main(string[] args)
    {
        VerileriYukle();

        while (true)
        {
            Console.WriteLine("\n--- LİSTE ---");
            foreach (var plakalar in Plaka)
            {
                Console.WriteLine("Plaka: " + plakalar.Key + " - Şehir: " + plakalar.Value);
            }

            Console.WriteLine("Plaka giriniz.");
            int plakadeger = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Şehir giriniz.");
            string sehirdeger = Console.ReadLine();

            if (Plaka.ContainsKey(plakadeger))
            {
                Console.WriteLine("Zaten var!");
            }
            else
            {
                Plaka.Add(plakadeger, sehirdeger);
                VerileriKaydet();
                Console.WriteLine("Bilgiler eklendi!");         
            }
        }
    }
}