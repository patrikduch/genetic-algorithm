//-----------------------------------------------------------------------
// <copyright file="Util.cs" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------

namespace GeneticAlgorithm.Helper
{
    using System;

    /// <summary>
    /// Helper random generator utility
    /// </summary>
    public static class Util
    {
        private static Random rnd = new Random(DateTime.Today.Millisecond);
        public static int GetRandom(int boundary)
        {
            return rnd.Next(0, boundary);
        }
        public static int GetRandomAll()
        {
            return rnd.Next();
        }

    }
}
