namespace Sprachfeatures;

internal class Tupel
{
	static void Main(string[] args)
	{
		(string vn, string nn) = ("Max", "Mustermann");
		Console.WriteLine(vn);
		Console.WriteLine(nn);
	}
}