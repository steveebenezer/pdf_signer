using PDFSigner.Model;
using PDFSigner.ViewModel;
using System.Windows;

namespace PDFSigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            MainWindowViewModel vm = new MainWindowViewModel();
            this.DataContext = vm;
        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            StudentManager.LoadStudentsFromCsv();
        }
    }
}