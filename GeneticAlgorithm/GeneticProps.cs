//-----------------------------------------------------------------------
// <copyright file="GeneticProps.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------

namespace GeneticAlgorithm
{
    /// <summary>
    /// Properties for genetic algorithm (such as searched result, chromosome length etc)
    /// </summary>
    public class GeneticProps
    {

        #region Constructors
        /// <summary>
        /// Instance of Genetic algorithm configuration
        /// </summary>
        /// <param name="solution">Searched solution</param>
        public GeneticProps(int[] solution)
        {
            Solution = solution;
            CrossoverRate = 0.5;
            MutationRate = 0.15;
            TournamentSize = 5;

            MaxFitness = Solution.Length;
            ChromosomeLength = solution.Length;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Sequence for searching
        /// </summary>
        public int[] Solution { get; set; }

        /// <summary>
        /// Rate of crossover process
        /// </summary>
        public double CrossoverRate { get; set; }

        /// <summary>
        /// Rate for mutation process
        /// </summary>
        public double MutationRate { get; set; }

        /// <summary>
        /// Tournament size
        /// </summary>
        public int TournamentSize { get; set; }

        /// <summary>
        /// Max fitness is equal to  length of searched sequence set
        /// </summary>
        public int MaxFitness { get; }

        /// <summary>
        /// Max fitness is equal to  length of chromosome length
        /// </summary>
        public int ChromosomeLength { get; }

        #endregion
    }
}
