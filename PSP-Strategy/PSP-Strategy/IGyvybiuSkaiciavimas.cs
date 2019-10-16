using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    interface IGyvybiuSkaiciavimas
    {
        double veikejoGyvybes(int gyvybes, double sarvai, int lygis);
        double papildomosGyvybes(string klase, int gyvybes, string kilme);
    }
}
