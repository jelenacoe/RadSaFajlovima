using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    class Program
    {
        static int Meni()
        {
            Console.WriteLine("\nOdaberi opciju:");
            Console.WriteLine("\t 1) Ucitaj fajl...");
            Console.WriteLine("\t 2) Zapisi u fajl...");
            Console.WriteLine("\t 3) Prebaci sadrzaj...");
            Console.WriteLine("\t 4) Proveri jednakost sadrzaja...");
            Console.WriteLine("\t 5) Prebroj pojave zeljene reci...");
            Console.WriteLine("\t 6) Prebroj sve reci...");
            Console.WriteLine("\t 7) Napusti program");
            Console.Write("Vas odgovor: ");

            int odg = 0;
            do
            {
                Int32.TryParse(Console.ReadLine(), out odg);

                if (odg < 1 || odg > 7)
                {
                    Console.WriteLine("Pogresna vrednost! Unesite broj od 1 do 7!");
                    Console.Write("Vas odgovor: ");
                }
            }
            while (odg < 1 || odg > 7);
            
            return odg;
        }

        static void Main(string[] args)
        {
            int unos;

            do
            {
                unos = Meni();
                switch(unos)
                {
                    case 1:
                        Metode.UcitajIzFajla();
                        break;
                    case 2:
                        Metode.UcitajIzFajla();
                        break;
                    case 3:
                        Metode.KopirajIzJednogFajlaUDrugi();                        
                        break;
                    case 4:
                        Metode.UporedjivanjeSadrzajaFajlova();
                        break;
                    case 5:
                        Metode.PrebrojZadatuRecUFajlu();
                        break;
                    case 6:
                        Metode.PrebrojReciUFajlu();
                        break;
                }
                
            } while (unos != 7);
            
        }
    }
}
