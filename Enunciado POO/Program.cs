using System;

class Motor
{
    private int litros_de_aceite;
    private int potencia;

    public Motor(int potencia)
    {
        this.litros_de_aceite = 0;
        this.potencia = potencia;
    }

    public int GetLitrosDeAceite()
    {
        return litros_de_aceite;
    }

    public void SetLitrosDeAceite(int litros_de_aceite)
    {
        this.litros_de_aceite = litros_de_aceite;
    }

    public int GetPotencia()
    {
        return potencia;
    }

    public void SetPotencia(int potencia)
    {
        this.potencia = potencia;
    }
}

class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double precio_acumulado_averias;

    public Coche(string marca, string modelo, int potenciaMotor)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.precio_acumulado_averias = 0;
        this.motor = new Motor(potenciaMotor);
    }

    public Motor GetMotor()
    {
        return motor;
    }

    public string GetMarca()
    {
        return marca;
    }

    public string GetModelo()
    {
        return modelo;
    }

    public double GetPrecioAcumuladoAverias()
    {
        return precio_acumulado_averias;
    }

    public void AcumularAveria(double importe)
    {
        precio_acumulado_averias += importe;
    }
}

class Garaje
{
    private Coche coche;
    private string nombre_averia;
    private int numero_coches_atendidos;

    public Garaje()
    {
        coche = null;
        nombre_averia = "";
        numero_coches_atendidos = 0;
    }

    public bool AceptarCoche(Coche coche, string nombre_averia)
    {
        if (this.coche == null)
        {
            this.coche = coche;
            this.nombre_averia = nombre_averia;
            numero_coches_atendidos++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DevolverCoche()
    {
        coche = null;
        nombre_averia = "";
    }

    public int GetNumeroCochesAtendidos()
    {
        return numero_coches_atendidos;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Garaje garaje = new Garaje();
        Coche coche1 = new Coche("Toyota", "Corolla", 150);
        Coche coche2 = new Coche("Honda", "Civic", 200);
        Random random = new Random();

        for (int i = 0; i < 2; i++)
        {
            if (garaje.AceptarCoche(coche1, "aceite"))
            {
                coche1.GetMotor().SetLitrosDeAceite(coche1.GetMotor().GetLitrosDeAceite() + 10);
                coche1.AcumularAveria(random.NextDouble());
            }
            garaje.DevolverCoche();

            if (garaje.AceptarCoche(coche2, "motor"))
            {
                coche2.AcumularAveria(random.NextDouble());
            }
            garaje.DevolverCoche();
        }

        Console.WriteLine("Información de los coches:");
        Console.WriteLine("Coche 1:");
        Console.WriteLine("Marca: " + coche1.GetMarca());
        Console.WriteLine("Modelo: " + coche1.GetModelo());
        Console.WriteLine("Litros de aceite: " + coche1.GetMotor().GetLitrosDeAceite());
        Console.WriteLine("Precio acumulado de averías: " + coche1.GetPrecioAcumuladoAverias());

        Console.WriteLine("\nCoche 2:");
        Console.WriteLine("Marca: " + coche2.GetMarca());
        Console.WriteLine("Modelo: " + coche2.GetModelo());
        Console.WriteLine("Precio acumulado de averías: " + coche2.GetPrecioAcumuladoAverias());
    }
}
