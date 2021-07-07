//pseudo-random number generator based on the Wichmann-Hill Alghorithm
//source: https://en.wikipedia.org/wiki/Wichmann–Hill

namespace RNG
{
    class WichmannRNG
    {
        private int s1;
        private int s2;
        private int s3;

        public WichmannRNG(int seed)
        {
            s1 = seed;
            s2 = seed + 1;
            s3 = seed + 2;
        }

        public double Next()//returns the value from (0,1)
        {
            s1 = 171 * (s1 % 177) - 2 * (s1 / 177);
            if (s1 < 0) s1 += 30269;
            s2 = 172 * (s2 % 176) - 35 * (s2 / 176);
            if (s2 < 0) s2 += 30307;
            s3 = 170 * (s3 % 178) - 63 * (s3 / 178);
            if (s3 < 0) s3 += 30323;
            double r = (s1 * 1.0) / 30269 + (s2 * 1.0) / 30307 + (s3 * 1.0) / 30323;
            return r % 1.0;
        }


        public int randomInt(int min, int max)//returns int [min, max)
        {
            double x = Next();

            return (int)((max - min) * x + min);
        }
    }
}
