using System.Diagnostics;

namespace AsyncAwait
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			//Stopwatch sw = Stopwatch.StartNew();
			//Toast();
			//GeschirrHerrichten();
			//KaffeeZubereiten();
			//sw.Stop();
			//Console.WriteLine(sw.ElapsedMilliseconds);

			//Stopwatch sw2 = Stopwatch.StartNew();
			//ToastAsync();
			//GeschirrHerrichtenAsync();
			//KaffeeZubereitenAsync();
			//sw2.Stop();
			//Console.WriteLine(sw2.ElapsedMilliseconds); //Die Methoden sind im Hintergrund und die Stopwatch ist im Main Thread
			//Console.ReadKey();

			Stopwatch sw3 = Stopwatch.StartNew();
			Task<Toast> toast = ToastTaskAsync();
			Task<Tasse> tasse = GeschirrHerrichtenTaskAsync();
			//Tasse t = await tasse;
			Task<Kaffee> kaffee = KaffeeZubereitenTaskAsync(await tasse);
			Toast t = await toast;
			Kaffee k = await kaffee;
			sw3.Stop();
			Console.WriteLine(sw3.ElapsedMilliseconds);
		}

		static void Toast()
		{
			Thread.Sleep(4000);
			Console.WriteLine("Toast fertig");
		}

		static void GeschirrHerrichten()
		{
			Thread.Sleep(2000);
			Console.WriteLine("Geschirr hergerrichtet");
		}

		static void KaffeeZubereiten()
		{
			Thread.Sleep(2000);
			Console.WriteLine("Kaffee zubereitet");
		}

		static async void ToastAsync()
		{
			await Task.Delay(4000); //equivalent zu Thread.Sleep(...)
			Console.WriteLine("Toast fertig");
		}

		static async void GeschirrHerrichtenAsync()
		{
			await Task.Delay(2000);
			Console.WriteLine("Geschirr hergerrichtet");
		}

		async static void KaffeeZubereitenAsync()
		{
			await Task.Delay(2000);
			Console.WriteLine("Kaffee zubereitet");
		}

		static async Task<Toast> ToastTaskAsync() //Hier Task<Toast> statt nur Toast
		{
			await Task.Delay(4000); //equivalent zu Thread.Sleep(...)
			Console.WriteLine("Toast fertig");
			return new Toast();
		}

		static async Task<Tasse> GeschirrHerrichtenTaskAsync()
		{
			await Task.Delay(2000);
			Console.WriteLine("Geschirr hergerrichtet");
			return new Tasse();
		}

		async static Task<Kaffee> KaffeeZubereitenTaskAsync(Tasse tasse)
		{
			await Task.Delay(2000);
			Console.WriteLine("Kaffee zubereitet");
			return new Kaffee();
		}
	}
}

public class Toast { }

public class Tasse { }

public class Kaffee { }