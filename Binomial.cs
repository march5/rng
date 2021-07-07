//To generate a Binomial distributed numbers we wiil use the Bernulli generetor
//The Binomial number will be the number of 1s we get in n Bernoulli draws
namespace RNG
{
    class Binomial
    {
        double p;//probability
        long n;//number of Bernoulli attempts

        Bernoulli b;

        public Binomial(long size, double x)//we specify the n and p value
        {
            n = size;
            p = x;
            b = new Bernoulli(x);//and call the Benroulli distribution function with the proper x value
        }

        public double Next()
        {
            long result = 0;
            
            for(int i = 0; i < n; i++)//then we run n Bernoulli draws and count the 1s
            {
                if (b.Next() == 1) result++;
            }

            return result;
        }
    }
}
