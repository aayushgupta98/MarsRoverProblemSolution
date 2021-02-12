﻿using MarsRoverProblemSolution.Data.Entities;

namespace MarsRoverProblemSolution.Repository.Provider
{
    public interface Invoker
    {
        /// <summary>
        /// start rover movement
        /// </summary>
        /// <param name="command"></param>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        Coordinates StartMoving(Command command, Coordinates coordinates);
    }
}
