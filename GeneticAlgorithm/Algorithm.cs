//-----------------------------------------------------------------------
// <copyright file="Algorithm.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------
namespace GeneticAlgorithm
{
    using System;
    using GeneticAlgorithm.Helper;

    /// <summary>
    /// Implementation of Genetic algorithm
    /// </summary>
    public class Algorithm
    {
        #region Fields
        private readonly GeneticProps _geneticProps;
        #endregion

        #region Constructors
        public Algorithm(GeneticProps geneticProps)
        {
            _geneticProps = geneticProps;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Genetic algorithm default constructor
        /// </summary>
        /// <param name="population">population is source to execute Genetic algorithm</param>
        /// <returns></returns>
        public Population EvolvePopulation(Population population)
        {
            var newPopulation = new Population(_geneticProps, population.Size());

            #region Crossover

            var crossover = new Crossover(_geneticProps);

            // Generate chromosomes
            for (var i = 0; i < population.Size(); i++)
            {
                // Random selection of chromosome from provided population
                var firstChromosome = RandomSelection(population);
                var secondChromosome = RandomSelection(population);

                var newChromosome = crossover.Process(firstChromosome, secondChromosome);
                newPopulation.SaveChromosome(i, newChromosome);
            }
            #endregion

            #region Mutation

            var mutation = new Mutation(_geneticProps);
            for (var i = 0; i < newPopulation.Size(); i++)
            {
                mutation.Mutate(newPopulation.GetIndividual(i));
            }

            return newPopulation;

            #endregion

        }


        /// <summary>
        /// Random selection of chromosome
        /// </summary>
        /// <param name="population">population of Genetic algorithm</param>
        /// <returns></returns>
        private Chromosome RandomSelection(Population population)
        {
            // Creation of population based on Tournament size
            var newPopulation = new Population(_geneticProps, _geneticProps.TournamentSize);

            for (var i = 0; i < _geneticProps.TournamentSize; i++)
            {
                var randomIndex = Util.GetRandom(population.Size());
                newPopulation.SaveChromosome(i, population.GetIndividual(randomIndex));
            }

            var fittestChromosome = newPopulation.GetFittestChromosome();
            return fittestChromosome;
        }
        #endregion
    }
}
