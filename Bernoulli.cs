
namespace RNG
{
    class Bernoulli//Bernoulli distribution is a distribution which takes the value 1 with probability p and 0 with probability 1 - p
    {
        double p;
        double x;
        WichmannRNG rng;

        public Bernoulli()//default constructor with .5 probability
        {
            p = 0.5;
            rng = new WichmannRNG(12345);//here we call the base generator
        }

        public Bernoulli(double x)//constructor with custom probability
        {
            p = x;
            rng = new WichmannRNG(12345);
        }

        public int Next()//to get the bernoulli distributed number we generate the number from (0,1) range, then based on the p probability we return the proper value
        {
            x = rng.Next();

            if (x < p) return 1;
            else return 0;
        }
    }
}
