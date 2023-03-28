using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaktionslogik für EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        private MainWindow mainWindow;
        private bool update;
        private Data.Record record;
        private List<string> genres;
        

        public object DialogResult { get; private set; }

        public EditView(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            CreateGenres();
            update = false;
        }



        public EditView(MainWindow mainWindow, Data.Record record)
        {
            this.record = record;
            this.mainWindow = mainWindow;
            InitializeComponent();
            CreateGenres();
            FillPage(record);
            update = true;
        }



        private void btnSave_DoubleClick(object sender, RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                record.AlbumTitle = txtAlbumTitle.Text;
                record.Artist = txtArtist.Text;
                record.ReleaseDate = (DateTime)dpiReleaseDate.SelectedDate;
                record.Price = double.Parse(txtPrice.Text); ;
                record.Own = (bool)ckbOwn.IsChecked;
                record.Update();
            }
            else
            {
                record = new Data.Record();
                record.AlbumTitle = txtAlbumTitle.Text;
                record.Artist = txtArtist.Text;
                record.ReleaseDate = (DateTime)dpiReleaseDate.SelectedDate;
                record.Price = double.Parse(txtPrice.Text);
                record.Own = (bool)ckbOwn.IsChecked;
                record.Create();
            }

            mainWindow.OpenListView();
        }

        private void CreateGenres()
        {
            genres = new List<string>{

            "Pop",
            "Rock",
            "Hip hop",
            "Electronic dance music",
            "Country",
            "Jazz",
            "Classical",
            "R&B",
            "Metal",
            "Reggae",
            "Blues",
            "Punk",
            "Alternative",
            "Indie rock",
            "Folk",
            "World music",
            "Funk",
            "Soul",
            "Gospel",
            "Electronic",
            "House",
            "Techno",
            "Dubstep",
            "Trap",
            "Grime",
            "K-pop",
            "J-pop",
            "Latin",
            "Afrobeat",
            "Dancehall"
            };
            cmbGenres.ItemsSource = genres;
        }

        public void FillPage(Data.Record record)
        {
            txtAlbumTitle.Text = record.AlbumTitle;
            txtArtist.Text = record.Artist;
            cmbGenres.SelectedValue = record.Genre;
            dpiReleaseDate.SelectedDate = record.ReleaseDate;
            txtPrice.Text = record.Price.ToString();
            OwnPrint(record);
        }
        public void OwnPrint(Data.Record record)
        {
            if (record.Own)
            {
                ckbOwn.IsChecked = true;
            }
            else
            {
                ckbOwn.IsChecked = false;
            }
        }

        private void btnReturn_DoubleClick(object sender, RoutedEventArgs e)
        {
            btnReturn_Click(sender, e);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                mainWindow.OpenRecordView(record.RecordId);
            }
            else
            {
                mainWindow.OpenListView();
            }
        }
        private void bntCover_DoubleClick(object sender, RoutedEventArgs e)
        {
            bntCover_Click(sender, e);




        }
        private void bntCover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected file's path
                string filePath = openFileDialog.FileName;

                // Read the file into a byte array
                byte[] imageData = File.ReadAllBytes(filePath);
            }
        }

        private void txtAlbumTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSave.IsEnabled = true;

        }

        private void txtArtist_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSave.IsEnabled = true;
        }

        private void cmbGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnSave.IsEnabled = true;
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSave.IsEnabled = true;
        }
    }
}
