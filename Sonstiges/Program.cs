using System.Collections;
using System.Collections.Generic;

namespace Sonstiges;

internal class Program
{
	static void Main(string[] args)
	{
		Zug z = new();
		foreach (Wagon w in z)
		{

		}

		z[1].ToString();
		z[3, "Rot"].ToString();

		var anonym = new { ID = 1, Name = "Test", b = false };
	}
}

public class Zug : IEnumerable
{
	private List<Wagon> Wagons;

	public Zug()
	{
		var x = Wagons.Select(e => new { HC = e.GetHashCode(), Farbe = e.Farbe }); //Beliebig viele Felder weiter bewegen
		Console.WriteLine(x.First().HC);
	}

	public IEnumerator GetEnumerator()
	{
		foreach (Wagon w in Wagons)
		{
			yield return w;
		}
	}

	public Wagon this[int idx]
	{
		get => Wagons[idx];
		set => Wagons[idx] = value;
	}

	public Wagon this[int sitze, string farbe] => Wagons.First(e => e.Sitzplätze == sitze && e.Farbe == farbe);
}

public class Wagon
{
	public int Sitzplätze;

	public string Farbe;

	public static bool operator ==(Wagon w1, Wagon w2)
	{
		return w1.Sitzplätze == w2.Sitzplätze && w1.Farbe == w2.Farbe;
	}

	public static bool operator !=(Wagon w1, Wagon w2)
	{
		return !(w1 == w2);
	}
}