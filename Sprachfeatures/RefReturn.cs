namespace Sprachfeatures
{
	internal class RefReturn
	{
		static void Main(string[] args)
		{
			int[] zahlen = { 1, 2, 3, 4, 5, 6 };
			ref int position = ref Zahlensuche(3, zahlen); //Hier Referenz zu der Position im Array (2)
			position = 100; //Position 2 im Array wird zu 100
		}

		public static ref int Zahlensuche(int gesucht, int[] zahlen)
		{
			for (int i = 0; i < zahlen.Length; i++)
				if (zahlen[i] == gesucht)
					return ref zahlen[i];
			throw new Exception();
		}
	}
}
