using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4_Okey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Taslar[] taslar = new Taslar[106];//taş listesi****
            Olusturma[] olusturma = new Olusturma[4];//***

            List<string> listerenk = new List<string>();//***
            listerenk.Add("mavi");
            listerenk.Add("sarı");
            listerenk.Add("kırmızı");
            listerenk.Add("siyah");


            List<int> tasnumarası = new List<int>();
            int sayı1 = 0;


            for (int i = 0; i < 106; i++)//liste*****
            {
                tasnumarası.Add(i);


            }

            for (int i = 0; i < 4; i++)//taşlara özellik verme******
            {
                for (int j = 0; j < 13; j++)
                {
                    taslar[sayı1] = new Taslar(j + 1, listerenk[i]);
                    sayı1++;
                }
                for (int k = 0; k < 13; k++)
                {
                    taslar[sayı1] = new Taslar(k + 1, listerenk[i]);
                    sayı1++;
                }



            }
            taslar[sayı1] = new Taslar(100, "");//yıldızı ekleme****
            taslar[sayı1 + 1] = new Taslar(200, "");//yıldızı ekleme****



            for (int i = 0; i < 106; i++)
                Console.WriteLine(taslar[i].color + taslar[i].number);//****

            for (int i = 0; i < 4; i++)//taşları rast gele atama beşer beşer
            {
                olusturma[i] = new Olusturma();//kuyruk oluşturur
                for (int j = 0; j < 5; j++)
                {
                    int rsayı = random.Next(0, tasnumarası.Count);
                    int nsayı = tasnumarası[rsayı];
                    olusturma[i].Taş_ekle();
                    olusturma[i].head.numara = taslar[nsayı].number;
                    olusturma[i].head.renk = taslar[nsayı].color;
                    tasnumarası.RemoveAt(rsayı);
                }
            }

            for (int i = 0; i < 4; i++)//taşları rast gele atama dörder
            {
                for (int j = 0; j < 4; j++)
                {
                    int rsayı = random.Next(0, tasnumarası.Count);
                    int nsayı = tasnumarası[rsayı];
                    olusturma[i].Taş_ekle();
                    olusturma[i].head.numara = taslar[nsayı].number;
                    olusturma[i].head.renk = taslar[nsayı].color;
                    tasnumarası.RemoveAt(rsayı);

                }
            }
            int f = 0;

            while (tasnumarası.Count != 0)//taşları rast gele atama birer birer
            {
                while (f < 4 && tasnumarası.Count != 0)
                {
                    int rsayı = random.Next(0, tasnumarası.Count);
                    int nsayı = tasnumarası[rsayı];
                    olusturma[f].Taş_ekle();
                    olusturma[f].head.numara = taslar[nsayı].number;
                    olusturma[f].head.renk = taslar[nsayı].color;
                    tasnumarası.RemoveAt(rsayı);
                    f++;

                }
                f = 0;




            }
            for (int y = 0; y < 4; y++)
            {
                Console.WriteLine(y + 1 + ". oyuncunun taşları:");
                olusturma[y].TaslarıGoster();///kişilerin taşlarını ekrana yazdırma
                Console.WriteLine("****");
            }

            List<int> puanliste = new List<int>();


            for (int l = 0; l < 4; l++)
            {
                YıgınTaslar temp1 = olusturma[l].head;
                YıgınTaslar temp4 = olusturma[l].head;
                YıgınTaslar temp7 = olusturma[l].head;
                YıgınTaslar temp10 = olusturma[l].head;







                while (temp1 != null)///aynı sayılı taşların farklı renkli olması kontrolü
                {

                    if (temp1.düzen != 1)
                    {
                        YıgınTaslar temp2 = olusturma[l].head;
                        while (temp2 != null)
                        {
                            if (temp2.düzen != 1 && temp1.numara == temp2.numara && temp2.renk != temp1.renk)
                            {
                                YıgınTaslar temp3 = olusturma[l].head;

                                while (temp3 != null)
                                {
                                    if (temp3.düzen != 1 && temp2.numara == temp3.numara && temp3.renk != temp2.renk && temp3.renk != temp1.renk)
                                    {
                                        Console.WriteLine("aynı sayı farklı renk: " + temp1.numara + temp1.renk + "-" + temp2.numara + temp2.renk + "-" + temp3.numara + temp3.renk);
                                        olusturma[l].p = olusturma[l].p + 1;
                                        temp1.düzen = 1;
                                        temp2.düzen = 1;
                                        temp3.düzen = 1;
                                        break;
                                    }

                                    temp3 = temp3.next;



                                }
                                break;
                            }

                            temp2 = temp2.next;




                        }
                    }


                    temp1 = temp1.next;


                }
                while (temp4 != null)//ardışık sayılı taşların aynı renkli olması durumu
                {

                    if (temp4.düzen != 1)
                    {
                        YıgınTaslar temp5 = olusturma[l].head;

                        while (temp5 != null)
                        {
                            if (temp5.düzen != 1 && temp4.numara + 1 == temp5.numara && temp4.renk == temp5.renk)
                            {
                                YıgınTaslar temp6 = olusturma[l].head;

                                while (temp6 != null)
                                {
                                    if (temp6.düzen != 1 && temp4.numara + 2 == temp6.numara && temp5.renk == temp6.renk)
                                    {
                                        Console.WriteLine("ardışık sayılar aynı renk: " + temp4.numara + temp4.renk + "-" + temp5.numara + temp5.renk + "-" + temp6.numara + temp6.renk);


                                        olusturma[l].p = olusturma[l].p + 1;
                                        temp4.düzen = 1;
                                        temp5.düzen = 1;
                                        temp6.düzen = 1;
                                        break;

                                    }
                                    temp6 = temp6.next;
                                }
                                break;
                            }
                            temp5 = temp5.next;



                        }
                    }
                    temp4 = temp4.next;
                }
                while (temp7 != null)///yıldızlı sayının aynı numarallı farklı renkli sayıları tamamlaması 22* - 3*3
                {
                    if (temp7.renk == "*" && temp7.düzen != 1)
                    {
                        YıgınTaslar temp8 = olusturma[l].head;

                        while (temp8 != null && temp7.düzen != 1)
                        {


                            if (temp8.düzen != 1)
                            {
                                YıgınTaslar temp9 = olusturma[l].head;
                                while (temp9 != null)
                                {
                                    if (temp9.düzen != 1 && temp8.numara == temp9.numara && temp9.renk != temp8.renk)
                                    {
                                        Console.WriteLine("yıldızlı puan aynı sayılı farklı renkli taşlar: " + temp7.renk + "-" + temp8.numara + temp8.renk + "-" + temp9.numara + temp9.renk);

                                        olusturma[l].p = olusturma[l].p + 1;
                                        temp8.düzen = 1;
                                        temp9.düzen = 1;
                                        temp7.düzen = 1;
                                        break;
                                    }

                                    temp9 = temp9.next;
                                }

                            }
                            temp8 = temp8.next;
                        }


                    }
                    temp7 = temp7.next;
                }
                while (temp10 != null)//yıldızlı sayının aynı renkli ve ardışık sayıları tamamlamsı 1*2-32*-*34
                {
                    if (temp10.renk == "*" && temp10.düzen != 1)
                    {
                        YıgınTaslar temp11 = olusturma[l].head;

                        while (temp11 != null && temp10.düzen != 1)
                        {


                            if (temp11.düzen != 1)
                            {
                                YıgınTaslar temp12 = olusturma[l].head;
                                while (temp12 != null)
                                {
                                    if (temp12.düzen != 1 && (temp11.numara + 1 == temp12.numara || temp11.numara + 2 == temp12.numara) && temp12.renk == temp11.renk)
                                    {
                                        Console.WriteLine("yıldızlı puan aynı renkli ardışık sayılı taşlar: " + temp10.renk + "-" + temp11.numara + temp11.renk + "-" + temp12.numara + temp12.renk);

                                        olusturma[l].p = olusturma[l].p + 1;

                                        temp11.düzen = 1;
                                        temp12.düzen = 1;
                                        temp10.düzen = 1;
                                        break;
                                    }

                                    temp12 = temp12.next;
                                }

                            }
                            temp11 = temp11.next;
                        }


                    }
                    temp10 = temp10.next;
                }



                Console.WriteLine(l + 1 + ".oyuncunun toplam puanı" + olusturma[l].p);
                puanliste.Add(olusturma[l].p);




            }
            List<int> birinci = new List<int>();
            int buyuk = puanliste[0];

            for (int i = 0; i < puanliste.Count; i++)
            {
                if (buyuk < puanliste[i])
                { buyuk = puanliste[i]; }

            }
            for (int i = 0; i < puanliste.Count; i++)
            {
                if (buyuk == puanliste[i])
                {
                    birinci.Add(i);
                }
            }
            for (int i = 0; i < birinci.Count; i++)
            {
                Console.WriteLine("oyunun birincisi: " + (birinci[i] + 1) + ". oyuncu");

            }
            List<int> sonuncu = new List<int>();
            int kucuk = puanliste[0];

            for (int i = 0; i < puanliste.Count; i++)
            {
                if (kucuk > puanliste[i])
                { kucuk = puanliste[i]; }

            }
            for (int i = 0; i < puanliste.Count; i++)
            {
                if (kucuk == puanliste[i])
                {
                    sonuncu.Add(i);
                }
            }
            for (int i = 0; i < sonuncu.Count; i++)
            {
                Console.WriteLine("oyunun sonuncusu: " + (sonuncu[i] + 1) + ". oyuncu");

            }

            Console.ReadKey();





        }
    }
    class YıgınTaslar
    {
        public int numara;
        public string renk;
        public int düzen;
        public YıgınTaslar next;
        public YıgınTaslar()
        {
            next = null;
        }
    }
    class Olusturma
    {
        public int p;// kuyruktaki toplam puanı tutan değişken
        public YıgınTaslar head;
        public Olusturma()
        {
            head = null;
        }
        public void Taş_ekle()
        {
            YıgınTaslar eleman = new YıgınTaslar();
            if (head == null)
            {
                head = eleman;
            }
            else
            {
                eleman.next = head;
                head = eleman;
            }
        }
        public void TaslarıGoster()
        {
            YıgınTaslar temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.numara + "-" + temp.renk);
                temp = temp.next;
            }
        }
    }
    class Taslar
    {
        public int number;
        public string color;
        public Taslar(int number, string color)
        {
            this.number = number;
            this.color = color;
        }

    }
}