using MarsRoverProblemSolution.Data.Entities;
using MarsRoverProblemSolution.Repository.Provider;

namespace MarsRoverProblemSolution.Service.Provider
{
    public interface IMarsRoverProblemSolutionService
    {
        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement, Invoker _invoker);
    }
}
