//-----------------------------------------------------------------------
// <copyright file="MainWindow.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------

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
            this.Top = 0;
            this.Left = 0;

            var tmp = SystemParameters.WorkArea.Width;
            var to = SystemParameters.WorkArea.Height;

            this.Width = tmp;

            //this.Width = SystemParameters.MaximizedPrimaryScreenWidth- SystemParameters.BorderWidth;
            //this.Height = SystemParameters.MaximumWindowTrackHeight;

            this.Height = to;

            this.Title = "Genetic algorithm";
        }
        public MainWindow()
        {
            
            InitializeComponent();
            SetupWindow();


        }
    }
}
