using FakeItEasy;
using MarsRoverProblemSolution.Data.Entities;
using MarsRoverProblemSolution.Repository.Invoker;
using MarsRoverProblemSolution.Repository.Provider;
using MarsRoverProblemSolution.Tests.MockObjects;
using Xunit;

namespace MarsRoverProblemSolution.Tests.RepositoryTest
{
    public class ExecuteActionTest
    {
        /// <summary>
        /// command reference
        /// </summary>
        private readonly Command _command;

        /// <summary>
        /// invoker reference
        /// </summary>
        private readonly Invoker _invoker;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public ExecuteActionTest()
        {
            _command = A.Fake<Command>();
            _invoker = new ExecuteAction();
        }

        /// <summary>
        /// test for StartMovingSync
        /// </summary>
        [Fact]
        public void StartMovingSync_Test()
        {
            //Arrange
            var coordinates = MockData.Coordinates();
            A.CallTo(() => _command.Execute(A<Coordinates>._)).ReturnsLazily(() => coordinates);

            //Act
            var result = _invoker.StartMoving(_command, coordinates);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, coordinates);
        }
    }
}
