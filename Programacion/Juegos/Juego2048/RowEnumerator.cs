using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego2048
{
    
    public class RowEnumerator : IEnumerator<Location>
    {
        public enum Direction {LeftToRight, RightToLeft};

        int actualRow;
        int actualCol;
        int delta;

        Board board;

        public RowEnumerator(Board board, int rowIndex, Direction dir)
        {
            this.board = board;
            this.actualRow = rowIndex;

            switch (dir)
            {
                case Direction.LeftToRight:
                    actualCol = -1;
                    delta = 1;
                    break;
                case Direction.RightToLeft:
                    actualCol = board.Size;
                    delta = -1;
                    break;
                default:
                    break;
            } 
        }

        public Location Current
        {
            get { return new Location(this.actualRow, this.actualCol); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.Current; }
        }

        public bool MoveNext()
        {
            this.actualCol += delta;
            return !this.board.IsOutBoundsLocation(this.actualRow, this.actualCol);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
