using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class GyvybiuSkaiciavimasTobulinamas : IGyvybiuSkaiciavimas
    {
        private double gyvybesPerskaiciuota;
        public double papildomosGyvybes(string klase, int gyvybes, string kilme)
        {
            gyvybesPerskaiciuota = gyvybes;
            if (klase == "Kovotojas" && kilme == "Maneja")
                gyvybesPerskaiciuota *= 1.2;
            else if (klase == "Karvedys" && kilme == "Troja")
                gyvybesPerskaiciuota *= 2;
            return gyvybesPerskaiciuota;
        }

        public double veikejoGyvybes(int gyvybes, double sarvai, int lygis)
        {
            gyvybesPerskaiciuota = gyvybes;

            if (lygis > 10)
                return gyvybesPerskaiciuota *= 1.2;
            if (lygis > 20)
                return gyvybesPerskaiciuota *= 1.4;
            return gyvybesPerskaiciuota;
        }
    }
}
