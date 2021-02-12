using MarsRoverProblemSolution.Data.Entities;

namespace MarsRoverProblemSolution.Repository.Invoker
{
    public class ExecuteAction : Provider.Invoker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Coordinates StartMoving(Provider.Command command)
        {
            return command.Execute();
        }
    }
}
