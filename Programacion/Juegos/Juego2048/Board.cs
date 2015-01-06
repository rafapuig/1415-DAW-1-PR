using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego2048
{
    public class Board
    {
        Square[,] squares;

        public readonly int Size;

        public Board(int size)
        {
            this.Size = size;
            this.squares = new Square[this.Size, this.Size];
        }

        public void Clear()
        {
            int rowCount = this.squares.GetLength(0);
            int colCount = this.squares.GetLength(1);

            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                    this[i, j] = null;// Square.Default;                
        }

        public Square this[int rowIndex, int colIndex]
        {
            get { return this.squares[rowIndex, colIndex]; }
            set { this.squares[rowIndex, colIndex] = value; }
        }

        public bool IsEmpty(int rowIndex, int colIndex)
        {
            return this.squares[rowIndex, colIndex] == null;

            //return this.squares[rowIndex,colIndex].Equals(Square.Default);
        }

        public bool IsOutBoundsLocation(int rowIndex,int colIndex)
        {
            if (rowIndex < 0 || rowIndex > this.Size - 1) return true;
            if (colIndex < 0 || colIndex > this.Size - 1) return true;
            return false;
        }

        public bool IsOutBoundsLocation(Location location)
        {
            return IsOutBoundsLocation(location.Row, location.Column);
        }

        public void Move(Location origin, Location destination)
        {
            this[destination.Row, destination.Column] = this[origin.Row, origin.Column];
        }


        //Compactar aqui???



    }        

}
