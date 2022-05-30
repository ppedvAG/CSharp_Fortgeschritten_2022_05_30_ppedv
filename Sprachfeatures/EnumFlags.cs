namespace Sprachfeatures
{
	internal class EnumFlags
	{
		static void Main(string[] args)
		{
			Wochentag2 kombi = Wochentag2.Mo | Wochentag2.Di; //0011
			kombi.HasFlag(Wochentag2.Mo);
		}
	}
}

[Flags] //Enum mit Flags markieren (Binär verknüpfen mit |)
enum Wochentag2
{
	Mo = 1, Di = 2, Mi = 4, Do = 8
}
