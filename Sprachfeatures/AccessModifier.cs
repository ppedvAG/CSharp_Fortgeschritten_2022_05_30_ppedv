namespace M008
{
	public class AccessModifier //Klasse/Member ohne Modifier sind internal
	{
		public string Name { get; set; } //Kann überall gesehen werden (auch außerhalb vom Projekt)

		private int Groesse { get; set; } //Kann nur in dieser Klasse (AccessModifier) gesehen werden

		internal string Wohnort { get; set; } //Kann überall aber nur in diesem Projekt gesehen werden


		protected string Lieblingsfarbe { get; set; } //Kann nur in dieser Klasse und Unterklassen gesehen werden, aber auch außerhalb vom Projekt

		protected internal string Lieblingsnahrung { get; set; } //Kann im ganzen Projekt gesehen und auch in Unterklassen außerhalb

		protected private DateTime Geburtsdatum { get; set; } //Kann nur in dieser Klasse und Unterklassen von dieser Klasse nur im Projekt gesehen werden
	}
}
