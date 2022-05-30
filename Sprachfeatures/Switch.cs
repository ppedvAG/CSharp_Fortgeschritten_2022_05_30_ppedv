namespace Sprachfeatures;

internal class Switch
{
	static void Main(string[] args)
	{
		Wochentag wt = Wochentag.Mo;
		switch (wt)
		{
			case >= Wochentag.Mo and <= Wochentag.Mi: //<=, >=, and und or statt && und ||
				break;
			case Wochentag.Do:
				break;
		}

		string x = args[0] switch 
		{
			"1" => "Eins",
			"2" => "Zwei",
			"3" => "Drei",
			_ => "Keine Zahl"
		};

		int gehalt = new Person().Alter switch
		{
			22 => 2000
		};
	}
}

public class Person
{
	public int Alter;
}

enum Wochentag
{
	Mo, Di, Mi, Do
}
