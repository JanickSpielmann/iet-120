using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für RecordView.xaml
    /// </summary>
    public partial class RecordView : UserControl
    {
        MainWindow mainWindow;
        Data.Record record;
        public RecordView(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        public RecordView(MainWindow mainWindow,long id)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            this.record = GetRecord(id);
            FillPage(record);
        }

        private Data.Record GetRecord(long id)
        {
            return Data.Record.ReadID(id);
        }

        public void FillPage(Data.Record record)
        {
            txtAlbumTitle.Text =  record.AlbumTitle;
            txtArtist.Text = record.Artist;
            txtGenres.Text = record.Genre;
            txtPrice.Text = record.Price.ToString("F2");
            dpiReleaseDate.Text = record.ReleaseDate.ToString("dd.MM.yyyy");
            OwnPrint(record);
        }
        public void OwnPrint(Data.Record record)
        {
            if (record.Own)
            {
                txtOwn.Background = Brushes.Green;
            }
            else
            {
                txtOwn.Background = Brushes.Red;
            }
        }
        private void btnEdit_DoubleClick(object sender, RoutedEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenEditView(record);
        }

        private void btnDelete_DoubleClick(object sender, RoutedEventArgs e)
        {
            btnDelete_Click(sender,e);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {


          MessageBoxResult result = MessageBox.Show("You are trying to delete " + record.AlbumTitle + "\nAre you sure you want to delete this item? ", "Delete Confirmation?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                record.Delete();
                mainWindow.OpenListView();
            }
        }
        private void btnReturn_DoubleClick(object sender, RoutedEventArgs e)
        {
            btnReturn_Click(sender, e);
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenListView();
        }
    }
}
