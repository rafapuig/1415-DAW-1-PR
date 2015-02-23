using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using Imagenes;
using System.Windows.Forms;
using ImageProvider;

namespace TestImagenes
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestPath();

            //IFactory<Image> factory = new FromResourceImageFactory("Barajas.Modelos.Heraclio");
            ////IFactory<Image> factory = new FromResouceImagenFactory("Barajas.Modelos.Valenciana");
            
            ////IFactory<Image> factory = new FromFileImageFactory("heraclio");
           
            //IFactory<Image> resizedFactory = new ResizeImageFactoryDecorator(factory, 63);
            //IFactory<Image> cachedFactory = new FlyweightFactory<Image>(resizedFactory);

            ////Image img1 = cachedFactory.Create("11");
            
            //Image img = cachedFactory.Create("tapada");
            //Image img2 = cachedFactory.Create("tapada");

            //System.Diagnostics.Debug.WriteLine(img == img2) ;

            ////Form1 f = new Form1(cachedFactory);
            ////Application.Run(f);

            //Form2 f = new Form2(new FromResourceCartasImagenesProvider(cachedFactory));
            ////Application.Run(f);

            Application.Run(new PruebaControlCartaForm());            
            
            ////Console.ReadKey();
        }



        static void TestPath()
        {
            Form frm = new Form();
            frm.SetBounds(0, 0, 1280, 720);
            frm.AutoScaleMode = AutoScaleMode.None;

            frm.Paint += (obj, e) =>
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                
                path.AddArc(
                    x: 100, y: 100,
                    width: 200, height: 100,
                    startAngle: 180,
                    sweepAngle: 90);

                e.Graphics.DrawPath(Pens.Blue, path);                    

            };

            Application.Run(frm);
        }
    }
}
