using MarsRoverProblemSolution.Data.Entities;
using MarsRoverProblemSolution.Repository.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRoverProblemSolution.Service.Provider
{
    public interface IMarsRoverProblemSolutionService
    {
        /// <summary>
        /// register services for DI implementation
        /// </summary>
        /// <param name="services"></param>
        /// <param name="_serviceProvider"></param>
        void RegisterServices(ServiceCollection services);

        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement);

        //TODO: Remove this method, its only used for unit test purpose

        /// <summary>
        /// temporarily using this method for making this file unit testable
        /// </summary>
        /// <param name="invoker"></param>
        void SetInvokerForUnitTest(Invoker invoker);
    }
}
