using MarsRoverProblemSolution.Data.Constants;
using MarsRoverProblemSolution.Repository.Command;
using MarsRoverProblemSolution.Repository.Provider;
using MarsRoverProblemSolution.Tests.MockObjects;
using System.Collections.Generic;
using Xunit;

namespace MarsRoverProblemSolution.Tests.RepositoryTest
{
    public class MoveForwardTest
    {
        /// <summary>
        /// command reference
        /// </summary>
        private readonly Command _command;

        /// <summary>
        /// max coordinates
        /// </summary>
        private readonly List<int> _maxLst;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public MoveForwardTest()
        {
            _maxLst = MockData.MaxLst;
            _command = new MoveForward(_maxLst);
        }

        /// <summary>
        /// test for execute
        /// </summary>
        /// <param name="directions"></param>
        [Theory]
        [InlineData(Directions.N)]
        [InlineData(Directions.E)]
        [InlineData(Directions.W)]
        [InlineData(Directions.S)]
        public void Execute_Test(Directions directions)
        {
            var coordinates = MockData.Coordinates();

            switch (directions)
            {
                case Directions.N:
                    coordinates.Dir = Directions.N;
                    break;

                case Directions.E:
                    coordinates.Dir = Directions.E;
                    break;

                case Directions.W:
                    coordinates.Dir = Directions.W;
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.S;
                    break;
            }
            var result = _command.Execute(coordinates);

            Assert.NotNull(result);
            Assert.Equal(coordinates, result);
        }

        /// <summary>
        /// test for Execute failure
        /// </summary>
        /// <param name="isYExceed"></param>
        /// <param name="isXExceed"></param>
        /// <param name="isYLess"></param>
        /// <param name="isXLess"></param>
        [Theory]
        [InlineData(true, false, false, false)]
        [InlineData(false, true, false, false)]
        [InlineData(false, false, true, false)]
        [InlineData(false, false, false, true)]
        [InlineData(true, true, false, false)]
        [InlineData(true, false, false, true)]
        [InlineData(false, true, true, false)]
        [InlineData(false, false, true, true)]
        public void ExecuteTest_Failure(bool isYExceed, bool isXExceed, bool isYLess, bool isXLess)
        {
            var coordinates = MockData.Coordinates();
            if (isYExceed)
            {
                coordinates.Y = 6;
                coordinates.Dir = Directions.N;
            }
            if (isXExceed)
            {
                coordinates.X = 6;
                coordinates.Dir = Directions.E;
            }
            if (isYLess)
            {
                coordinates.Y = 0;
                coordinates.Dir = Directions.S;
            }
            if (isXLess)
            {
                coordinates.X = 0;
                coordinates.Dir = Directions.W;
            }

            var result = _command.Execute(coordinates);

            Assert.Null(result);
        }
    }
}
