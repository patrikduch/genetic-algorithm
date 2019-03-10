//-----------------------------------------------------------------------
// <copyright file="Crossover.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------

namespace GeneticAlgorithm
{
    using Helper;

    /// <summary>
    /// Crossover process
    /// </summary>
    public class Crossover
    {
        #region Fields
        private readonly GeneticProps _geneticProps;
        #endregion

        #region Constructors
        public Crossover(GeneticProps geneticProps)
        {
            _geneticProps = geneticProps;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Crossover (for crossover we need exactly two chromosomes)
        /// </summary>
        /// <param name="firstChromosome">first chromosome</param>
        /// <param name="secondChromosome">second chromosome</param>
        /// <returns></returns>
        public Chromosome Process(Chromosome firstChromosome, Chromosome secondChromosome)
        {
            var newChromosome = new Chromosome(_geneticProps);

            for (var i = 0; i < _geneticProps.ChromosomeLength; i++)
            {
                newChromosome.SetGene(i,
                    Util.GetRandomAll() <= _geneticProps.CrossoverRate
                        ? firstChromosome.GetGene(i)
                        : secondChromosome.GetGene(i));
            }
            return newChromosome;
        }
        #endregion
    }
}
