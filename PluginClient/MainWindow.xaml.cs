using System.Linq;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace PluginClient
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string path = Path.Text;

			Assembly loaded = Assembly.LoadFrom(path);

			Type compType = loaded.DefinedTypes.First(e => e.GetInterface("PluginBase.IPlugin") != null);
			object component = loaded.CreateInstance(compType.FullName); //Komponente erstellen anhand des Namens vom Typen

			foreach (MethodInfo mi in component.GetType().GetMethods())
			{
				Button b = new Button();
				b.Content = mi.Name;
				b.Click += (sender, e) => { component.GetType().GetMethod(mi.Name).Invoke(component, null); };
				ButtonPanel.Children.Add(b);
			}
		}
	}
}
