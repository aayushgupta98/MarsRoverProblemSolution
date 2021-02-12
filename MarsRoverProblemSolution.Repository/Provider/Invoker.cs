using MarsRoverProblemSolution.Data.Entities;

namespace MarsRoverProblemSolution.Repository.Provider
{
    public interface Invoker
    {
        Coordinates StartMoving(Command command);
    }
}
