namespace Linq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Erstellt eine Liste von Start mit einer bestimmten Anzahl Elementen
			//(5, 20) -> Start bei 5, 20 Elemente -> 5-24
			List<int> ints = Enumerable.Range(1, 20).ToList();

			Console.WriteLine(ints.Average());
			Console.WriteLine(ints.Min());
			Console.WriteLine(ints.Max());
			Console.WriteLine(ints.Sum());

			Console.WriteLine(ints.First()); //Erstes Element der Liste, Exception wenn Liste leer
			Console.WriteLine(ints.FirstOrDefault()); //null wenn Liste leer

			Console.WriteLine(ints.Last()); //Erstes Element der Liste, Exception wenn Liste leer
			Console.WriteLine(ints.LastOrDefault()); //null wenn Liste leer


			List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
			{
				new Fahrzeug(251, FahrzeugMarke.BMW),
				new Fahrzeug(274, FahrzeugMarke.BMW),
				new Fahrzeug(146, FahrzeugMarke.BMW),
				new Fahrzeug(208, FahrzeugMarke.Audi),
				new Fahrzeug(189, FahrzeugMarke.Audi),
				new Fahrzeug(133, FahrzeugMarke.VW),
				new Fahrzeug(253, FahrzeugMarke.VW),
				new Fahrzeug(304, FahrzeugMarke.BMW),
				new Fahrzeug(151, FahrzeugMarke.VW),
				new Fahrzeug(250, FahrzeugMarke.VW),
				new Fahrzeug(217, FahrzeugMarke.Audi),
				new Fahrzeug(125, FahrzeugMarke.Audi)
			};

			fahrzeuge.Where(fzg => fzg.Marke == FahrzeugMarke.VW);

			fahrzeuge.Select(e => e.MaxGeschwindigkeit);

			fahrzeuge.OrderBy(e => e.MaxGeschwindigkeit); //Hier besonders aufpassen: neue Liste
			fahrzeuge.OrderByDescending(e => e.Marke).ThenBy(e => e.MaxGeschwindigkeit);

			fahrzeuge.All(e => e.MaxGeschwindigkeit > 150);
			fahrzeuge.Any(e => e.MaxGeschwindigkeit < 150);

			fahrzeuge.Any(); //fahrzeuge.Count >= 0

			fahrzeuge.Count(e => e.Marke == FahrzeugMarke.BMW);

			fahrzeuge.Min(e => e.MaxGeschwindigkeit); //kleinste Geschwindigkeit
			fahrzeuge.MinBy(e => e.MaxGeschwindigkeit); //Auto mit der kleinsten Geschwindigkeit

			fahrzeuge.Chunk(5); //Liste in 5er Teile teilen

			fahrzeuge.Skip(3).Take(5); //5er Teil mittendrin nehmen

			fahrzeuge.Reverse<Fahrzeug>(); //Speziell Linq Methode ansprechen, neue Liste

			List<Fahrzeug> concat = new()
			{
				new Fahrzeug(324, FahrzeugMarke.Audi),
				new Fahrzeug(338, FahrzeugMarke.BMW),
				new Fahrzeug(291, FahrzeugMarke.VW)
			};
			fahrzeuge.Concat(concat); //neue Liste

			Fahrzeug prependAppend = new Fahrzeug(350, FahrzeugMarke.BMW);

			fahrzeuge.Prepend(prependAppend); //neue Liste
			fahrzeuge.Append(prependAppend); //neue Liste

			fahrzeuge.Except(concat); //Alle Elemente in der ersten Liste aber nicht in der zweiten
			fahrzeuge.Intersect(concat); //in beiden Listen

			IEnumerable<int> ids = Enumerable.Range(0, fahrzeuge.Count);
			IEnumerable<(int ID, Fahrzeug Second)>? zip = ids.Zip(fahrzeuge);

			Dictionary<int, Fahrzeug> idDict = zip.ToDictionary(e => e.ID, e => e.Second); //Tupel entfernen

			IEnumerable<IGrouping<FahrzeugMarke, Fahrzeug>> grouped = fahrzeuge.GroupBy(e => e.Marke); //Nach Marke gruppieren (BMW-Gruppe, Audi-Gruppe, VW-Gruppe)

			Dictionary<FahrzeugMarke, List<Fahrzeug>> groupDictionary = grouped.ToDictionary(e => e.Key, x => x.ToList()); //Zu Dictionary umwandeln
			
			IGrouping<FahrzeugMarke, Fahrzeug> bmwGroup = grouped.First(e => e.Key == FahrzeugMarke.BMW); //Einzelne Gruppe holen

			bmwGroup.ToList(); //Alle BMWs aus dem GroupBy

			Console.WriteLine(fahrzeuge.Aggregate(string.Empty, (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxGeschwindigkeit}km/h fahren.\n"));


			4826359.Quersumme();

			int q = 38527;
			q.Quersumme();

			"Test".ParseDirect();
		}
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}