using System;
using Accord.Statistics.Testing;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Visualizations;
using Accord.Controls;
using System.Windows;

namespace RNG
{
    class Program
    {

        static void testG()
        {
            double[] array10 = new double[10];
            double[] array100 = new double[100];

            //Kolmogorow-Smirnow Test
            //generator G
            
            Console.WriteLine("Kolmogorov-Smirnov Test for Uniform Discrete Distribution (generator G)");

            
            WichmannRNG rng = new WichmannRNG(12345);

            for(int i = 0; i < 100; i++)
            {
                if(i < 10)
                array10[i] = rng.randomInt(0, 10);//sample 1
                array100[i] = rng.randomInt(0, 100);//sample 2
            }

            //we generate the uniform distribution, to compare our G generator with
            var distribution = new UniformDiscreteDistribution(0,9);

            var kstest = new KolmogorovSmirnovTest(array10, distribution);

            Console.WriteLine("Generator G - K-S Test [0,9] - 10 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            distribution = new UniformDiscreteDistribution(0, 99);//second test

            kstest = new KolmogorovSmirnovTest(array100, distribution);

            Console.WriteLine("Generator G - K-S Test [0,99] - 100 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            Console.WriteLine();
        }

        static void testJ()
        {
            double[] array10 = new double[10];
            double[] array100 = new double[100];

            //Kolmogorow-Smirnow Test
            //generator J

            Console.WriteLine("Kolmogorov-Smirnov Test for Uniform Continous Distribution (generator J)");


            WichmannRNG rng = new WichmannRNG(12345);

            for(int i =0; i < 100; i++)
            {
                if(i < 10)
                array10[i] = rng.Next();
                array100[i] = rng.Next();
            }
            var distribution = UniformContinuousDistribution.Standard;

            var kstest = new KolmogorovSmirnovTest(array10, distribution);

            Console.WriteLine("Generator J - K-S Test - 10 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            kstest = new KolmogorovSmirnovTest(array100, distribution);

            Console.WriteLine("Generator J - K-S Test - 100 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            Console.WriteLine();

        }

        static void testB()
        {
            int[] array = { 0, 0 };
            int x;
            //Kolmogorow-Smirnow Test
            //Generator B

            Console.WriteLine("Kolmogorov-Smirnov Test for Bernoulli Distribution (generator B)");


            Bernoulli bernoulli = new Bernoulli(0.5);

            for(int i = 0; i < 100; i++)
            {
                x = bernoulli.Next();
                array[x]++;
            }

            double D = Math.Abs(0.5 - ((double)array[0] / 100));
            double d = Math.Abs(0.5 - ((double)array[1] / 100));
            if (d > D) D = d;

            double pValue = 1.36 / Math.Sqrt(100);//out of K-S Test P-Value Table

            bool isRejected;
            if (D < pValue) isRejected = false;
            else isRejected = true;

            Console.WriteLine("Generator B - K-S Test p = 0.5 - 100 values");
            Console.WriteLine("Statistic: " + D + " p Value: " + pValue);
            Console.WriteLine("Is rejected: " + isRejected);

            bernoulli = new Bernoulli(0.2);
            array[0] = 0;
            array[1] = 0;

            for (int i = 0; i < 100; i++)
            {
                x = bernoulli.Next();
                array[x]++;
            }

            D = Math.Abs(0.8 - ((double)array[0] / 100));
            d = Math.Abs(0.2 - ((double)array[1] / 100));
            if (d > D) D = d;

            if (D < pValue) isRejected = false;
            else isRejected = true;

            Console.WriteLine("Generator B - K-S Test p = 0.2 - 100 values");
            Console.WriteLine("Statistic: " + D + " p Value: " + pValue);
            Console.WriteLine("Is rejected: " + isRejected);

            Console.WriteLine();

        }

        static void testD()
        {
            double[] array10 = new double[10];

            //Kolmogorow-Smirnow Test
            //Generator D

            Console.WriteLine("Kolmogorov-Smirnov Test for Binomial Distribution (generator D)");


            Binomial binomial = new Binomial(100,0.5);

            for(int i = 0; i < 10; i++)
            {
                array10[i] = binomial.Next();
            }

            var distribution = new BinomialDistribution(100, 0.5);

            var kstest = new KolmogorovSmirnovTest(array10, distribution);

            Console.WriteLine("Generator D - K-S Test p = 0.5 - 100 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            binomial = new Binomial(100, 0.2);
            for (int i = 0; i < 10; i++)
            {
                array10[i] = binomial.Next();
            }

            distribution = new BinomialDistribution(100, 0.2);

            kstest = new KolmogorovSmirnovTest(array10, distribution);

            Console.WriteLine("Generator D - K-S Test p = 0.2 - 100 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            Console.WriteLine();

        }

        static void testP()
        {
            double[] array10 = new double[100];
            double[] array20 = new double[20];

            //Kolmogorow-Smirnow Test
            //Generator P

            Console.WriteLine("Kolmogorov-Smirnov Test for Poisson Distribution (generator P)");


            Poisson poisson = new Poisson(50);

            for (int i = 0; i < 100; i++)
            {
                array10[i] = poisson.Next();
            }

            var distribution = new PoissonDistribution(50);

            var kstest = new KolmogorovSmirnovTest(array10, distribution);

            Console.WriteLine("Generator P - K-S Test lambda = 50 - 100 values ");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            poisson = new Poisson(10);

            for (int i = 0; i < 20; i++)
            {
                array20[i] = poisson.Next();
            }

            distribution = new PoissonDistribution(10);

            kstest = new KolmogorovSmirnovTest(array20, distribution);

            Console.WriteLine("Generator P - K-S Test lambda = 10 - 20 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            Console.WriteLine();

        }

        static void testW()
        {
            double[] array10 = new double[10];
            double[] array100 = new double[100];


            //Kolmogorow-Smirnow Test
            //Generator W

            Console.WriteLine("Kolmogorov-Smirnov Test for Exponential Distribution (generator W)");


            Exponential exp = new Exponential();

            for(int i = 0; i < 100; i++)
            {
                if(i < 10)
                array10[i] = exp.Next();
                array100[i] = exp.Next();
            }

            var distribution = new ExponentialDistribution();

            var kstest = new KolmogorovSmirnovTest(array10, distribution);

            Console.WriteLine("Generator W - K-S Test lambda = 1 - 10 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            kstest = new KolmogorovSmirnovTest(array100, distribution);

            Console.WriteLine("Generator W - K-S Test lambda = 1 - 100 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            Console.WriteLine();

        }

        static void testN()
        {
            double[] array10 = new double[10];
            double[] array100 = new double[100];


            //Kolmogorow-Smirnow Test
            //Generator N

            Console.WriteLine("Kolmogorov-Smirnov Test for Normal Distribution (generator N)");


            Normal normal = new Normal();

            for(int i = 0; i < 100; i++)
            {
                if (i < 10)
                    array10[i] = normal.Next();
                array100[i] = normal.Next();
            }

            var distribution = new NormalDistribution();

            var kstest = new KolmogorovSmirnovTest(array10, distribution);

            Console.WriteLine("Generator N - K-S Test - 10 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            kstest = new KolmogorovSmirnovTest(array100, distribution);

            Console.WriteLine("Generator N - K-S Test - 100 values");
            Console.WriteLine("Statistic: " + kstest.Statistic + " p Value: " + kstest.PValue);
            Console.WriteLine("Is rejected: " + kstest.Significant);

            Console.WriteLine();

        }

        static void writeArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            
            Console.WriteLine();
        }

        static void writeArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.WriteLine();
        }

        static void Bexample()
        {
            //B example
            Bernoulli bernoulli = new Bernoulli(0.5);
            Bernoulli bernoulli8 = new Bernoulli(0.8);

            int x;
            int[] a = { 0, 0 };
            int[] b = { 0, 0 };

            for(int i =0; i < 1000;i++)
            {
                x = bernoulli.Next();
                a[x]++;

                x = bernoulli8.Next();
                b[x]++;
            }

            Console.WriteLine("Benroulli p = 0.5, 1000 losowań \n Ilość zer: " + a[0] + " ilość jedynek: " + a[1]);
            Console.WriteLine("Benroulli p = 0.8, 1000 losowań \n Ilość zer: " + b[0] + " ilość jedynek: " + b[1]);
        }

        static void Dexample()
        {
            //D example
            Binomial bin = new Binomial(40, 0.5);

            Console.WriteLine("Generator D n = 40, p = 0.5");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(bin.Next() + " ");
            }
        }

        static void Pexample()
        {
            //P example
            Poisson p = new Poisson(10);
            int[] a = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int x;

            Console.WriteLine("Generator P lambda = 10, 10 000 values generated \n Amount of values from 5 - 14");

            for (int i = 0; i < 10000; i++)
            {
                x = p.Next();
                if (x < 15 && x >= 5) a[x - 5]++;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Write(a[i] + " ");
            }
        }

        static void Main(string[] args)
        {

            //Bexample();

            //Dexample();

            //Pexample();
            
            Console.WriteLine("K-S Tests for implemented distributions.");
            testG();
            testJ();
            testB();
            testD();
            testP();
            testW();
            testN();

        }
    }
}
