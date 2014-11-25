using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDemo
{
    static class Modelo
    {
        //Posicion X e Y del jugador en la pantalla
        public static int PlayerPosX = 0;
        public static int PlayerPosY = 0;

        //public static int WorldWidth;
        //public static int WorldHeight;

        //Funciones para que el programa controlador le diga al modelo como debe recuperar las dimensiones de la pantalla
        public static Func<int> GetViewPortWidth = null;
        public static Func<int> GetViewPortHeight = null;
        
        //public static Action<int> SetViewPortWidth = null;
        //public static Action<int> SetViewPortHeight = null;

        //El jugador
        public static string[] _Player = new string[] { "|<--^-->|" };
        public static string[] Player
        {
            get { return _Player; }
            set
            {
                _Player = value;
                HasChanged = true;
            }
        }

        public static int PlayerWidth { get { return Player[0].Length; } }
        public static int PlayerHeight { get { return Player.Length; } }


        //Mover un jugador por el mundo 
        public static void Mover(int deltaX, int deltaY)
        {
            //Si no hay movimiento volver del metodo sin hacer nada;
            if (deltaX == 0 && deltaY == 0) return;

            //int nuevaPosX = PlayerPosX + deltaX;
            //nuevaPosX = Math.Min(nuevaPosX, GetViewPortWidth() - 1); //Como maximo tope derecha para no salirnos
            //PlayerPosX = Math.Max(0, nuevaPosX);     //Como minimo 0 para no salirnos por la izquierda

            PlayerPosX = Math.Max(0, 
                Math.Min(GetViewPortWidth() - PlayerWidth, PlayerPosX + deltaX));

            int nuevaPosY = PlayerPosY + deltaY;
            nuevaPosY = Math.Min(nuevaPosY, GetViewPortHeight() - (PlayerHeight - 1)); //Para no salirnos por abajo
            PlayerPosY = Math.Max(0, nuevaPosY);  //Para no salirnos por arriba

            HasChanged = true;
        }

        

        //Indica si se ha producido algun cambio en el estado del modelo
        private static bool _hasChanged = true;
       
        public static bool HasChanged
        {
            get { return _hasChanged; }
            private set { _hasChanged = value; }
        }
        
        //Reestablecer el estado a sin cambios en el modelo, una vez se han tenido en cuenta para refrescar la vista (pantalla - Consola)
        public static void ResetChanges()
        {
            HasChanged = false;
        }

        ////Forzar a que se considere que han cambios y se refresque la vista
        //public static void Init()
        //{
        //    HasChanged = true;
        //}
    
    }


}