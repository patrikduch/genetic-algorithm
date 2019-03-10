//-----------------------------------------------------------------------
// <copyright file="Mutation.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------

namespace GeneticAlgorithm
{
    using Helper;

    /// <summary>
    /// Mutation process of Genetic algorithm
    /// </summary>
    public class Mutation
    {

        #region Fields
        /// <summary>
        /// Setup configuration for Genetic algorithm
        /// </summary>
        private readonly GeneticProps _geneticProps;
        #endregion

        #region Constructors
        public Mutation(GeneticProps geneticProps)
        {
            _geneticProps = geneticProps;
        }
        #endregion

        #region Methods
        public void Mutate(Chromosome getIndividual)
        {
            for (var i = 0; i < _geneticProps.ChromosomeLength; i++)
            {
                if (!(Util.GetRandomAll() <= _geneticProps.MutationRate)) continue;
                int gene = Util.GetRandom(_geneticProps.ChromosomeLength + 1);
                getIndividual.SetGene(i, gene);
            }
        }
        #endregion
    }
}
