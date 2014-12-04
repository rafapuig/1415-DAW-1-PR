using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDemo
{
    class GameObject
    {
        public float Top { get; set; }
        public float Left { get; set; }

        public string[] Image;

        public int Width { get { return this.Image.GetLength(0); } }
        public int Height { get { return this.Image.Length; } }

        public float SpeedX { get; set; }
        public float SpeedY { get; set; }

        public void Move(float timeElapsed)
        {
            //Espacio = a velocidad por tiempo
            Left += SpeedX * timeElapsed;
            Top += SpeedY * timeElapsed;
        }
    }
}
