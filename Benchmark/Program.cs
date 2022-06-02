using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
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

		public string FolderPath;

		[GlobalSetup]
		public void Setup()
		{
			Fahrzeuge = new List<Fahrzeug>();
			string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			FolderPath = Path.Combine(desktop, "Benchmark");
			if (!Directory.Exists("Benchmark"))
				Directory.CreateDirectory(FolderPath);

			Random rnd = new Random();
			for (int i = 0; i < 50000; i++)
				Fahrzeuge.Add(new Fahrzeug(i, rnd.Next(100, 500), (FahrzeugMarke) rnd.Next(0, 3)));
		}

		[GlobalCleanup]
		public void Cleanup()
		{
			Directory.Delete(FolderPath, true);
		}

		
		[Benchmark]
		[IterationCount(50)]
		public void SystemJson()
		{
			string path = Path.Combine(FolderPath, @"System.json");
			using Stream s = new FileStream(path, FileMode.Create);
			System.Text.Json.JsonSerializerOptions options = new System.Text.Json.JsonSerializerOptions();
			options.IncludeFields = true;
			System.Text.Json.JsonSerializer.Serialize(s, Fahrzeuge, options);
		}

		[Benchmark]
		[IterationCount(50)]
		public void NewtonsoftJson()
		{
			string json = JsonConvert.SerializeObject(Fahrzeuge);
			string path = Path.Combine(FolderPath, @"Newtonsoft.json");
			File.WriteAllText(path, json);
		}

		[Benchmark]
		[IterationCount(50)]
		public void Xml()
		{
			string path = Path.Combine(FolderPath, @"Xml.xml");
			using Stream s = new FileStream(path, FileMode.Create);
			XmlSerializer xml = new XmlSerializer(typeof(List<Fahrzeug>));
			xml.Serialize(s, Fahrzeuge);
		}

		[Benchmark]
		[IterationCount(50)]
		public void Binary()
		{
			string path = Path.Combine(FolderPath, @"Binary.bin");
			using Stream s = new FileStream(path, FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(s, Fahrzeuge);
		}
	}
}