internal class Program
{

    static int bakiye = 1000;
    static object kilit = new object();
    static void paraCek()
    {
       lock (kilit)
        {
            if(bakiye >= 400)
            {
                Console.WriteLine("İşlem Yapılıyor...");
                Thread.Sleep(2000);
                bakiye = bakiye - 400;
                Console.WriteLine("Güncel Bakiye: " + bakiye);
            }
            else
            {
                Console.WriteLine("BAKIYE YETERSIZ!");
            }
        }
    }

    private static void Main(string[] args)
    {
        Thread t1 = new Thread(paraCek);
        Thread t2 = new Thread(paraCek);
        Thread t3 = new Thread(paraCek);
        t1.Start();
        t2.Start();
        t3.Start();
        t1.Join();
        t2.Join();
        t3.Join();
        Console.WriteLine("İşlem tamamlandı...");
    }
}