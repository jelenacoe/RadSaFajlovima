using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public static class Metode
    {
        public static void UpisUFajl(string fajlIme, string sadrzaj)
        {
            byte[] bafer = Encoding.UTF8.GetBytes(sadrzaj);

            // Otvaranje binarnog file stream objekta za upis u fajl (obezbeđeno implicitno oslobađanje resursa)
            using (FileStream fajlStream = new FileStream(fajlIme, FileMode.Append, FileAccess.Write, FileShare.None)) //OBRATITI PAZNJU NA APPEND zbog opcije 3!
            {
                fajlStream.Write(bafer, 0, bafer.Length);
            } // Implicitno se poziva fajlStream.Close() za oslobađanje resursa
        }

        public static string CitanjeIzFajla(string fajlIme)
        {
            byte[] bafer;

            // Otvaranje binarnog file stream objekta za čitanje iz fajla (obezbeđeno implicitno oslobađanje resursa)
            using (FileStream fajlStream = new FileStream(fajlIme, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                int length = (int)fajlStream.Length;   // Dužina fajla
                bafer = new byte[length];              // Kreiranje bafera čija je veličina ista kao veličina fajla
                int count = 0;                         // Broj isčitanih bajtova u trenutnoj iteraciji
                int sum = 0;                           // Ukupan broj isčitanih bajtova

                // Čitanje dok 'Read' metoda ne vrati 0 (do kraja stream-a)
                while ((count = fajlStream.Read(bafer, sum, length - sum)) > 0)
                    sum += count;                       // 'sum' je ofset za sledeću iteraciju
            } // Implicitno se poziva fajlStream.Close() za oslobađanje resursa

            string sadrzaj = Encoding.UTF8.GetString(bafer);
            return sadrzaj;
        }

        public static void UcitajIzFajla()
        {
            Console.WriteLine("Unesite zeljenu putanju do fajla (sa sve nazivom i esktenzijom):");
            string putanja = Console.ReadLine();
            try
            {
                Console.WriteLine(CitanjeIzFajla(putanja));
            }
            catch (Exception)
            {
                Console.WriteLine("Problem pri ucitavanju fajla!");
            }
        }
        public static void UpisiUFajl()
        {
            Console.WriteLine("Unesite zeljenu putanju za novi fajl (sa sve nazivom i esktenzijom):");
            string putanja = Console.ReadLine();
            Console.WriteLine("Unesite sadrzaj koji ce biti upisan u fajl:");
            string tekst = Console.ReadLine();
            try
            {
                UpisUFajl(putanja, tekst);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem pri ucitavanju fajla!");
            }
        }

        public static void KopirajIzJednogFajlaUDrugi()
        {
            Console.WriteLine("Unesite zeljenu putanju do fajla ciji se sadrzaj kopira (sa sve nazivom i esktenzijom):");
            string putanja = Console.ReadLine();
            try
            {
                string tekst = CitanjeIzFajla(putanja);

                Console.WriteLine("Unesite zeljenu putanju do fajla gde se sadrzaj nalepljuje (sa sve nazivom i esktenzijom):");
                putanja = Console.ReadLine();

                UpisUFajl(putanja, tekst);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem pri ucitavanju fajla!");
            }
        }

        public static void UporedjivanjeSadrzajaFajlova()
        {
            Console.WriteLine("Unesite zeljenu putanju do prvog fajla (sa sve nazivom i esktenzijom):");
            string putanja = Console.ReadLine();
            try
            {
                string tekst = CitanjeIzFajla(putanja);

                Console.WriteLine("Unesite zeljenu putanju do prvog fajla (sa sve nazivom i esktenzijom):");
                putanja = Console.ReadLine();

                if (tekst == CitanjeIzFajla(putanja))
                {
                    Console.WriteLine("Sadrzaji su isti!");
                }
                else
                {
                    Console.WriteLine("Sadrzaji nisu isti!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Problem pri ucitavanju fajla!");
            }
        }

        public static void PrebrojZadatuRecUFajlu()
        {
            Console.WriteLine("Unesite zeljenu putanju do fajla (sa sve nazivom i esktenzijom):");
            string putanja = Console.ReadLine();
            try
            {
                string tekst = CitanjeIzFajla(putanja);

                Console.WriteLine("Unesite rec ciji broj ponavljanja trazite:");
                string rec = Console.ReadLine();

                string[] reci = tekst.Split(' ');
                int brReci = 0;
                foreach (string r in reci)
                {
                    if (r.Equals(rec))
                    {
                        ++brReci;
                    }
                }

                Console.WriteLine("Rec {0} se nalazi {1} puta u ucitanom fajlu!", rec, brReci);

            }
            catch (Exception)
            {
                Console.WriteLine("Problem pri ucitavanju fajla!");
            }
        }

        public static void PrebrojReciUFajlu()
        {
            Console.WriteLine("Unesite zeljenu putanju do fajla (sa sve nazivom i esktenzijom):");
            string putanja = Console.ReadLine();
            try
            {
                string tekst = CitanjeIzFajla(putanja);

                Console.WriteLine("U fajlu ima {0} reci!", tekst.Split(' ').Length);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem pri ucitavanju fajla!");
            }
        }
    }
}
