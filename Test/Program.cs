Wochentag wt = Wochentag.Mo;
switch (wt)
{
	case >= Wochentag.Mo and <= Wochentag.Mi:
		break;
	case Wochentag.Do:
		break;
}

Person p = new Person(1, "Max", null);
string vName = p switch
{
	{ Vorgesetzter.Name: "Test" } => "Test"
};

public record Person(int ID, string Name, Person Vorgesetzter);



enum Wochentag
{
	Mo, Di, Mi, Do
}