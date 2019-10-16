using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public class AgresyvusPuolimas : IPuolimoStrategija
    {
        public double puolimoApsauga(double sarvai, string klase)
        {
            if (klase == "Magas" || klase == "Alchemikas")
                return sarvai;
            else return sarvai*1.2;
        }

        public double zalosKeitimas(int lygis, string klase)
        {
            if (klase == "Karvedys" || klase == "Kovotojas")
                return lygis * 15;
            else if (klase == "Magas")
                return lygis * 25;
            else return lygis * 10;
        }
    }
}
