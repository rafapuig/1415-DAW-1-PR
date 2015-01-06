using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego2048
{
    class Compacter
    {
        private Board _board;

        public Board Board
        {
            get { return _board; }
            protected set { _board = value; }
        }
        
        public Compacter(Board board)
        {
            this.Board = board;
        }
    
        //protected Horizontal

        protected void Compact(int initialRow, int initialColumn, int deltaH, int deltaV)
        {
            int i = initialRow;
            int j = initialColumn;

            while (this.Board.IsOutBoundsLocation(i, j))
            {
                //Si la posicion esta vacia, traer el siguente adjacente
                if (this.Board.IsEmpty(i, j))
                {
                    //Posicion de la Casilla siguiente en la direccion de busqueda
                    Location nextToSquareLocation = GetNextTo(i, j);  
                    
                    if (nextToSquareLocation != null)
                    {
                        Location compactingLocation = new Location(i, j);
                        this.Board.Move(compactingLocation, nextToSquareLocation);
                    }
                    i += deltaH;
                    j += deltaV;
                }
            }
        }


        public enum Orientation { North, South, West, East };
       // Location GetNext

        protected Location GetNextTo(int i, int j)
        {
            return GetNextToLocation(i, j, Orientation.North);
        }


        public Location GetNextToLocation(int rowIndex, int colIndex, Orientation orientation)
        {
            int deltaVertical = 0;
            int deltaHorizontal = 0;

            switch (orientation)
            {
                case Orientation.North: deltaVertical = -1;
                    break;
                case Orientation.South: deltaVertical = 1;
                    break;
                case Orientation.West: deltaHorizontal = -1;
                    break;
                case Orientation.East: deltaHorizontal = 1;
                    break;
            }

            int adjRowIndex = rowIndex + deltaHorizontal;
            int adjColIndex = colIndex + deltaVertical;

            while (!this.Board.IsOutBoundsLocation(adjRowIndex, adjColIndex))    //Mientras no nos salgamos del tablero comprobando
            {
                if (!this.Board.IsEmpty(adjRowIndex, adjColIndex))
                    return new Location(adjRowIndex, adjColIndex);

                adjRowIndex += deltaHorizontal;
                adjColIndex += deltaVertical;
            }

            return null;
        }


        public void Compact()
        {           

               
        }    
    }
}
