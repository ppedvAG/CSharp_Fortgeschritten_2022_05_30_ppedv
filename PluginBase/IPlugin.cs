namespace PluginBase
{
	public interface IPlugin
	{
		public string Name { get; }

		public string Description { get; }
	}

	public interface ISpecificPlugin : IPlugin //Spezifizierung
	{
		public void Method1();

		public int Method2(int x, int y);
	}
}