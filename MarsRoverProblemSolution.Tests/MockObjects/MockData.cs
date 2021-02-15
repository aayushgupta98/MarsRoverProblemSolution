using MarsRoverProblemSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProblemSolution.Tests.MockObjects
{
    public static class MockData
    {
        public static string[] MaxPoints = { "5", "5" };

        public static string[] CurrentLocation = { "1", "2", "N" };

        public static string Movement = "LMLMLMLMM";

        public static Coordinates Coordinates()
        {
            return new Coordinates
            {
                X = 1,
                Y = 2,
                Dir = Data.Constants.Directions.N
            };
        }

        public static List<int> MaxLst => new List<int> { 5, 5 };
    }
}
