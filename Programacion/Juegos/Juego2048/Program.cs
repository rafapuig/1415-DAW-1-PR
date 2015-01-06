using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego2048
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(4); 
            Engine game = new Engine();

            b[2, 3] = new Square(2048);
            b[1, 1] = new Square(2);
            b[0, 3] = new Square(16);
            b[3, 3] = new Square(256);
            DrawBoard(b);

            game.CompactBottom();

            Console.ReadKey();
        }

        public static string AlignCenteredText(string text, int length)
        {
            int padLength = length - text.Length;
            int padRight = padLength / 2;           

            return text.PadLeft(length - padRight).PadRight(length);
        }

        public static void DrawBoard(Board board) 
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();            

            for (int j = 0; j < board.Size; j++) 
            {
                if (j == 0) sb.Append("┌────┬");               //si es la primera columna
                else if (j == board.Size - 1) sb.Append("────┐");   //columna final
                else sb.Append("────┬");                       //las de enmedio
            }
            sb.AppendLine();          
           
            for (int i = 0; i < board.Size; i++)
            {
                sb.Append("│");
                for (int j = 0; j <board.Size; j++)
                {
                    string text = !board.IsEmpty(i, j) ? board[i,j].Value.ToString(): string.Empty;
                    sb.AppendFormat("{0}│",
                        AlignCenteredText(text, 4)); 
                }
                sb.AppendLine();
                              

                for (int j = 0; j < board.Size; j++)
                {
                    if (i == board.Size - 1)                    //el pintado de la linea final
                    {
                        if (j == 0) sb.Append("└────┴");                //primera columna
                        else if (j == board.Size - 1) sb.Append("────┘");    //Última columna
                        else sb.Append("────┴");                    //las de enmedio
                    }
                    else //el pintado de las lineas separadoras de enmedio, las que no sean las ultimas
                    {
                        if (j == 0) sb.Append("├────┼");                    //primera columna
                        else if (j == board.Size - 1) sb.Append("────┤");   //Última columna
                        else sb.Append("────┼");                            //las de enmedio
                    }
                }
                sb.AppendLine();//nueva linea
            }

            Console.Write(sb);

        }

    }
}
