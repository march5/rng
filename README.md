# rng
## Pseudo-random number generators with various distributions

The following codes are the university project I made on the pseudo-random numbers generators, with Program.cs file being the main file.
The task was to create a pseudo-random number generator of evenly distributed variables without using any built in random generating functions or the system clock.
The first two generators are the generator of evenly distributed variables and a generator with uniform distributed variables from range of (0,1) (called the G and J generator in terms of the project).
The two first generators are created using the **Wichmann-Hill** algorithm. It is located in WichmannRNG.cs file.

Then I was supposed to create various generators with different distributions using the J generator, which are the following:

* B generator (Benroulli distribution):
  Very simple generator, we take the probability p of getting the 1 value, then we generate a random variable using the J generator. If the generated value is less than p then we  return 1, else we return 0.
* D generator (Binomial distribution): It is made based on the B generator, where for the given probability p and the number of tests we return the number of tests succeeded (1s returned).
* P generator (Poisson distribution): This generetor is based on the Knuth's algorithm (https://en.wikipedia.org/wiki/Poisson_distribution#Computational_methods).
* W generator (Exponential distribution): Based on the computional methd given here https://en.wikipedia.org/wiki/Exponential_distribution#Generating_exponential_variates.
* N generator (Normal distribution): I used the Box-Muller method. We use the given formula to generate two variables with normal distribution that are independent, then we return them as the generated numbers.


## Testing

To test the above generators I used the Kolmogorow-Smirnow Goodness of fit test, which compares the sample with a reference probability distribution.
In the main program file there are some example tests for every generator (testG function, etc.).

The generators could use some randomness test beside the distributions consistency tests, but I ran out of time for the project because of the exams.
  
  
   


