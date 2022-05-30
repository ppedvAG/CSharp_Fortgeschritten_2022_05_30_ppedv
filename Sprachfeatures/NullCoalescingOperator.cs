namespace Sprachfeatures
{
	internal class NullCoalescingOperator
	{
		static void Main(string[] args)
		{
			string name = args[0] ?? throw new Exception(); //Wenn args[0] nicht null -> args[0] sonst Exception
			name ??= args[0]; //Wenn args[0] nicht null -> args[0] sonst nix
		}
	}
}
