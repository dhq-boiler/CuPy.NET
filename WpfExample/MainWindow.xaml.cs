using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cupy;
using Python.Runtime;

namespace WpfExample
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool _allowThreads = false;

        private void WriteLine(string text)
        {
            TextBox.AppendText(text + "\n");
            TextBox.ScrollToEnd();
        }

        private void OnBlockingClick(object sender, RoutedEventArgs e)
        {
            WriteLine("Example 1: Matrix multiplication with CuPy on the GUI thread (blocking):");
            // before starting the measurement, let us call CuPy once to get the setup checks done. 
            cp.arange(1);
            var stopwatch = Stopwatch.StartNew();

            var a1 = cp.arange(60000).reshape(300, 200);
            var a2 = cp.arange(80000).reshape(200, 400);

            var result = cp.matmul(a1, a2);
            stopwatch.Stop();

            WriteLine($"execution time with CuPy: {stopwatch.Elapsed.TotalMilliseconds}ms\n");
            WriteLine("Result:\n" + result.repr);
            WriteLine("\nNote: blocking usage is not recommended. ");
            WriteLine("\nIf you close the program without runnning example 2 it will hang indefinitely. ");
            Button1.IsEnabled = false;
            Button2.IsEnabled = true;
        }

        private async void OnNonBlockingClick(object sender, RoutedEventArgs e)
        {
            WriteLine("Example 2: Matrix multiplication with CuPy on a background thread (non-blocking):");

            if (!_allowThreads) {
                // https://github.com/pythonnet/pythonnet/issues/109
                PythonEngine.BeginAllowThreads();
                _allowThreads=true;
            }
            var stopwatch = Stopwatch.StartNew();
            var resultString = "";
            await Task.Run(() => {
                using (Py.GIL()) {


                    var a1 = cp.arange(60000).reshape(300, 200);
                    var a2 = cp.arange(80000).reshape(200, 400);

                    var result = cp.matmul(a1, a2);
                    stopwatch.Stop();
                    resultString = result.repr;
                }
            });
            await this.Dispatcher.BeginInvoke(() => {
                WriteLine($"execution time with CuPy: {stopwatch.Elapsed.TotalMilliseconds}ms\n");
                WriteLine("Result:\n" + resultString);
            });
            WriteLine("\nNote: if you close the program now it will not hang because of PythonEngine.BeginAllowThreads();\nWe only have to make sure to enclose all calculations in using(Py.GIL()) { }");
        }
    }
}
