﻿using MarsRoverProblemSolution.Data.Constants;
using MarsRoverProblemSolution.Data.Entities;
using MarsRoverProblemSolution.Repository.Command;
using MarsRoverProblemSolution.Repository.Provider;
using MarsRoverProblemSolution.Tests.MockObjects;
using Xunit;

namespace MarsRoverProblemSolution.Tests.RepositoryTest
{
    public class MoveRightTest
    {
        /// <summary>
        /// command reference
        /// </summary>
        private readonly Command _command;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public MoveRightTest()
        {
            _command = new MoveRight();
        }

        /// <summary>
        /// test for Execute method
        /// </summary>
        /// <param name="directions"></param>
        [Theory]
        [InlineData(Directions.N)]
        [InlineData(Directions.E)]
        [InlineData(Directions.S)]
        [InlineData(Directions.W)]
        public void Execute_Test(Directions directions)
        {
            //Arrange
            var coordinates = MockData.Coordinates();
            switch (directions)
            {
                case Directions.N:
                    coordinates.Dir = Directions.N;
                    break;

                case Directions.E:
                    coordinates.Dir = Directions.E;
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.S;
                    break;

                case Directions.W:
                    coordinates.Dir = Directions.W;
                    break;
            }

            //Act
            var result = _command.Execute(coordinates);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(coordinates, result);
        }
    }
}
