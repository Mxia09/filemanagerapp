using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FileManagerApp.Models;

namespace FileManagerApp.Data
{
    public class FileManagerAppContext : DbContext
    {
        public FileManagerAppContext (DbContextOptions<FileManagerAppContext> options)
            : base(options)
        {
        }

        public DbSet<FileManagerApp.Models.UploadedFile> UploadedFile { get; set; } = default!;
    }
}
