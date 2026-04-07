using System.Runtime.Intrinsics;

namespace Algoritmalar
{
    //bismilliahirrahmanirrahim
    internal class Program
    {
        static uint memA = 3;
        static uint memB = 32;
        static uint memC = 33;   
        static uint memD = 64;
        static uint memE = 912421553;
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            Bitwise();
        }

        #region Bit manipulation
        /*
        bool -> 1bit
        byte/sbyte -> 8bit
        short/yshort -> 16bit

        sbyte / 8 bit 1 byte / İşaretli / -128 ~ 127
        byte / 8 bit / 1 byte / İşaretsiz / 0 ~ 255
        short / 16 bit / 2 byte / İşaretli / -32.768 ~ 32.767
        ushort / 16 bit / 2 byte / İşaretsiz / 0 ~ 65.535
        int / 32 bit / 4 byte / İşaretli / -2.147.483.648 ~ 2.147.483.647
        uint / 32 bit / 4 byte / İşaretsiz / 0 ~ 4.294.967.295
        long / 64 bit / 8 byte / İşaretli / -9.223.372.036.854.775.808 ~ 9.223.372.036.854.775.807
        ulong / 64 bit / 8 byte / İşaretsiz / 0 ~ 18.446.744.073.709.551.615
         */
        static void Bitwise()
        {
            //memA ı bit değerinde yazacak
            static void BitOfMem(uint sayi)
            {
                for (int i = 31; i >= 0; i--)
                {
                    uint bit = (sayi >> i) & 1;
                    Console.Write(bit);

                    if (i % 8 == 0) Console.Write(" ");
                }
                Console.WriteLine();
            }

            //sayının 1. bitindeki değeri ver
            static void v1()
            {
                if ((memA & 1) != 0)
                {
                    Console.WriteLine("memA'nın 1. bit değeri: 1");
                }
                else
                {
                    Console.WriteLine("memA'nın 1. bit değeri: 0");
                }
            }

            //sayının 3.bitinin değeri
            static void v2()
            {
                uint controlBit = 0x4;
                if ((memA & controlBit) != 0)
                {
                    Console.WriteLine("memA'nın 3. bit değeri: 1");
                }
                else
                {
                    Console.WriteLine("memA'nın 3. bit değeri: 0");
                }
            }

            //1. bitini 0 yapan
            static void v3()
            {
                uint mask = 0xfffffffe;
                uint result = memA & mask;
                Console.WriteLine("memA'nın 1. biti 0 yapılırsa ondalık cinsinden sonuç: " + result);
            }

            //A sayısının ikilik sayı sisteminde kaç biti 1 dir
            static int v4(uint sayi)
            {
                int count = 0;
                for (int i = 31; i >= 0; i--)
                {
                    if (((sayi >> i) & 1) != 0) count++;
                }
                return count;
            }

            //A sayısının 32.bitini yazdıran
            static void v5(uint sayi)
            {
                uint mask = 0x80000000;
                uint result = sayi & mask;
                if (result != 0) Console.WriteLine("32. bit 1'dir.");
                else Console.WriteLine("32.bit sıfırdır");
            }

            //A sayısının 32.bitini döndüren
            static uint v6(uint sayi)
            {
                return sayi >> 31;
            }

            //A sayısının 1.bitini 1 yap
            static uint v7(uint sayi)
            {
                return sayi | 0x1;
            }

            //A sayısını B ye kopyala for döngüsü ile 
            static uint v8(uint value)
            {
                uint copyValue = 0;
                for(int i =0; i < 32; i++)
                { 
                    uint bit = (value >> i) & 1;
                    if (bit == 1) copyValue |= ((uint)1 << i);
                }

                return copyValue;
            }

            //A sayısını B ye kopyala for döngüsü ile 
            static uint v9(uint value)//en güzeli bu
            {
                uint copyValue = 0;
                for (int i = 0; i < 32; i++)
                {
                    copyValue = copyValue | (((value >> i) & 1 ) << i);
                }
                return copyValue;
            } 

            //A sayısının 8 9 10 ve 11 bitlerini 1 yap -> 0x00000780
            static uint v10(uint value)
            {
                return value | 0x780;
              //return value | 0xF << 8;
            }


            #region çalıştır
            Console.WriteLine("memA değerinin ondalık sayı sistemindeki karşılığı: " + memA);
            Console.WriteLine("memB değerinin ondalık sayı sistemindeki karşılığı: " + memB);
            Console.WriteLine("memC değerinin ondalık sayı sistemindeki karşılığı: " + memC);
            Console.WriteLine("memD değerinin ondalık sayı sistemindeki karşılığı: " + memD);
            Console.WriteLine("memE değerinin ondalık sayı sistemindeki karşılığı: " + memE);
            Console.WriteLine();
            Console.Write("memA değerinin ikilik sayı sistemindeki karşılığı: "); BitOfMem(memA);
            Console.Write("memB değerinin ikilik sayı sistemindeki karşılığı: "); BitOfMem(memB);
            Console.Write("memC değerinin ikilik sayı sistemindeki karşılığı: "); BitOfMem(memC);
            Console.Write("memD değerinin ikilik sayı sistemindeki karşılığı: "); BitOfMem(memD);
            Console.Write("memE değerinin ikilik sayı sistemindeki karşılığı: "); BitOfMem(memE);
            Console.WriteLine(); 
            v1();
            v2();
            v3();
            Console.WriteLine("Number of 1 bit in memB: {0}", v4(memB));
            Console.WriteLine("Number of 1 bit in memE: {0}", v4(memE));
            v5(memE);
            Console.WriteLine("memE 32. biti: {0}", v6(memE));
            Console.Write("memD 1. biti 1 yapıldı: " ); BitOfMem(v7(memD));
            Console.Write("memE kopyalandı: "); BitOfMem(v8(memE));
            Console.Write("memE kopyalandı: "); BitOfMem(v9(memE));
            Console.Write("memB sayısının 8 9 10 ve 11 bitleri 1 yapıldı: "); BitOfMem(v10(memB));


            #endregion
        #endregion
        }
    }
}