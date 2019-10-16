using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PSP_Strategy
{
    class Program
    {
        private enum Klase { Karvedys = 1, Kovotojas, Magas, Alchemikas };
        private enum Kilme { Troja = 1, Maneja, Trofis};

        private static Veikejas zaidejas;
        static void Main(string[] args)
        {
            string[] priesuPasirinkimas = new string[4];
            priesuPasirinkimas[1] = @"^[1-3]$";
            priesuPasirinkimas[2] = @"^[1-6]$";
            priesuPasirinkimas[3] = @"^[1-9]$";
            string val;
            string lygioKelimas = @"^lygis$";
            string puolimas = @"^pulti$";
            string puolimoPasirinkimas = @"^puolimo tipas$";
            string lygioSablonas = @"^(100|[1-9][0-9]|[1-9])$";
            string puolimoTipoSablonas = @"^[1-2]$";
            Regex rgxLygioKelimas = new Regex(lygioKelimas);
            Regex rgxPuolimas = new Regex(puolimas);
            Regex rgxPuolimoPasirinkimas = new Regex(puolimoPasirinkimas);
            Random rnd = new Random();
            List<Veikejas> priesai = new List<Veikejas>();

            int sudetingumas = ZaidimoPradzia();
            for (int i=0; i<sudetingumas*3; i++)
            {
                priesai.Add(new Veikejas(rnd.Next(1, 3), rnd.Next(1,4), rnd.Next(1,10), rnd.Next(50, 200), rnd.Next(10, 70)));
                priesai[i].PasirinktiPuolimoTipa(rnd.Next(1, 2));
            }
            while (zaidejas.gyvas)
            {
                foreach (Veikejas v in priesai)
                {
                    if (v.gyvas)
                        Console.WriteLine("[" + (priesai.IndexOf(v)+1) + "] " + v.klase + "(" + v.lygis + ")" + " HP: " + v.gyvybes + " AR: " + v.sarvai + " DMG: " + v.maxZala + " " + v.strategija);
                }
                Console.WriteLine("\nHEROJUS " + zaidejas.klase + " (" + zaidejas.lygis + ")" + " HP: " + zaidejas.gyvybes + " AR: " + zaidejas.sarvai + " DMG: " + zaidejas.maxZala + " " + zaidejas.strategija);
                Console.WriteLine("\nGalimos komandos: \"pulti\", \"lygis\", \"puolimo tipas\"\n");
                val = Console.ReadLine();
                if (rgxLygioKelimas.IsMatch(val))
                {
                    Console.WriteLine("Iveskite nauja lygi (0-100):\n");
                    zaidejas.KeistiLygi(Convert.ToInt16(SkaitytiIvesti(lygioSablonas)));
                    Console.Clear(); Console.WriteLine("Lygis pakeistas! Naujas lygis: " + zaidejas.lygis + ", gyvybes: " + zaidejas.gyvybes + "\n");
                    Console.ReadLine();
                }
                else if (rgxPuolimas.IsMatch(val))
                {
                    if (zaidejas.PuolimoTipas != null)
                    {
                        Console.WriteLine("Pasirinkite prieso numeri: \n");
                        int priesoNumeris = Convert.ToInt32(SkaitytiIvesti(priesuPasirinkimas[sudetingumas]));
                        zaidejas.Pulti(priesai[priesoNumeris-1]);
                    }
                    else Console.WriteLine("Zaidejas neturi puolimo strategijos!\n");
                }
                else if (rgxPuolimoPasirinkimas.IsMatch(val))
                {
                    Console.WriteLine("\n1. Agresyvus puolimas\n2. Saugus puolimas");
                    int pasirinkimas = Convert.ToInt32(SkaitytiIvesti(puolimoTipoSablonas));
                    zaidejas.PasirinktiPuolimoTipa(pasirinkimas);
                }
                else
                    Console.WriteLine("Neatpazinta komanda!\n");
                Console.ReadLine(); Console.Clear();
                foreach (Veikejas v in priesai)
                {
                    if (v.gyvas) v.Pulti(zaidejas);
                }
            }

            Console.WriteLine("\n\nHerojus pralaimejo\n\n");
        }

        private static string SkaitytiIvesti(string pattern)
        {
            string value;
            Regex rgx = new Regex(pattern);
            while (!rgx.IsMatch(value = Console.ReadLine()))
                Console.WriteLine("Netinkamas formatas, bandykite dar karta:\n");
            return value;
        }
        private static int ZaidimoPradzia()
        {
            string val;
            int[] param = new int[2];
            string pattern = @"^[1-4]$";
            Regex rgx = new Regex(pattern);

            Console.WriteLine("Pradekime zaidimo simuliacija!\n");

            Console.WriteLine("Susikurk savo personaza!\nPasirinkite norima klase (iveskite skaiciu):\n"+
                              "1. Karvedys\n" +
                              "2. Kovotojas\n" +
                              "3. Magas\n" +
                              "4. Alchemikas\n");
            param[0] = Convert.ToInt32(SkaitytiIvesti(pattern));

            pattern = @"^[1-3]$";
            rgx = new Regex(pattern);

            Console.WriteLine("Pasirinkite veikejo kilme (iveskite skaiciu):\n"+
                              "1. Troja\n" +
                              "2. Maneja\n" +
                              "3. Trofis\n");

            param[1] = Convert.ToInt32(SkaitytiIvesti(pattern));
            zaidejas = new Veikejas(param[1], param[0]);

            Console.WriteLine("Pasirinkite gyvybiu tipa:\n" +
                              "1. Nuo lygio, sarvu ir klases\n" +
                              "2. Nuo lygio, kilmes ir klases\n" +
                              "3. Paprastas tik nuo lygio\n");
            val = SkaitytiIvesti(pattern);
            if (Convert.ToInt32(val) == 1)
                zaidejas.GyvybiuTipas = new GyvybiuSkaiciavimasPridetinis();

            else if (Convert.ToInt32(val) == 2)
                zaidejas.GyvybiuTipas = new GyvybiuSkaiciavimasTobulinamas();

            Console.WriteLine("Personazas sukurtas!\nTesti...[ENTER]");
            Console.ReadLine(); Console.Clear();

            Console.WriteLine("Zaidimas netrukus prasides, pasirinkite sudetingumo lygi:\n"+
                              "1. Lengva (3 priesai)\n" +
                              "2. Sudetinga (6 priesai)\n" +
                              "3. Savizudybe (9 priesai)\n");
            val = SkaitytiIvesti(pattern);
            Console.Clear();
            return Convert.ToInt32(val);
        }
    }
}
