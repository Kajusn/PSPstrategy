using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public interface IGyvybiuSkaiciavimas
    {
        double veikejoGyvybes(double gyvybes, double sarvai, int lygis);
        double papildomosGyvybes(string klase, double gyvybes, string kilme);
    }
}
