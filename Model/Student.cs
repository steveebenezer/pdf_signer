using CsvHelper.Configuration.Attributes;

namespace PDFSigner.Model
{
    public class Student
    {
        public Student()
        {
            
        }

        [Name("Roll No")]
        public string RollNo { get; set; }

        [Name("File Name")]
        public string FileName { get; set; }

        [Name("IsSigned")]
        [Optional]
        public bool? IsSigned { get; set; }

        [Name("IsUploaded")]
        [Optional]
        public bool? IsUploaded { get; set; }
    }
}
