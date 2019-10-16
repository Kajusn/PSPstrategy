using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class SaugusPuolimas : IPuolimoStrategija
    {
        public double puolimoApsauga(double sarvai, string klase)
        {
            if (klase == "Magas" || klase == "Alchemikas")
                return sarvai*1.5;
            else return sarvai*2;
        }

        public double zalosKeitimas(int lygis, string klase)
        {
            if (klase == "Karvedys" || klase == "Kovotojas")
                return 0;
            else return lygis*5;
        }
    }
}
