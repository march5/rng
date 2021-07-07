using System;
//Normal distributed variables are generated using Box-Muller method
namespace RNG
{
    class Normal
    {
        double X;
        double Y;
        int xyTaken = 2;
        WichmannRNG rng;

        public Normal()
        {
            rng = new WichmannRNG(12345);
        }

        private void getXY()//first we generate two independent numbers u, v from the given formula, these will have the standard normal distribution
        {
            double u,v;

            u = rng.Next();
            v = rng.Next();

            X = (double)Math.Sqrt(-2 * Math.Log(u)) * Math.Cos(2 * 3.14 * v);
            Y = (double)Math.Sqrt(-2 * Math.Log(u)) * Math.Sin(2 * 3.14 * v);
        }

        public double Next()//then we take and return the not yet used value, or when both were used we generate the new ones
        {
            if(xyTaken == 2)
            {
                xyTaken = 0;
                getXY();
            }


            if (xyTaken == 0)
            {
                xyTaken++;
                return X;
            }
            else if (xyTaken == 1)
            {
                xyTaken++;
                return Y;
            }

            return -1;
        }
    }
}
