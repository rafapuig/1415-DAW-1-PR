using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego2048
{
    public class Location
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Location(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
