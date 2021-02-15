using MarsRoverProblemSolution.Data.Constants;
using MarsRoverProblemSolution.Data.Entities;
using System;
using System.Collections.Generic;

namespace MarsRoverProblemSolution.Repository.Command
{
    public class MoveForward : Provider.Command
    {
        /// <summary>
        /// maximum limit of rover
        /// </summary>
        private List<int> maxLst = new List<int>();

        /// <summary>
        /// constructor for using maxLst
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="theDirection"></param>
        /// <param name="maxLst"></param>
        public MoveForward(List<int> maxLst)
        {
            this.maxLst = maxLst;
        }

        /// <summary>
        /// execute movement
        /// </summary>
        /// <returns></returns>
        public Coordinates Execute(Coordinates coordinates)
        {
            switch (coordinates.Dir)
            {
                case Directions.N:
                    if (coordinates.Y >= maxLst[1])
                        coordinates = RoverCantMove();
                    else
                        coordinates.Y += 1;
                    break;

                case Directions.E:
                    if (coordinates.X >= maxLst[0])
                        coordinates = RoverCantMove();
                    else
                        coordinates.X += 1;
                    break;

                case Directions.S:
                    if (coordinates.Y != 0)
                        coordinates.Y -= 1;
                    else
                        coordinates = RoverCantMove();
                    break;

                case Directions.W:
                    if (coordinates.X != 0)
                        coordinates.X -= 1;
                    else
                        coordinates = RoverCantMove();
                    break;
            }
            return coordinates;
        }

        /// <summary>
        /// 
        /// </summary>
        private Coordinates RoverCantMove()
        {
            Console.WriteLine("Can't Move");
            return null;
        }
    }
}
