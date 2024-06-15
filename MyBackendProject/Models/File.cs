namespace MyBackendProject.Models
{
    public class File
    {
        public int FileId { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime UploadTime { get; set; }
        public string Status { get; set; }
        public string OriginalFilePath { get; set; }
        public string ConvertedFilePath { get; set; }
        public User User { get; set; }
    }
}