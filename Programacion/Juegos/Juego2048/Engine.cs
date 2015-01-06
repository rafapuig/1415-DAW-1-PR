using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego2048
{
    class Engine
    {
        Board theBoard; //Podria ser una lista de squares

        void FusionarColumna(int columnIndex)
        {
            //Compactar
            Square candidate = theBoard[3, columnIndex];
            Square adjacent = theBoard[3 - 1, columnIndex];
            //Fusionar
            //Compactar
        }

        //void Compactar(int columnIndex)
        //{
        //    int i = theBoard.Size - 1;
        //    int j = columnIndex;
        //    int deltaV = -1;
        //    int deltaH = 0;            

        //    while (theBoard.IsOutBoundsLocation(i, j))
        //    {
        //        //Si la posicion esta vacia, traer el siguente adjacente
        //        if (theBoard.IsEmpty(i, j))
        //        {
        //            Location nextToSquareLocation = GetNextToLocation(i, j, Orientation.North);
        //            //Square adjacent = GetNextToSquare(i, j, Orientation.North);
        //            if (nextToSquareLocation != null)
        //            {
        //                Location compactingLocation = new Location(i, j);
        //                theBoard.Move(compactingLocation, nextToSquareLocation);
        //            }
        //            i += deltaH;
        //            j += deltaV;
        //        }
        //    }        
            
        //    //Si hay adjacente
        //    //ubicarlo en esta posicion y a por el siguiente
        //    //Si no terminar
        //}


        public void CompactBottom()
        { }

        void CompactTop() { }

        void CompactLeft()
        {

        }

        void CompactRight() { }



        

        //public Square GetNextToSquare(int rowIndex, int colIndex, Orientation orientation)
        //{
        //    Location nextToLocation = GetNextToLocation(rowIndex, colIndex, orientation);
        //        if (nextToLocation!=null)
        //        return theBoard[nextToLocation.Row,nextToLocation.Column];
        //    return null;
        //}


    }
}
