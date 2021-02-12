using MarsRoverProblemSolution.Data.Entities;

namespace MarsRoverProblemSolution.Repository.Provider
{
    public interface Command
    {
        public Coordinates Execute();
    }
}
