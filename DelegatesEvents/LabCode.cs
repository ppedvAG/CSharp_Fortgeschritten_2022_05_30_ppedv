namespace DelegatesEvents;

public class LabCode
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }

    public void Addition(double zahl1, double zahl2)
    {
        Console.WriteLine($"{zahl1} + {zahl2} = {zahl1 + zahl2}");
    }

    public void Subtraktion(double zahl1, double zahl2)
    {
        Console.WriteLine($"{zahl1} - {zahl2} = {zahl1 - zahl2}");
    }

    public void Multiplikation(double zahl1, double zahl2)
    {
        Console.WriteLine($"{zahl1} * {zahl2} = {zahl1 * zahl2}");
    }
}

public class DivisionsCalculator
{
    public void Division(double zahl1, double zahl2)
    {
        Console.WriteLine($"{zahl1} : {zahl2} = {zahl1 / zahl2}");
    }
}

