using System.ComponentModel.DataAnnotations;
using System;

namespace FileManagerApp.Models;

public class UploadedFile
{
    public int Id { get; set; }
    public required string FileName { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public float FileSize { get; set; }
    public required string FilePath { get; set; }
}
