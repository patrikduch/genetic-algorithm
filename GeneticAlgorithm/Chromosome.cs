//-----------------------------------------------------------------------
// <copyright file="Chromosome.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------

using System;
using System.Text;
using GeneticAlgorithm.Helper;

namespace GeneticAlgorithm
{
    /// <summary>
    /// Representation of possible outcome
    /// </summary>
    public class Chromosome
    {
        #region Fields

        /// <summary>
        /// Every chromosome is created by genes
        /// </summary>
        private int[] _genes;
        /// <summary>
        /// Actual fitness value of specific chromosome
        /// </summary>
        private int _fitness;
        /// <summary>
        /// Random generator of values
        /// </summary>
        private Random _randomGenerator;

        /// <summary>
        /// Setup of Genetic algorithm
        /// </summary>
        private readonly GeneticProps _geneticProps;

        #endregion

        #region Constructors
        public Chromosome(GeneticProps geneticProps)
        {
            _geneticProps = geneticProps;
            _genes = new int[_geneticProps.ChromosomeLength];
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gene generator by size of chromosome
        /// </summary>
        public void GenerateIndividual()
        {
            for (var i = 0; i < _geneticProps.ChromosomeLength; i++)
            {
                _randomGenerator = new Random(DateTime.Today.Millisecond);

                var gene = Util.GetRandom(10);
                _genes[i] = gene;
            }
        }

        /// <summary>
        /// Get fitness value
        /// </summary>
        /// <returns></returns>
        public int GetFitness()
        {
            if (_fitness != 0) return _fitness;

            // We must iterate throught all indexes

            for (var i = 0; i < _geneticProps.ChromosomeLength; i++)
            {
                if (GetGene(i) == _geneticProps.Solution[i]) // Match was founded
                {
                    _fitness++;
                }
            }

            return _fitness;
        }

        /// <summary>
        /// Get gene by its index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetGene(int index)
        {
            return _genes[index];

        }

        /// <summary>
        /// Set gene by its index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetGene(int index, int value)
        {
            _genes[index] = value;

            // Fitness reset
            _fitness = 0;
        }


        /// <summary>
        /// Auxiliary method for development purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var gene in _genes)
            {
                sb.Append(gene);
                sb.Append(",");
            }

            return sb.ToString();
        }


        #endregion
    }
}
