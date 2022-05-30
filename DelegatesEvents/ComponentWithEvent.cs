namespace DelegatesEvents;

internal class ComponentWithEvent
{
	static void Main(string[] args)
	{
		Component comp = new();
		comp.ValueChanged += (counter) => Console.WriteLine("Zähler: " + counter); //Action mit einem Parameter counter
		comp.ProcessCompleted += () => Console.WriteLine("Fertig"); //Action ohne Parameter mit ()
		comp.StartProcess();
	}
}

public class Component
{
	public event Action ProcessCompleted; //Action, Predicate, Func hier möglich
	public event Action<int> ValueChanged;

	public void StartProcess()
	{
		for (int i = 0; i < 100; i++)
		{
			//Längerer Prozess
			ValueChanged(i);
			Thread.Sleep(10);
		}
		ProcessCompleted?.Invoke();
	}
}