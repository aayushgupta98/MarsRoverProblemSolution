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
        /// 
        /// </summary>
        private Invoker _invoker;

        /// <summary>
        /// register services for DI implementation
        /// </summary>
        /// <param name="services"></param>
        /// <param name="_serviceProvider"></param>
        public void RegisterServices(ServiceCollection services)
        {
            services.AddSingleton<Invoker, ExecuteAction>();
            var _serviceProvider = services.BuildServiceProvider(true);
            _invoker = _serviceProvider.GetService<Invoker>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        public Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement)
        {
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
                        command = new MoveLeft(coordinates.Dir);
                        coordinates.Dir = _invoker.StartMoving(command).Dir;
                        break;

                    case 'R':
                        command = new MoveRight(coordinates.Dir);
                        coordinates.Dir = _invoker.StartMoving(command).Dir;
                        break;

                    case 'M':
                        command = new MoveForward(coordinates.X, coordinates.Y, coordinates.Dir, maxLst);
                        var c = _invoker.StartMoving(command);
                        coordinates.X = c.X;
                        coordinates.Y = c.Y;
                        break;

                    default:
                        return null;
                }
            }
            return coordinates;
        }
    }
}
