using MarsRoverProblemSolution.Data.Constants;
using MarsRoverProblemSolution.Data.Entities;
using MarsRoverProblemSolution.Repository.Command;
using MarsRoverProblemSolution.Repository.Invoker;
using MarsRoverProblemSolution.Repository.Provider;
using MarsRoverProblemSolution.Service.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MarsRoverProblemSolution.Service
{
    public class MarsRoverProblemSolutionService : IMarsRoverProblemSolutionService
    {
        /// <summary>
        /// instance for Invoker
        /// </summary>
        private Invoker _invoker;

        /// <summary>
        /// register services for DI implementation
        /// </summary>
        /// <param name="services"></param>
        /// <param name="_serviceProvider"></param>
        private void RegisterServices(ServiceCollection services)
        {
            services.AddSingleton<Invoker, ExecuteAction>();
            var _serviceProvider = services.BuildServiceProvider(true);
            _invoker = _serviceProvider.GetService<Invoker>();
        }

        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        public Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement, ServiceCollection services)
        {
            var _invoker = new ExecuteAction();
            var maxLst = new List<int>();
            foreach (var m in maxPoints)
            {
                var maxCoordinate = Convert.ToInt32(m);
                maxLst.Add(maxCoordinate);
            }
            var coordinates = new Coordinates();
            coordinates.X = Convert.ToInt32(currentLocation[0]);
            coordinates.Y = Convert.ToInt32(currentLocation[1]);
            coordinates.Dir = currentLocation[2].ToEnumValue<Directions>();
            Command command;

            foreach (var dir in movement)
            {
                switch (dir)
                {
                    case 'L':
                        command = new MoveLeft();
                        break;

                    case 'R':
                        command = new MoveRight();
                        break;

                    case 'M':
                        command = new MoveForward(maxLst);
                        break;

                    default:
                        return null;
                }
                RegisterServices(services);
                var c = _invoker.StartMoving(command, coordinates);
                
                if (c == null)
                    return null;

                coordinates.Dir = c.Dir;
                coordinates.X = c.X;
                coordinates.Y = c.Y;
            }
            return coordinates;
        }
    }
}
