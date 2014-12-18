namespace Programacion.POO.Herencia.Animales.Abstracta
{
    class Pato:Ave
    {
        public override bool PuedeVolar()
        {
            return true;
        }
        public override string EmitirSonido()
        {
            return "Cuak cuak";
        }
    }
}
