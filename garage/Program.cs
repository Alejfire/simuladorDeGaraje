public class Motor
{
    private int litros_de_aceite;
    private int potencia;

    public Motor(int potencia)
    {
        this.litros_de_aceite = 0;
        this.potencia = potencia;
    }

    public int GetPotencia()
    {
        return potencia;
    }

    public int GetLitros_de_aceite()
    {
        return litros_de_aceite;
    }

    public void SetPotencia(int potencia)
    {
        this.potencia = potencia;
    }

    public void SetLitros_de_aceite(int litrosAceite)
    {
        this.litros_de_aceite = litrosAceite;
    }

}




public class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double precioDeAverias;

    public Coche(string marca, string modelo)
    {
        this.precioDeAverias = 0.0;
        this.marca = marca;
        this.modelo = modelo;
    }

    public string GetMarca()
    {
        return marca;
    }

    public string GetModelo()
    {
        return modelo;
    }

    public double GetPrecioDeAverias()
    {
        return precioDeAverias;
    }

    public Motor GetMotor()
    {
        return motor;
    }

    public void SetPrecioDeAverias(double precioDeAverias)
    {
        this.precioDeAverias = precioDeAverias;
    }

    public void SetMarca(string marca)
    {
        this.marca = marca;
    }

    public void SetModelo(string modelo)
    {
        this.modelo = modelo;
    }

    public void SetMotor(Motor motor)
    {
        this.motor = motor;
    }

    public void AcumularAveria(double importe)
    {
        precioDeAverias += importe;
    }

}




public class Garaje
{
    private Coche coche;
    private string averiaAsociada;
    private int cochesAtendidos;

    public Garaje()
    {
        coche = null;
        cochesAtendidos = 0;
        averiaAsociada = "";
    }

    public bool AceptarCoche(Coche coche, string averiaAsociada)
    {
        if (this.coche != null)
        {
            return false;
        }

        this.coche = coche;
        this.averiaAsociada = averiaAsociada;
        cochesAtendidos++;

        return true;
    }

    public void DevolverCoche()
    {
        averiaAsociada = "";
        coche = null;
    }

    public int GetCochesAtendidos()
    {
        return cochesAtendidos;
    }
}




public class PracticaPOO
{
    static void Main()
    {
        Console.WriteLine("Simulador de Garaje\n\n");

        Garaje suGaraje = new Garaje();

        Coche coche1 = new Coche("Porsche", "718");
        coche1.SetMotor(new Motor(300));

        Coche coche2 = new Coche("Toyota", "Supra");
        coche2.SetMotor(new Motor(200));

        Coche[] coches = { coche1, coche2 };

        Random random = new Random();
        double importeAveria;

        for (int i = 0; i < 2; i++)
        {
            foreach (Coche coche in coches)
            {
                importeAveria = random.NextDouble() * 500;

                string averia = (random.Next(1, 4) == 1) ? "aceite" : "otra avería";

                bool aceptado = suGaraje.AceptarCoche(coche, averia);

                if (aceptado)
                {
                    Console.WriteLine($"* Un coche de marca {coche.GetMarca()} y modelo {coche.GetModelo()} fue aceptado al garaje.\n");
                }
                else
                {
                    Console.WriteLine("* El coche no fue aceptado ya que el garaje ya esta siendo utilizado por otro coche.\n");
                }

                if (averia == "aceite")
                {
                    coche.GetMotor().SetLitros_de_aceite(coche.GetMotor().GetLitros_de_aceite() + 10);
                }

                coche.AcumularAveria(importeAveria);

                suGaraje.DevolverCoche();
            }
        }

        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");

        foreach (Coche coche in coches)
        {
            Console.WriteLine($"El carro marca {coche.GetMarca()}, modelo {coche.GetModelo()}, tiene {coche.GetMotor().GetLitros_de_aceite()} litros de aceite, y un precio acumulado de averías de ${coche.GetPrecioDeAverias()}\n");
        }
    }
}


