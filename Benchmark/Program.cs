using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Benchmark;

internal class Program
{
	public static List<Fahrzeug> Fahrzeuge;

	static void Main(string[] args)
	{
		BenchmarkRunner.Run(typeof(Program));
	}

	[GlobalSetup]
	static void SetupList()
	{
		Fahrzeuge = new List<Fahrzeug>();
		Random rnd = new Random();
		for (int i = 0; i < 50000; i++)
			Fahrzeuge.Add(new Fahrzeug(i, rnd.Next(100, 500), (FahrzeugMarke) rnd.Next(0, 3)));
	}

	[Benchmark]
	static void SystemJson()
	{
		using Stream s = new FileStream(@"Test\System.json", FileMode.Open);
		System.Text.Json.JsonSerializer.Serialize(s, Fahrzeuge);
	}

	[Benchmark]
	static void NewtonsoftJson()
	{
		string json = JsonConvert. SerializeObject(Fahrzeuge);
	}

	[Benchmark]
	static void Xml()
	{
		using Stream s = new FileStream(@"Test\Xml.xml", FileMode.Open);
		XmlSerializer xml = new XmlSerializer(typeof(Fahrzeug));
		xml.Serialize(s, Fahrzeuge);
	}

	[Benchmark]
	static void Binary()
	{
		using Stream s = new FileStream(@"Test\Binary.bin", FileMode.Open);
		BinaryFormatter formatter = new BinaryFormatter();
		formatter.Serialize(s, Fahrzeuge);
	}
}