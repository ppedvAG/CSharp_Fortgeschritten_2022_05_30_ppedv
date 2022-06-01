using System.Reflection;

namespace Reflection;

internal class Program
{
	static void Main(string[] args)
	{
		Program p = new Program();
		//Über p.GetType() Informationen über den Aufbau des Objekts erhalten

		typeof(Program).GetMethod("Test").Invoke(p, null);
		//Über typeof(Program) und GetMethod auf die Test Methode zugreifen
		//Danach mit Invoke(ProgramObjekt) die Methode ausführen

		typeof(Program).GetMethod("Test2").Invoke(p, new[] { "Print this" }); //Methode mit Parameter ausführen
		
		object o = Activator.CreateInstance(typeof(Program)); //Activator: Objekte anhand eines Typs erstellen
		object o2 = Activator.CreateInstance("Reflection", "Reflection.Program"); //Objekt anhand Assemblyname + Namespaces.Typename erstellen
		
		Assembly a = Assembly.GetExecutingAssembly(); //Derzeitige Assembly
		List<TypeInfo> types = a.DefinedTypes.ToList(); //Alle Typen im Assembly

		Assembly loaded = Assembly.LoadFrom(@"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_05_30\DelegatesEvents\bin\Debug\net6.0\DelegatesEvents.dll"); //DLL laden
		Type compType = loaded.DefinedTypes.First(e => e.FullName == "DelegatesEvents.Component"); //Typ (ComponentWithEvent) finden
		object component = loaded.CreateInstance(compType.FullName); //Komponente erstellen anhand des Namens vom Typen

		component.GetType().GetEvent("ValueChanged").AddEventHandler(component, (int i) => Console.WriteLine(i)); //Events anhängen
		component.GetType().GetEvent("ProcessCompleted").AddEventHandler(component, () => Console.WriteLine("Fertig"));

		component.GetType().GetMethod("StartProcess").Invoke(component, null); //StartProcess aufrufen
	}

	public void Test()
	{
		Console.WriteLine("Test wurde aufgerufen");
	}

	public void Test2(string print)
	{
		Console.WriteLine(print);
	}
}