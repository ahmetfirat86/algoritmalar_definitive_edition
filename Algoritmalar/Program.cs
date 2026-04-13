using System.Numerics;
using System.Runtime.Intrinsics;
// tüm regionları kapatmak ctrl+m,l veya ctrl+m,o
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
        #endregion

        #region bitwise
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
        }
        #endregion

        #region vize2022
        static void Vize2022()
        {
            //armstrong sayısı 
            static bool birinciSacmaSoru(int n)
            {
                int gecici = n;
                int toplam = 0;

                // Basamak sayısını bulma
                int basamakSayisi = n.ToString().Length;

                while (gecici > 0)
                {
                    int basamak = gecici % 10; // Son basamağı al
                    toplam += (int)Math.Pow(basamak, basamakSayisi); // Üssünü al ve topla
                    gecici /= 10; // Sayıyı küçült
                }
                Console.WriteLine(toplam);
                return toplam == n;
            }

            //int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 4 basamaklı bir sayı olustur ve sayının basamaklarını topla
            static void ikinciSacmaSoru()
            {
                Random rnd = new Random();

                //random 4 basamaklı sayı oluştur
                int i = 0;
                int sayi = 0;
                while (i < 4)
                {
                    int randomRakam = rnd.Next(0, 9);
                    sayi = sayi * 10 + randomRakam;
                    i++;
                }
                Console.WriteLine("random 4 basamaklı sayı oluşturuldu: "+sayi);
                i = 0;
                //sayının basamaklarını topla kötü çözdüm aşırıs saçma oldu 
                int basamakToplamı = 0;
                int x = 10000;
                while (i < 4)
                {
                    x /= 10;
                    int basamak = (sayi / x)%10;
                    basamakToplamı += basamak;
                    i++;
                }
                Console.WriteLine("random 4 basamaklı sayının basamakları toplamı: "+basamakToplamı);

                //sayının basamaklarını topla 2. yöntem
                int toplam = 0;
                int tempSayi = sayi;    

                while (tempSayi > 0)
                {
                    toplam += tempSayi % 10;
                    tempSayi /= 10;
                }
                Console.WriteLine("random 4 basamaklı sayının basamakları toplamı: " + toplam);
            }

            // girilen bir int a sayısının bitlerini kontrol edip hexadecimal olarak yazdır.
            static void ucuncuSacmaSoru()
            {
                int sayi = 123456789;   
                uint unsignedSayi = (uint)sayi;

                Console.WriteLine(unsignedSayi);

                //sayının binary karşılığını yazdır
                string binString = "";
                uint mask = 0x80000000;
                for (int i = 0; i < 32; i++)
                {
                    if ((unsignedSayi & mask) != 0)
                    {
                        binString += "1";

                    }
                    else
                    {
                        binString += "0";

                    }
                    unsignedSayi <<= 1;
                }
                Console.WriteLine("123456789 sayısının binary karşılığı: "+binString);

                //sayının hexadecimal karşılığını yazdır 
                //int to hexadecimal string
                if (sayi == 0)
                {
                    Console.WriteLine("0");
                }
                string hexString = "";
                char[] hexAlphabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

                uint temp = (uint)sayi;
                while (temp > 0)
                {
                    uint kalan = temp % 16;
                    hexString = hexAlphabet[kalan]+hexString; 
                    temp /= 16;
                }
                Console.WriteLine("123456789 sayısının hexadecimal karşılığı: 0x"+hexString);

            }
            #region çalıştır
            birinciSacmaSoru(1124);
            ikinciSacmaSoru();
            ucuncuSacmaSoru();
            #endregion

        }
        #endregion

        #region LongestIncreasingSubsequence
        static void lis()
        {
            string str = "1231546778";
            int strLen = str.Length;
            int[] dp = new int[strLen];
            dp[0] = 1;
            int maxLen = 1;
            int bestEndIndex = 0;

            for (int i = 1; i < strLen; i++)
            {
                if (str[i] > str[i - 1])
                {
                    dp[i] = dp[i - 1] + 1;
                }
                else
                {
                    dp[i] = 1;
                }
                if (dp[i] > maxLen)
                {
                    maxLen = dp[i];
                    bestEndIndex = i;
                }
            }
            Console.WriteLine("1231546778 longest increasing substring: "+maxLen);
        
            string str2 = "ananınamıgalatasarayananınamı";
            int strLen2 = str.Length;
            int[] dp2 = new int[strLen];
            dp2[0] = 1;
            int maxLen2 = 1; int bestEndIndex2 = 0;
            for (int i = 1; i < strLen2; i++)
            {
                if (str2[i] > str2[i - 1])
                {
                    dp2[i] = dp2[i - 1] + 1;
                }
                else
                {
                    dp2[i] = 1;
                }
                if (dp2[i] > maxLen2)
                {
                    maxLen2 = dp2[i];
                    bestEndIndex2 = i;
                }
            }
            Console.WriteLine("ananınamıgalatasarayananınamı longest increasing substring: "+maxLen2);
            

            // lcs ama bitişik olmak zorunda kalmasa
            int[] sayilar = { 1, 2, 3, 0, 4, 5 }; // Örnek dizi
            int n = sayilar.Length;
            int[] dp3 = new int[n];

            // Her sayı en az 1 uzunluğunda bir dizidir (kendisi)
            for (int i = 0; i < n; i++) dp3[i] = 1;

            int maxLen3 = 1;

            // Her bir sayıyı (i) kontrol et
            for (int i = 1; i < n; i++)
            {
                // i'den önceki tüm sayıları (j) kontrol et
                for (int j = 0; j < i; j++)
                {
                    // Eğer i. sayı j. sayıdan büyükse VE 
                    // j'nin sonuna eklenmek mevcut dp[i]'den daha uzun bir seri yapıyorsa
                    if (sayilar[i] > sayilar[j] && dp3[i] < dp3[j] + 1)
                    {
                        dp3[i] = dp3[j] + 1;
                    }
                }

                // Genel maksimumu güncelle
                if (dp3[i] > maxLen3)
                    maxLen3 = dp3[i];
            }

            Console.WriteLine("123045 En Uzun Artan Alt Dizi Uzunluğu: " + maxLen3 );
        }
        #endregion

        #region substring
        static void substring()
        {
            string q = "abcdefgh123";
            string w = "a1ab2djk3";

            int[,] lcs = new int[q.Length, w.Length];
            int eb = 0; // En uzun ortak ifadenin uzunluğunu tutacak değişken

            for (int i = 0; i < q.Length; i++)
            {
                for (int j = 0; j < w.Length; j++)
                {
                    if (q[i] == w[j]) // Karakterler eşleşirse
                    {
                        if (i * j == 0)
                            lcs[i, j] = 1; // İlk satır veya sütunsa 1 yap
                        else
                        {
                            // Önceki eşleşmenin (sol üst çapraz) üzerine 1 ekle
                            lcs[i, j] = lcs[i - 1, j - 1] + 1;

                            if (eb < lcs[i, j])
                                eb = lcs[i, j]; // En büyük uzunluğu güncelle
                        }
                    }
                    else
                    {
                        // Eşleşme yoksa (Subsequence problemine kayıyorsa Math.Max kullanılır)
                        if (i * j == 0)
                            lcs[i, j] = 0;
                        else
                            Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }
            Console.WriteLine(eb); // Sonucu ekrana yazdır
        }
        #endregion
        
        #region LongestCommonSubstring
        static void lcs()
        {
            string s1 = "merhaba dünya selin";
            string s2 = "merhaba selinem";
            string s3 = "bütün dünya merhaba";

            // 3 boyutlu matris tanımlaması
            int[,,] lcs = new int[s1.Length, s2.Length, s3.Length];
            int maxUzun = 0;

            for (int i = 0; i < s3.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    for (int l = 0; l < s1.Length; l++)
                    {
                        // Her üç stringin ilgili karakterleri aynıysa
                        if (s3[i] == s2[j] && s2[j] == s1[l])
                        {
                            // Sınırlardan biri sıfırsa hata almamak için 1 yapıyoruz
                            if (i == 0 || j == 0 || l == 0)
                                lcs[i, j, l] = 1;
                            else
                                lcs[i, j, l] = lcs[i - 1, j - 1, l - 1] + 1;

                            // maxUzun değişkenini güncelle
                            if (maxUzun < lcs[i, j, l])
                            {
                                maxUzun = lcs[i, j, l];
                            }
                        }
                    }
                }
            }
            Console.WriteLine(maxUzun);
        }
        #endregion

        #region Dynamic Programming Fibonacci
        static long Fibonacci_dp(int n)
        {
            if (n <= 1) return n;

            // 1. Bir tablo (dizi) oluşturuyoruz
            long[] dp = new long[n + 1];

            // 2. Temel durumları (bildiğimiz en küçük parçalar) tanımlıyoruz
            dp[0] = 0;
            dp[1] = 1;

            // 3. Tabloyu küçükten büyüğe dolduruyoruz
            for (int i = 2; i <= n; i++)
            {
                // Önceki iki değerin toplamını kullanarak yenisini buluyoruz
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            // 4. Hedeflediğimiz sonucu tablodan çekiyoruz
            Console.WriteLine("{0}a kadar olan sayıların fibonacci toplamı: {1}",n,dp[n]);
            return dp[n]; 
        }
        #endregion

        #region Dynamic Programming Coin Change
        //elimizde 1 2 5 madeni paralar var toplam 11 lira olması için en az kaç tane madeni para kullanmak gerekir
        static int CoinChangeDp(int[] b,int a)
        {
            int istenenToplam = a;
            int[] madeniParalar = b;
            if (istenenToplam < 1)
            {
                Console.WriteLine("istenen toplam 0");
                return 0;
            }

            int[] dpArr = new int[istenenToplam + 1];
            // 1'den hedef tutara kadar bütün tutarları dolduruyoruz
            for (int amountToMake = 1; amountToMake <= istenenToplam; amountToMake++)
            {
                dpArr[amountToMake] = int.MaxValue;

                foreach(int para in madeniParalar)
                {
                    if(para <= amountToMake && dpArr[amountToMake - para] != int.MaxValue)
                    {
                        dpArr[amountToMake] = Math.Min(dpArr[amountToMake], 1 + dpArr[amountToMake - para]);
                    }
                }
            }
            if (dpArr[istenenToplam] == int.MaxValue)
            {
                return -1;
            }
            Console.WriteLine("1, 2, 4 toplam 11 min madeni para: "+dpArr[istenenToplam]);
            return dpArr[istenenToplam];
        }
        #endregion

        #region Dynamic Programing Coin Change Hocanın Çözüm
        static int minMadeniPara(int[] paralar,int hedefTutar)
        {
            // enIyi[t] = t tutarını oluşturmak için gereken minimum para sayısı
            int[] enIyi = new int[hedefTutar + 1];

            // 0 tutarı oluşturmak için 0 para gerekir
            enIyi[0] = 0;

            // Diğer tüm tutarları başlangıçta çok büyük bir sayı yapıyoruz
            for (int tutar = 1; tutar <= hedefTutar; tutar++)
            {
                enIyi[tutar] = 999999;
            }

            // 1'den hedef tutara kadar bütün tutarları dolduruyoruz
            for (int tutar = 1; tutar <= hedefTutar; tutar++)
            {
                // Elimizdeki her parayı deniyoruz
                for (int i = 0; i < paralar.Length; i++)
                {
                    // Eğer bu para şu anki tutardan büyük değilse kullanılabilir
                    if (paralar[i] <= tutar)
                    {
                        // Bu parayı son para olarak kullanırsak
                        // 1 tane para kullandık + kalan tutarın en iyi çözümü
                        int aday = 1 + enIyi[tutar - paralar[i]];

                        // Daha az sayıda para ile oluşturabiliyorsak güncelle
                        if (aday < enIyi[tutar])
                        {
                            enIyi[tutar] = aday;
                        }
                    }
                }
            }

            // Eğer hâlâ çok büyük sayıysa oluşturulamıyor demektir
            if (enIyi[hedefTutar] == 999999)
            {
                return -1;
            }
            Console.WriteLine("1, 3, 4 toplam 6 için min para: "+enIyi[hedefTutar]);
            return enIyi[hedefTutar];
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Bitwise();
            Vize2022();
            lis();
            substring();
            lcs();
            Fibonacci_dp(33);
            CoinChangeDp(new int[] {1,2,4},11);
            minMadeniPara(new int[] { 1, 3, 4 }, 6);
        }
    }
}