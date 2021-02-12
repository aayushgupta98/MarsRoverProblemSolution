using MarsRoverProblemSolution.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRoverProblemSolution.Service.Provider
{
    public interface IMarsRoverProblemSolutionService
    {
        /// <summary>
        /// register services for DI implementation
        /// </summary>
        /// <param name="services"></param>
        void RegisterServices(ServiceCollection services);

        Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement);
    }
}
