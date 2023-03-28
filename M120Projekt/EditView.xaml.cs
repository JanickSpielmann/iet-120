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
        MainWindow mainWindow;
        public EditView(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }
        public EditView(MainWindow mainWindow, Data.Record record)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            FillPage(record);
            
        }

        private void btnSave_DoubleClick(object sender,RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        public void FillPage(Data.Record record)
        { 
            txtAlbumTitle.Text = record.AlbumTitle;
            txtArtist.Text = record.Artist;
            cmbGenres.Text = record.Genre;
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
    }
}
