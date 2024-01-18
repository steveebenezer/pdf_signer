using CsvHelper;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;

namespace PDFSigner.Model
{
    public class StudentManager
    {
        public static ObservableCollection<Student> _DatabaseStudents = new ObservableCollection<Student>();

        public static ObservableCollection<Student> GetStudents()
        {
            return _DatabaseStudents;
        }

        public static void AddStudent(Student student)
        {
            _DatabaseStudents.Add(student);
        }

        public static void LoadStudentsFromCsv()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            // Set the initial directory to the user's "Documents" folder
            string documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            fileDialog.InitialDirectory = documentsFolderPath;
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "Bulk Import CSV | Bulk-Import.csv";
            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                string path = fileDialog.FileName;
                LoadStudentsFromCsvFile(path);
            }
        }

        public static void LoadStudentsFromCsvFile(string filePath)
        {
            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<Student>().ToList();

                _DatabaseStudents.Clear();
                foreach (var student in records)
                {
                    student.IsUploaded = false;
                    student.IsSigned = false;
                    AddStudent(student);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found, format issues)
                Console.WriteLine("Error loading students from CSV file: " + ex.Message);
            }
        }
    }
}
