using System;

namespace act12
{
    // 1. Crear Rectangulo con 3 constructores encadenados con this(...).
    public class Rectangulo
    {
        public double Ancho { get; }
        public double Alto { get; }
        public Rectangulo() : this(1, 1) { }
        public Rectangulo(double lado) : this(lado, lado) { }
        public Rectangulo(double ancho, double alto)
        {
            Ancho = ancho;
            Alto = alto;
        }

        public double Area() => Ancho * Alto;
    }

    // 6. Demostrar que C# genera constructor vacio solo si no hay ninguno.
    public class Demostrar
    {
        public string Demostracion { get; set; } = string.Empty;
    }

    // 2. Crear clase Persona con constructor que asigne ID automatico.
    // 3. Usar inicializador de objeto: new Persona { Nombre = "Ana" }.
    // 7. Usar this para resolver conflicto de nombres en constructor.
    public class Persona
    {
        private static int contadorId = 0;
        public int Id { get; }
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            contadorId++;
            Id = contadorId;
            this.Nombre = nombre;
        }

        public Persona() : this("Sin Nombre") { }
    }

    // 9. Crear constructor privado para clase Singleton basico.
    public class Singleton
    {
        private static Singleton? _instancia;
        public string Mensaje { get; set; } = "Instancia unica activa";

        private Singleton() { }

        public static Singleton Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Singleton();
                }
                return _instancia;
            }
        }
    }

    // 4. Crear Fraccion(int num, int den) con validacion den != 0.
    // 5. Sobrecargar Fraccion con constructor de entero.
    public class Fraccion
    {
        public int Numerador { get; }
        public int Denominador { get; }

        public Fraccion() : this(0, 1) { }
        public Fraccion(int entero) : this(entero, 1) { }
        public Fraccion(int numerador, int denominador)
        {
            if (denominador == 0)
            {
                Console.WriteLine("Error: El denominador no puede ser cero. Se asigna 1 por defecto.");
                denominador = 1;
            }
            Numerador = numerador;
            Denominador = denominador;
        }

        public double ADecimal() => (double)Numerador / Denominador;
    }

    // 8. Crear metodo fluido con return this: jugador.Mover(1,0).Atacar().
    public class Jugador
    {
        public string Nombre { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            X = 0;
            Y = 0;
        }

        public Jugador Mover(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
            Console.WriteLine($"{Nombre} se movió a la posición ({X}, {Y}).");
            return this;
        }

        public Jugador Atacar()
        {
            Console.WriteLine($"{Nombre} realiza un ataque en ({X}, {Y})!");
            return this;
        }
    }

    // 10. Crear clase Config con valores por defecto en constructor vacio.
    public class Config
    {
        public string Idioma { get; set; }
        public string Tema { get; set; }
        public int Volumen { get; set; }
        public bool ModoOscuro { get; set; }

        public Config()
        {
            Idioma = "Español";
            Tema = "Predeterminado";
            Volumen = 80;
            ModoOscuro = true;
        }

        public Config(string idioma, string tema, int volumen, bool modoOscuro)
        {
            Idioma = idioma;
            Tema = tema;
            Volumen = volumen;
            ModoOscuro = modoOscuro;
        }

        public void Mostrar()
        {
            Console.WriteLine($"[Configuración] Idioma: {Idioma} | Tema: {Tema} | Volumen: {Volumen}% | Modo Oscuro: {ModoOscuro}");
        }
    }

    class Program
    {
        static void Main()
        {
            Rectangulo ola = new Rectangulo(10, 10);
            Console.WriteLine("area del rectángulo: " + ola.Area());

            Persona p1 = new Persona { Nombre = "Lucas" };
            Console.WriteLine($"Mi ID: {p1.Id} y me llamo {p1.Nombre}");

            Fraccion numerofracionarioso = new Fraccion(12, 10);
            Fraccion fEntero = new Fraccion(5);
            Console.WriteLine($"{fEntero.Numerador}/{fEntero.Denominador}");
            Console.WriteLine($"{numerofracionarioso.Numerador}/{numerofracionarioso.Denominador} = {numerofracionarioso.ADecimal()}");

            Demostrar demostracion = new Demostrar();

            Jugador personaje = new Jugador("Caballero");
            personaje.Mover(1, 2).Atacar().Mover(3, 6).Atacar();

            Singleton noSePudo = Singleton.Instancia;
            Singleton siSeVe = Singleton.Instancia;
            noSePudo.Mensaje = "Hola desde s1";
            Console.WriteLine(siSeVe.Mensaje);

            Config perfil1 = new Config("Ruso", "AeroWindows", 200, true);
            perfil1.Mostrar();
        }
    }
}