using MarsRoverProblemSolution.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

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
        Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement, ServiceCollection services);
    }
}
