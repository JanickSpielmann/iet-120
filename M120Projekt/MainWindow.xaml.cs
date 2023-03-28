using System.Windows;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RecordView recordView;
        private ListView listView;
        private EditView editView;
        public MainWindow()
        {
            InitializeComponent();
            OpenListView();

            #region Demo
            //  Aufruf diverse APIDemo Methoden
            //  API.CreateNirvana();
            //  API.CreateACDC();
            //  API.RecordRead();
            //  API.RecordUpdate();
            //  API.RecordRead();
            //  API.RecordDelete();
            #endregion Demo
        }

        public void OpenRecordView(long id)
        {
            recordView = new RecordView(this,id);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(recordView);
        }
        public void OpenListView()
        {
            listView = new ListView(this);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(listView);
        }
        public void OpenEditView()
        {
            editView = new EditView(this);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(editView);
        }
        public void OpenEditView(Data.Record record)
        {
            editView = new EditView(this,record);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(editView);
        }

    }
}
