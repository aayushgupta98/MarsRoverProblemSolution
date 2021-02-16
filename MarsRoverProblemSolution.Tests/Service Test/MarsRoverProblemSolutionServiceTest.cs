using FakeItEasy;
using MarsRoverProblemSolution.Data.Entities;
using MarsRoverProblemSolution.Repository.Provider;
using MarsRoverProblemSolution.Service;
using MarsRoverProblemSolution.Service.Provider;
using MarsRoverProblemSolution.Tests.MockObjects;
using Xunit;

namespace MarsRoverProblemSolution.Tests.Service_Test
{
    public class MarsRoverProblemSolutionServiceTest
    {
        /// <summary>
        /// invoker reference
        /// </summary>
        private readonly Invoker _invoker;

        /// <summary>
        /// IMarsRoverProblemSolutionService reference
        /// </summary>
        private readonly IMarsRoverProblemSolutionService _marsRoverProblemSolutionService;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public MarsRoverProblemSolutionServiceTest()
        {
            _invoker = A.Fake<Invoker>();
            _marsRoverProblemSolutionService = new MarsRoverProblemSolutionService();
        }

        /// <summary>
        /// test for MoveRoverSync method
        /// </summary>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MoveRoverSync_Test(bool isCoordinateNull)
        {
            //Arrange
            var maxPoints = MockData.MaxPoints;
            var currentLocation = MockData.CurrentLocation;
            var movement = MockData.Movement;
            var coordinates = MockData.Coordinates();
            if (!isCoordinateNull)
                A.CallTo(() => _invoker.StartMoving(A<Command>._, A<Coordinates>._)).ReturnsLazily(() => coordinates);
            else
                A.CallTo(() => _invoker.StartMoving(A<Command>._, A<Coordinates>._)).ReturnsLazily(() => null);

            //Act
            var result = _marsRoverProblemSolutionService.MoveRoverSync(maxPoints, currentLocation, movement, _invoker);

            //Assert
            if (!isCoordinateNull)
            {
                Assert.NotNull(result);
                Assert.Equal(coordinates.X, result.X);
                Assert.Equal(coordinates.Y, result.Y);
                Assert.Equal(coordinates.Dir, result.Dir);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}
