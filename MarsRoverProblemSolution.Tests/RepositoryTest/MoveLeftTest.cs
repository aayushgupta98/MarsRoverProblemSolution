using MarsRoverProblemSolution.Data.Constants;
using MarsRoverProblemSolution.Data.Entities;
using MarsRoverProblemSolution.Repository.Command;
using MarsRoverProblemSolution.Repository.Provider;
using MarsRoverProblemSolution.Tests.MockObjects;
using Xunit;

namespace MarsRoverProblemSolution.Tests.RepositoryTest
{
    public class MoveLeftTest
    {
        /// <summary>
        /// command reference
        /// </summary>
        private readonly Command _command;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public MoveLeftTest()
        {
            _command = new MoveLeft();
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
            var coordinates = MockData.Coordinates();
            var result = new Coordinates();
            switch (directions)
            {
                case Directions.N:
                    coordinates.Dir = Directions.N;
                    result = _command.Execute(coordinates);
                    Assert.Equal(Directions.W, result.Dir);
                    break;

                case Directions.E:
                    coordinates.Dir = Directions.E;
                    result = _command.Execute(coordinates);
                    Assert.Equal(Directions.N, result.Dir);
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.S;
                    result = _command.Execute(coordinates);
                    Assert.Equal(Directions.E, result.Dir);
                    break;

                case Directions.W:
                    coordinates.Dir = Directions.W;
                    result = _command.Execute(coordinates);
                    Assert.Equal(Directions.S, result.Dir);
                    break;
            }
            Assert.NotNull(result);
        }
    }
}
