using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FileManagerApp.Data;
using FileManagerApp.Models;

namespace FileManagerApp.Pages.UploadedFiles
{
    public class CreateModel : PageModel
    {
        private readonly FileManagerApp.Data.FileManagerAppContext _context;

        public CreateModel(FileManagerApp.Data.FileManagerAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UploadedFile UploadedFile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UploadedFile.Add(UploadedFile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
