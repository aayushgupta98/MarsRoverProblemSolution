using MarsRoverProblemSolution.Data.Entities;

namespace MarsRoverProblemSolution.Repository.Invoker
{
    public class ExecuteAction : Provider.Invoker
    {
        /// <summary>
        /// start movement of rover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Coordinates StartMoving(Provider.Command command, Coordinates coordinates)
        {
            return command.Execute(coordinates);
        }
    }
}
