using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Progress.Value = 0;
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(25);
				Progress.Value++;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Task.Run(() => 
			{
				Dispatcher.Invoke(() => Progress.Value = 0);
				for (int i = 0; i < 100; i++)
				{
					Thread.Sleep(25);
					Dispatcher.Invoke(() => Progress.Value++); 
					//UI Elemente können nicht von side Threads/Tasks angegriffen werden
					//Dispatcher lässt Code am Main Thread laufen
				}
			});
		}

		private async void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Progress.Value = 0; //Dispatcher hier nicht notwendig
			for (int i = 0; i < 100; i++)
			{
				await Task.Delay(25);
				Progress.Value++; //Auch hier kein Dispatcher
			}
		}
	}
}
