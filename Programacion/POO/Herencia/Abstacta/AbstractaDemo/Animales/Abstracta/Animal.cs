namespace Programacion.POO.Herencia.Animales.Abstracta
{
    public abstract class Animal
    {
        //Emitir sonido, depende del tipo de animal
        //La clase base no sabe como implementarlo por tanto es un metodo virtual puro
        //Si una clase contiene un miembro sin implementacion se convierte en una clase abstracta
        //La clase derivada esta obligada a darle una implementacion
        //Si la clase derivada no lo implementa no podra ser concreta y devera seguir siendo abstracta
        //hasta que alguna de las subclases que deriven a su vez la de derivada lo implemente con override
        public abstract string EmitirSonido();
        
    }

}
