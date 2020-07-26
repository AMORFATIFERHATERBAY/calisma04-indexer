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
        public CokBoyutluIndexer(int Boyut1, int Boyut2) //
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
    class CokBoyutluIndekser
    {
        private int[,] dizi;
        public CokBoyutluIndekser(int Boyut1, int Boyut2)
        {
            dizi = new int[Boyut1, Boyut2];
        }
        public int Boyut1
        {
            get
            {
                return dizi.GetLength(0);
            }
        }
        public int Boyut2
        {
            get
            {
                return dizi.GetLength(1);
            }
        }
        public int this[int indeks1, int indeks2]
        {
            get
            {
                return dizi[indeks1, indeks2];
            }
            set
            {
                dizi[indeks1, indeks2] = (int)Math.Sqrt(value);
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
                return indeks; //* indeks;//sayi;//
            }
            set
            {
               sayi= value*value;
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

            //     class Indexers
            // {
            //     public double sayi;
            //     public double this[double indeks]
            //     {
            //         get
            //         {
            //             return indeks * indeks;//sayi;//
            //         }
            //         set
            //         {
            //             sayi = value;
            //         }
            //     }


            // }
            Indexers indeks = new Indexers();
            Console.WriteLine("i[1.2]={0}", indeks[1.2]);
            indeks[5] = 2 * indeks[1.2];
            Console.WriteLine(indeks.sayi);
            indeks[6] = 9;
            indeks[6] = 8;
            indeks[7] = 8;
            indeks[8] = 8;
            Console.WriteLine(indeks[7].Equals(indeks[6]));
            Console.WriteLine(indeks.sayi.Equals(indeks.sayi));

            Console.WriteLine(indeks.sayi);
            Console.WriteLine("i[5]={0}", indeks[5]);
            Console.WriteLine("i[6]={0}", indeks[6]);
            Console.WriteLine("i[7]={0}", indeks[7]);
            Console.WriteLine("i[8]={0}", indeks[8]);

            

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



            CokBoyutluIndexer c = new CokBoyutluIndexer(10,8);

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


            string[] bicim = BICIM.GetNames(typeof(BICIM));
            foreach (string g in bicim)
                Console.WriteLine("\n" + g);

            CokBoyutluIndekser cb = new CokBoyutluIndekser(5,4);
            for (int i = 0; i < cb.Boyut1; ++i)
                for (int j = 0; j < cb.Boyut2; ++j)
                    cb[i, j] = i * j;
                    
                    
                    

            for (int i = 0; i < cb.Boyut1; ++i)
            {
                for (int j = 0; j < cb.Boyut2; ++j)
                {
                    Console.Write("{0,3}", cb[i, j]);
                }
                Console.WriteLine();
            }
            int [,] bi = new int[2,2];
            Console.WriteLine(bi.GetLength(0));
            








        }
    }
}
