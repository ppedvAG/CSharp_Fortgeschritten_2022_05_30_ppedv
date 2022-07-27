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
			//C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_05_30\TestPlugin\bin\Debug\net6.0\TestPlugin.dll
			string path = Path.Text;

			Assembly loaded = Assembly.LoadFrom(path);

			Type compType = loaded.DefinedTypes.First(e => e.GetInterface("PluginBase.IPlugin") != null);
			object component = loaded.CreateInstance(compType.FullName); //Komponente erstellen anhand des Namens vom Typen

			foreach (MethodInfo mi in component.GetType().GetMethods())
			{
				Button b = new Button();
				b.Content = mi.Name;
				b.Click += (sender, e) =>
				{
					MethodInfo method = component.GetType().GetMethod(mi.Name);
					if (!method.GetParameters().Any() && method.ReturnType == typeof(void))
						mi.Invoke(component, null);
					else if (!method.GetParameters().Any() && method.ReturnType != typeof(void))
					{
						object x = mi.Invoke(component, null);
						Convert.ChangeType(x, method.ReturnType);
					}
					else
					{
						ParameterInput pi = new ParameterInput(mi.GetParameters());
						pi.ShowDialog();
						object result = mi.Invoke(component, pi.ReturnValues.Values.ToArray());
						MessageBox.Show(result.ToString());
					}
				};
				ButtonPanel.Children.Add(b);
			}
		}
	}
}
