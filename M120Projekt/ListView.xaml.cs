using M120Projekt.Data;
using System;
using System.Collections.Generic;
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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für ListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        private MainWindow mainWindow;
        public ListView(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            dgrRecord.ItemsSource = Data.Record.ReadTable();
        }
        private void btnCreat_DoubleClick(object sender, RoutedEventArgs e)
        {
            btnCreate_Click(sender,e);
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenEditView();

        }
        private void Record_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgrRecord.SelectedItem != null)
            {
                Record selectedRecord = (Record)dgrRecord.SelectedItem;
                mainWindow.OpenRecordView(selectedRecord.RecordId);
            }
        }
        private void btnExit_DoubleClick(object sender, RoutedEventArgs e)
        {
            btnExit_Click(sender, e);
        }
            private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }
    }
}
