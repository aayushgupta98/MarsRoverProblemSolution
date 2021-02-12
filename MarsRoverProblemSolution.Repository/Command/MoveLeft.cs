using MarsRoverProblemSolution.Data.Constants;
using MarsRoverProblemSolution.Data.Entities;

namespace MarsRoverProblemSolution.Repository.Command
{
    public class MoveLeft : Provider.Command
    {
        /// <summary>
        /// 
        /// </summary>
        private Directions direction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theDirection"></param>
        public MoveLeft(Directions theDirection)
        {
            direction = theDirection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Coordinates Execute()
        {
            var coordinates = new Coordinates();
            coordinates.Dir = direction;
            switch (direction)
            {
                case Directions.N:
                    coordinates.Dir = Directions.W;
                    break;

                case Directions.E:
                    coordinates.Dir = Directions.N;
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.E;
                    break;

                case Directions.W:
                    coordinates.Dir = Directions.S;
                    break;
            }
            return coordinates;
        }
    }
}
