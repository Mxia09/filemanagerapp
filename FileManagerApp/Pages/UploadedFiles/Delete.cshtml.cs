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
    public class DeleteModel : PageModel
    {
        private readonly FileManagerApp.Data.FileManagerAppContext _context;

        public DeleteModel(FileManagerApp.Data.FileManagerAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UploadedFile UploadedFile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadedfile = await _context.UploadedFile.FirstOrDefaultAsync(m => m.Id == id);

            if (uploadedfile is not null)
            {
                UploadedFile = uploadedfile;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadedfile = await _context.UploadedFile.FindAsync(id);
            if (uploadedfile != null)
            {
                UploadedFile = uploadedfile;
                _context.UploadedFile.Remove(UploadedFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
