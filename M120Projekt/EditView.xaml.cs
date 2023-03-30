using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            FillPage();
            update = false;
            btnSave.Content = "Create";
        }



        public EditView(MainWindow mainWindow, Data.Record record)
        {
            this.record = record;
            this.mainWindow = mainWindow;
            InitializeComponent();
            CreateGenres();
            FillPage(record);
            update = true;
            MarkGreen();
        }



        private void SetSaveButton()
        {
            btnSave.IsEnabled = true;

            if (txtAlbumTitle.Text.Replace(" ", "").Length == 0)
            {
                btnSave.IsEnabled = false;
            }
            if (txtArtist.Text.Replace(" ", "").Length == 0)
            {
                btnSave.IsEnabled = false;
            }
            if (cmbGenres.Text.Replace(" ", "").Length == 0)
            {
                btnSave.IsEnabled = false;
            }
            if (dpiReleaseDate.Text.Replace(" ", "").Length == 0)
            {
                btnSave.IsEnabled = false;
            }
            if (txtPrice.Text.Replace(" ", "").Length == 0)
            {
                btnSave.IsEnabled = false;
            }

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
                record.Genre = cmbGenres.Text;
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
                record.Genre = cmbGenres.Text;
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
            "",
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

        public void FillPage()
        {
            dpiReleaseDate.SelectedDate = DateTime.Now;
        }
        public void FillPage(Data.Record record)
        {
            txtAlbumTitle.Text = record.AlbumTitle;
            txtArtist.Text = record.Artist;
            cmbGenres.SelectedValue = record.Genre;
            dpiReleaseDate.SelectedDate = record.ReleaseDate;
            txtPrice.Text = record.Price.ToString("F2");
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
            SetSaveButton();



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

        private void txtAlbumTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            SetSaveButton();
            if (txtAlbumTitle.Text.Replace(" ", "").Length > 0)
            {
                txtAlbumTitle.Background = Brushes.LightGreen;
            }
            else
            {
                txtAlbumTitle.Background = Brushes.White;
                txtAlbumTitle.Text = string.Empty;
            }

        }

        private void txtArtist_LostFocus(object sender, RoutedEventArgs e)
        {

            SetSaveButton();
            if (txtArtist.Text.Replace(" ", "").Length > 0)
            {
                txtArtist.Background = Brushes.LightGreen;
            }
            else
            {
                txtArtist.Background = Brushes.White;
                txtArtist.Text = string.Empty;
            }
        }
       

        private void cmbGenres_LostFocus(object sender, RoutedEventArgs e)
        {
            SetSaveButton();
        }

        private void dpiReleaseDate_LostFocus(object sender, RoutedEventArgs e)
        {
            SetSaveButton();
        }

        private void txtPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            SetSaveButton();

            Regex regex = new Regex(@"^[0-9]+(\.[0-9]+)?$");
            Match match = regex.Match(txtPrice.Text);
            if (match.Success)
            {
                txtPrice.Background = Brushes.LightGreen;
            }
            else
            {
                txtPrice.Background = Brushes.White;
                txtPrice.Text = string.Empty;

            }
        }
        private void MarkGreen()
        {
            txtAlbumTitle.Background = Brushes.LightGreen;
            txtArtist.Background= Brushes.LightGreen;
            txtPrice.Background= Brushes.LightGreen;
        }

        private void ckbOwn_Click(object sender, RoutedEventArgs e)
        {
            SetSaveButton();
        }
    }
}

