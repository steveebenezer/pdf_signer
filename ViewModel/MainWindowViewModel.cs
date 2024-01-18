using PDFSigner.Core;
using PDFSigner.Model;
using System.Collections.ObjectModel;

namespace PDFSigner.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Student> Students { get; set; }
        public MainWindowViewModel()
        {
            Students = StudentManager.GetStudents();
        }

    }
}
