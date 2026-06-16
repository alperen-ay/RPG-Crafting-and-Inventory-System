using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgInventorySystem
{
    enum EsyaNadirligi : byte { Yaygın, Nadir, Destansi, Efsanevi }
    struct HasarTipi
    {
        public int Fiziksel;
        public int Buyu;
        public int Ates;
    }
    class Silah
    {
        public string Isim;
        public EsyaNadirligi Nadirlik;
        public HasarTipi HasarTuru;
        public static explicit operator int(Silah s)
        {
            return s.HasarTuru.Fiziksel + s.HasarTuru.Buyu + s.HasarTuru.Ates;
        }
        public static Silah operator +(Silah s1, Silah s2)
        {
            if (s1.Nadirlik == s2.Nadirlik)
            {
                Silah YeniKilic = new Silah();
                YeniKilic.HasarTuru.Fiziksel = s1.HasarTuru.Fiziksel + s2.HasarTuru.Fiziksel;
                YeniKilic.HasarTuru.Buyu = s1.HasarTuru.Buyu + s2.HasarTuru.Buyu;
                YeniKilic.HasarTuru.Ates = s1.HasarTuru.Ates + s2.HasarTuru.Ates;
                if (s1.Nadirlik == EsyaNadirligi.Yaygın && s2.Nadirlik == EsyaNadirligi.Yaygın)
                {
                    YeniKilic.Nadirlik = EsyaNadirligi.Nadir;
                }
                else if (s1.Nadirlik == EsyaNadirligi.Nadir && s2.Nadirlik == EsyaNadirligi.Nadir)
                {
                    YeniKilic.Nadirlik = EsyaNadirligi.Destansi;
                }
                else if (s1.Nadirlik == EsyaNadirligi.Destansi && s2.Nadirlik == EsyaNadirligi.Destansi)
                {
                    YeniKilic.Nadirlik = EsyaNadirligi.Efsanevi;
                }
                return YeniKilic;
            }
            else
                return null;
        }
    }
    class Envanter
    {
        Silah[] kilic = new Silah[10];
        public Silah this[int index]
        {
            get
            {
                return kilic[index];
            }
            set
            {
                kilic[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Silah k1 = new Silah();
            Silah k2 = new Silah();
            k1.Isim = "Excalibur";
            k2.Isim = "Stormbreaker";
            k1.Nadirlik = EsyaNadirligi.Yaygın;
            k2.Nadirlik = EsyaNadirligi.Yaygın;
            k1.HasarTuru.Fiziksel = 100;
            k1.HasarTuru.Buyu = 10;
            k1.HasarTuru.Ates = 20;
            k2.HasarTuru.Fiziksel = 30;
            k2.HasarTuru.Buyu = 80;
            k2.HasarTuru.Ates = 60;
            Silah UretilenKilic = k1 + k2;
            Envanter AlperenCanta = new Envanter();
            AlperenCanta[0] = UretilenKilic;
            Console.WriteLine("Yeni kılıcın toplam hasarı : " + (int)AlperenCanta[0]);
        }
    }
}
