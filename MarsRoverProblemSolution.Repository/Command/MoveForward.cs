using MarsRoverProblemSolution.Data.Constants;
using MarsRoverProblemSolution.Data.Entities;
using System;
using System.Collections.Generic;

namespace MarsRoverProblemSolution.Repository.Command
{
    public class MoveForward : Provider.Command
    {
        /// <summary>
        /// 
        /// </summary>
        private Directions direction;

        /// <summary>
        /// 
        /// </summary>
        private int x = 0;

        /// <summary>
        /// 
        /// </summary>
        private int y = 0;

        /// <summary>
        /// 
        /// </summary>
        private List<int> maxLst = new List<int>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="theDirection"></param>
        /// <param name="maxLst"></param>
        public MoveForward(int x, int y, Directions theDirection, List<int> maxLst)
        {
            direction = theDirection;
            this.x = x;
            this.y = y;
            this.maxLst = maxLst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Coordinates Execute()
        {
            var coordinates = new Coordinates();
            coordinates.X = x;
            coordinates.Y = y;
            switch (direction)
            {
                case Directions.N:
                    if (y >= maxLst[1])
                        RoverCantMove();
                    else
                        coordinates.Y = y + 1;
                    break;

                case Directions.E:
                    if (x >= maxLst[0])
                        RoverCantMove();
                    else
                        coordinates.X = x + 1;
                    break;

                case Directions.S:
                    if (y != 0)
                        coordinates.Y = y - 1;
                    else
                        RoverCantMove();
                    break;

                case Directions.W:
                    if (x != 0)
                        coordinates.X = x - 1;
                    else
                        RoverCantMove();
                    break;
            }
            return coordinates;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RoverCantMove()
        {
            Console.WriteLine("Can't Move");
        }
    }
}
