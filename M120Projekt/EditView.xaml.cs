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
    /// Interaktionslogik für EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        private MainWindow mainWindow;
        private bool update;
        private Data.Record record;
        private List<string> genres;


        public EditView(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            CreateGenres();
            InitializeComponent();
            update = false;
        }

  

        public EditView(MainWindow mainWindow, Data.Record record)
        {
            this.record = record;
            this.mainWindow = mainWindow;
            CreateGenres();
            InitializeComponent();
            FillPage(record);
            update = true;
        }

        private void btnSave_DoubleClick(object sender,RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                record.AlbumTitle = txtAlbumTitle.ToString();
                record.Artist = txtArtist.ToString();
                record.ReleaseDate = (DateTime) dpiReleaseDate.SelectedDate;
                record.Price = double.Parse(txtPrice.Text); ;
                record.Own = (bool)ckbOwn.IsChecked;
                record.Update();
            }
            else
            {
                record = new Data.Record();
                record.AlbumTitle = txtAlbumTitle.ToString();
                record.Artist = txtArtist.ToString();
                record.ReleaseDate = (DateTime)dpiReleaseDate.SelectedDate;
                record.Price = double.Parse(txtPrice.Text);
                record.Own = (bool)ckbOwn.IsChecked;
                record.Create();
            }

            mainWindow.OpenListView();


        }

        public void FillPage(Data.Record record)
        { 
            txtAlbumTitle.Text = record.AlbumTitle;
            txtArtist.Text = record.Artist;
            cmbGenres.Text = record.Genre;
            txtPrice.Text = record.Price.ToString();
            OwnPrint(record);
        }

        private void CreateGenres()
        {
               genres = new List<string>{ 
           
                "Pop",
                "Rock",
                "Hip hop",
                "Electronic dance music (EDM)",
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
    }
}
