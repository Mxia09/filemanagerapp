using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FileManagerApp.Data;
using FileManagerApp.Models;

namespace FileManagerApp.Pages.UploadedFiles
{
    public class IndexModel : PageModel
    {
        private readonly FileManagerApp.Data.FileManagerAppContext _context;

        public IndexModel(FileManagerApp.Data.FileManagerAppContext context)
        {
            _context = context;
        }

        public IList<UploadedFile> UploadedFile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UploadedFile = await _context.UploadedFile.ToListAsync();
        }
    }
}
