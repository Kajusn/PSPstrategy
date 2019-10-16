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
            int sudetingumas = zaidimoPradzia();
            Console.WriteLine("Kuriami priesai...\n");
            Random rnd = new Random();
            List<Veikejas> priesai = new List<Veikejas>();
            for (int i=0; i<sudetingumas*3; i++)
            {
                priesai.Add(new Veikejas(rnd.Next(1, 3), rnd.Next(1,4), rnd.Next(1,10), rnd.Next(50, 200), rnd.Next(10, 70)));
            }
            foreach (Veikejas v in priesai)
            {
                Console.WriteLine("Klase: "+v.klase+" Lygis: " + v.lygis + " Kilme: " + v.kilme + " Gyvybes: " + v.gyvybes + " Sarvai: " + v.sarvai + " Zala: " + v.maxZala);
            }


        }

        private static int zaidimoPradzia()
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
            while (!rgx.IsMatch(val = Console.ReadLine()))
                Console.WriteLine("Nenumatytas pasirinkimas, bandykite dar karta\n");
            param[0] = Convert.ToInt32(val);

            pattern = @"^[1-3]$";

            Console.WriteLine("Pasirinkite veikejo kilme (iveskite skaiciu):\n"+
                              "1. Troja\n" +
                              "2. Maneja\n" +
                              "3. Trofis\n");
            while (!rgx.IsMatch(val = Console.ReadLine()))
                Console.WriteLine("Nenumatytas pasirinkimas, bandykite dar karta\n");

            param[1] = Convert.ToInt32(val);
            zaidejas = new Veikejas(param[1], param[0]);

            Console.WriteLine("Pasirinkite gyvybiu tipa:\n" +
                              "1. Nuo lygio, sarvu ir klases\n" +
                              "2. Nuo lygio, kilmes ir klases\n" +
                              "3. Paprastas \n");
            while (!rgx.IsMatch(val = Console.ReadLine()))
                Console.WriteLine("Nenumatytas pasirinkimas, bandykite dar karta\n");

            Console.WriteLine("Personazas sukurtas!\nTesti...[ENTER]");
            Console.ReadLine(); Console.Clear();

            Console.WriteLine("Zaidimas netrukus prasides, pasirinkite sudetingumo lygi:\n"+
                              "1. Lengva (3 priesai)\n" +
                              "2. Sudetinga (6 priesai)\n" +
                              "3. Savizudybe (9 priesai)\n");
            while (!rgx.IsMatch(val = Console.ReadLine()))
                Console.WriteLine("Nenumatytas pasirinkimas, bandykite dar karta\n");
            Console.Clear();
            return Convert.ToInt32(val);
        }
    }
}
