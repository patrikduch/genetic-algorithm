//-----------------------------------------------------------------------
// <copyright file="MainWindow.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------

using System;
using GeneticAlgorithm;

namespace Desktop
{
    
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void SetupWindow()
        {
            Top = 0;
            Left = 0;

            var tmp = SystemParameters.WorkArea.Width;
            var to = SystemParameters.WorkArea.Height;

            Width = tmp;
            Height = to;

            Title = "Genetic algorithm";
        }
        public MainWindow()
        {
            
            InitializeComponent();
            SetupWindow();
        }


        private void ProcessGeneticAlgorithm(object sender, RoutedEventArgs e)
        {

            // Process input
            var res = inputTextBox.Text.Split(',');
            var array = Array.ConvertAll(res, int.Parse);

            // Genetic algorithm properties
            var geneticProps = new GeneticProps(array);
            var population = new Population(geneticProps,1000000);
            // Population initialization
            population.Initialize();

            // Genetic algorithm process
            var algorithm = new Algorithm(geneticProps);

            while (population.GetFittestChromosome().GetFitness() != geneticProps.MaxFitness)
            {
                population = algorithm.EvolvePopulation(population);

            }

            // Save the result
            var result = population.GetFittestChromosome();

            // Transform result into UI
            resultLabel.Content = result.ToString();

        }
    }
}
