using System;

namespace Calisma_indexer
{


    enum BICIM { DIKEY, YATAY }
    enum HaftaninGunleri
    {
        Pazartesi,
        Sali,
        Carsamba,
        Persembe, 
        Cuma,
        Cumartesi,
        Pazar
    }
    class CokBoyutluIndexer
    {
        private int[,] dizi1;
        public CokBoyutluIndexer(int Boyut1, int Boyut2)
        {
            dizi1 = new int[Boyut1, Boyut2];
        }
        public int Boyut1
        {
            get
            {
                return dizi1.GetLength(0);
            }
        }
        public int Boyut2
        {
            get
            {
                return dizi1.GetLength(1);
            }
        }
        public int this[int indeks1, int indeks2]
        {
            get
            {
                return dizi1[indeks1, indeks2];
            }
            set
            {
                dizi1[indeks1, indeks2] = value;
            }
        }



    }
    class IndeksIslem
    {
      private int[] dizi;
        public IndeksIslem(int DiziUzunlugu)
        {
            dizi = new int[DiziUzunlugu];
        }
        public int DiziBoyut
        {
            get
            {
                return dizi.Length;
            }
        }
        public int this[int indeks]
        {
            get
            {
                return dizi[indeks]; //indeks*indeks; //
            }
            set
            {
                dizi[indeks] = value;
            }
        }


    }

    class Indexers
    {
        public double sayi;
        public double this[double indeks]
        {
            get
            {
                return sayi;//indeks * indeks;
            }
            set
            {
                sayi = value;
            }
        }
    }
    class Program
    {
        static void DiziYaz(Array dizi, BICIM b)
        {
            foreach (int i in dizi)
                if (b == BICIM.DIKEY)
                {
                    Console.WriteLine(i.ToString());
                }
                else
                {
                    Console.Write(i.ToString() + " ");
                }
        }

        static void Main(string[] args)
        {
            Indexers i = new Indexers();
            Console.WriteLine("i[1.2]={0}", i[1.2]);
            i[5] = 2 * i[1.2];
            Console.WriteLine(i.sayi);
            //i[6] = 9;
            Console.WriteLine(i.sayi);
            Console.WriteLine("i[5]={0}", i[5]);
            Console.WriteLine("i[6]={0}", i[6]);

            IndeksIslem a = new IndeksIslem(7); // Burada dinamik boyutlu diziler tanımlıyoruz
            IndeksIslem b = new IndeksIslem(8);

            int[] z = new int[5];
            DiziYaz(z, BICIM.DIKEY);

            for (int j = 0; j < a.DiziBoyut; ++j) // burada DiziBoyut "Lenght" metodunun görevini görür bunu biz 
                                                  // metot olarak IndeksIslem sınıfında tanımladık
            {
                a[j] = j + 1; // --> value => dizi[indeks] burada j+1 değerini x[j] ye atar
                b[j] = j + 2;
                Console.WriteLine($"x[{j}] = {a[j]}");
                Console.WriteLine($"y[{j}] = {b[j]}");

            }



            CokBoyutluIndexer c = new CokBoyutluIndexer(10, 7);

            for (int y = 0; y < c.Boyut1; ++y)
                for (int x = 0; x < c.Boyut2; ++x)
                    c[y, x] = y + x;

            for (int y = 0; y < c.Boyut1; ++y)
            {
                for (int x = 0; x < c.Boyut2; ++x)
                    Console.Write("{0,4} ", c[y, x]);
                Console.WriteLine();

            }

            string[] Gunler = HaftaninGunleri.GetNames(typeof(HaftaninGunleri));
            foreach (string g in Gunler)
                Console.WriteLine(g);






        }
    }
}
