using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Strategy
{
    public interface IPuolimoStrategija
    {
        double puolimoApsauga(double sarvai, string klase);
        double zalosKeitimas(int lygis, string klase);
    }
}
