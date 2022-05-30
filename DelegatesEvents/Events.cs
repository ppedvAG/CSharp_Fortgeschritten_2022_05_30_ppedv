namespace DelegatesEvents;

internal class Events
{
	static event EventHandler Event;

	static event EventHandler<TestEventArgs> TestEvent;

	static void Main(string[] args)
	{
		Event += Events_Event; //Dranhängen ohne new
		Event += (o, args) => { }; //Anonyme Methode ohne new
		Event(null, new TestEventArgs("Event wurde gefeuert"));

		TestEvent += Events_TestEvent;
		TestEvent?.Invoke(null, new TestEventArgs("TestEvent wurde gefeuert")); //Sicherer Aufruf
	}

	private static void Events_TestEvent(object sender, TestEventArgs e)
	{
		Console.WriteLine(e.Status);
	}

	private static void Events_Event(object sender, EventArgs e)
	{
		if (e is TestEventArgs te)
			Console.WriteLine(te.Status);
	}
}

public class TestEventArgs : EventArgs
{
	public string Status { get; set; }

	public TestEventArgs(string status)
	{
		this.Status = status;
	}
}
