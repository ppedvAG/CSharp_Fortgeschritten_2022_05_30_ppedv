using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using System.Windows;
using System.Linq;

namespace AsyncAwaitUebung
{
	public partial class MainWindow : Window
	{
		public MainWindow() => InitializeComponent();

		/*
		 * JsonDocument.ParseAsync: Json Dokument einlesen und zu einem JsonDocument Objekt (jd) konvertieren
		 * jd.RootElement.EnumerateArray(): Json Dokument zu einem Array von JsonElement Objekten konvertieren um es zu iterieren
		 * jd.GetProperty(string): JsonProperty angreifen von einzelnem JsonElement
		 * jd.GetProperty(string).GetString(): Wert von Property angreifen
		 */

		private async void SplitJson(object sender, RoutedEventArgs e)
		{

		}

		private async void LoadJson(object sender, RoutedEventArgs e)
		{

		}

		//Es gibt keine Methode um aus einer Liste von JsonElements ein JsonArray zu generieren
		private string JsonListToJson(List<JsonElement> jsons)
		{
			return jsons.Aggregate(new StringBuilder("[\n"), (sb, je) =>
				sb.Append('\t')
				  .Append(je.GetRawText())
				  .Append(",\n"))
				  .ToString()
				  .TrimEnd(',', '\n') + "\n]";
		}
	}
}