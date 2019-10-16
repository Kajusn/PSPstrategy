using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class GyvybiuSkaiciavimasPaprastas : IGyvybiuSkaiciavimas
    {
        public double papildomosGyvybes(string klase, int gyvybes, string kilme)
        {
            return gyvybes;
        }

        public double veikejoGyvybes(int gyvybes, double sarvai, int lygis)
        {
            return gyvybes;
        }
    }
}
