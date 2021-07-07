using System;
//Generating the Poissom distributed variables is done using the simple Knuth's algrithm, as shown here https://en.wikipedia.org/wiki/Poisson_distribution#Computational_methods
namespace RNG
{
    class Poisson
    {
        double L;
        double p;
        int k;
        WichmannRNG rng;

        public Poisson(double lambda)
        {
            L = Math.Exp(-lambda);
            p = 1.0;
            k = 0;
            rng = new WichmannRNG(12345);
        }

        public int Next()
        {
            p = 1.0;
            k = 0;
            
            do
            {
                k++;
                p *= rng.Next();
            } while (p > L);

            return k - 1;
        }
    }
}
