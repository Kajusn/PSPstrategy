using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    interface IPuolimoStrategija
    {
        String puolimoStrategija(double sarvai, string klase);
        float zalosKeitimas(int lygis, int gyvybes);
    }
}
