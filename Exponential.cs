using System;
//Generating the exponentian distributed variables is based on the computational method given here https://en.wikipedia.org/wiki/Exponential_distribution#Generating_exponential_variates
namespace RNG
{
    class Exponential
    {
        double lambda;
        WichmannRNG rng;

        public Exponential()
        {
            rng = new WichmannRNG(12345);
            lambda = 1.0;
        }

        public double Next()
        {
            double u = rng.Next();
            double t = -Math.Log(u) / lambda;

            return t;
        }
    }
}
