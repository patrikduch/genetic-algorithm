//-----------------------------------------------------------------------
// <copyright file="Population.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------

namespace GeneticAlgorithm
{
    /// <summary>
    /// Population which is source for Genetic algorithm
    /// </summary>
    public class Population
    {
        #region Fields
        private readonly Chromosome[] _chromosomes;
        private readonly GeneticProps _geneticProps;
        #endregion

        #region Constructors
        public Population(GeneticProps geneticProps, int populationSize)
        {
            _geneticProps = geneticProps;
            _chromosomes = new Chromosome[populationSize];
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialization of population for Genetic algorithm
        /// </summary>
        public void Initialize()
        {
            for (var i = 0; i < _chromosomes.Length; i++)
            {
                // With every iteration we create new chromosome
                var newChromozone = new Chromosome(_geneticProps);
                newChromozone.GenerateIndividual();
                SaveChromosome(i, newChromozone);
            }
        }

        /// <summary>
        /// Get specific chromosome by its index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Chromosome GetIndividual(int index)
        {
            return _chromosomes[index];
        }

        /// <summary>
        /// Match counter (current vs searched)
        /// </summary>
        /// <returns></returns>
        public Chromosome GetFittestChromosome()
        {
            // Get chromosome fittest
            var fittest = _chromosomes[0];

            // While iteration we skip the first on which is applied fittes
            for (var i = 1; i < _chromosomes.Length; i++)
            {
                if (GetIndividual(i).GetFitness() >= fittest.GetFitness())
                {
                    fittest = GetIndividual(i);
                }
            }

            return fittest;

        }

        /// <summary>
        /// Get size of current population
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return _chromosomes.Length;
        }

        /// <summary>
        /// Manipulation within chromosome population
        /// </summary>
        /// <param name="index"></param>
        /// <param name="chromosome"></param>
        public void SaveChromosome(int index, Chromosome chromosome)
        {
            _chromosomes[index] = chromosome;
        }
        #endregion
    }
}
