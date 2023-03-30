using System;
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
            // UserGuide(); // Ready, if doubleklicking a record in the list to open it is not clear for the users
        }

        private void UserGuide()
        {
            String userGuide = "To select a single record you can doubleklick it";
            MessageBoxResult result = MessageBox.Show(userGuide, "User Guide", MessageBoxButton.OK);
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
