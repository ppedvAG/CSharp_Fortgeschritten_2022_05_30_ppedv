using PluginBase;

namespace TestPlugin
{
	public class Class1 : ISpecificPlugin
	{
		public string Name { get => "TestPlugin"; }

		public string Description { get => "ein Testplugin"; }

		public void Method1()
		{
			Environment.Exit(0);
			//Console.WriteLine($"Mein Name ist {Name} und ich bin {Description}");
		}

		public int Method2(int x, int y)
		{
			return x + y;
		}
	}
}