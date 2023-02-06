using System.Windows;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Aufruf diverse APIDemo Methoden
            APIDemo.CreateNirvana();
            APIDemo.CreateACDC();

        }
    }
}
