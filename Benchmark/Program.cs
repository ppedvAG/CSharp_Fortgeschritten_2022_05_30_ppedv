using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Benchmark;

public class Program
{
	public static void Main(string[] args)
	{
		BenchmarkRunner.Run(typeof(Benchmarks));
	}

	public class Benchmarks
	{
		public List<Fahrzeug> Fahrzeuge;

		public string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Benchmark");

		[GlobalSetup]
		public void SetupList()
		{
			Fahrzeuge = new List<Fahrzeug>();
			Random rnd = new Random();
			for (int i = 0; i < 50000; i++)
				Fahrzeuge.Add(new Fahrzeug(i, rnd.Next(100, 500), (FahrzeugMarke) rnd.Next(0, 3)));
		}

		[GlobalCleanup]
		public void Cleanup()
		{
			Directory.Delete("Test", true);
		}

		[Benchmark]
		public void SystemJson()
		{
			using Stream s = new FileStream(Path.Combine(FolderPath, @"System.json"), FileMode.Open);
			System.Text.Json.JsonSerializer.Serialize(s, Fahrzeuge);
		}

		[Benchmark]
		public void NewtonsoftJson()
		{
			string json = JsonConvert.SerializeObject(Fahrzeuge);
		}

		[Benchmark]
		public void Xml()
		{
			using Stream s = new FileStream(Path.Combine(FolderPath, @"Xml.xml"), FileMode.Open);
			XmlSerializer xml = new XmlSerializer(typeof(Fahrzeug));
			xml.Serialize(s, Fahrzeuge);
		}

		[Benchmark]
		public void Binary()
		{
			using Stream s = new FileStream(Path.Combine(FolderPath, @"Binary.bin"), FileMode.Open);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(s, Fahrzeuge);
		}
	}
}