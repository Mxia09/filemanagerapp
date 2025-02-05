using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileManagerApp.Data;
using FileManagerApp.Models;

namespace FileManagerApp.Pages.UploadedFiles
{
    public class EditModel : PageModel
    {
        private readonly FileManagerApp.Data.FileManagerAppContext _context;

        public EditModel(FileManagerApp.Data.FileManagerAppContext context)
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

            var uploadedfile =  await _context.UploadedFile.FirstOrDefaultAsync(m => m.Id == id);
            if (uploadedfile == null)
            {
                return NotFound();
            }
            UploadedFile = uploadedfile;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UploadedFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadedFileExists(UploadedFile.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UploadedFileExists(int id)
        {
            return _context.UploadedFile.Any(e => e.Id == id);
        }
    }
}
