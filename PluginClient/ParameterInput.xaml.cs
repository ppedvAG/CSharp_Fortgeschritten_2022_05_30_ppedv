using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace PluginClient
{
	public partial class ParameterInput : Window
	{
		public Dictionary<string, object> ReturnValues = new();

		public ParameterInput() => InitializeComponent();

		public ParameterInput(ParameterInfo[] par)
		{
			InitializeComponent();
			foreach (var item in par)
			{
				ParameterElement element = new ParameterElement();
				element.ParameterName.Text = item.Name;
				ParameterPanel.Children.Add(element);
			}
		}

		private void AbbrechenClicked(object sender, RoutedEventArgs e) => Close();

		private void OkClicked(object sender, RoutedEventArgs e)
		{
			foreach (ParameterElement pe in ParameterPanel.Children)
			{
				ReturnValues.Add(pe.ParameterName.Text, pe.ParameterValue.Text);
			}
			Close();
		}
	}
}
