using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBook.Model;

namespace RazorBook.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            Book = await _db.Books.FindAsync(Id);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bookFromDb = await _db.Books.FindAsync(Book.Id);
            bookFromDb.Name = Book.Name;
            bookFromDb.ISBN = Book.ISBN;
            bookFromDb.Author = Book.Author;
            await _db.SaveChangesAsync();

            Message = "Book has been updated successfully";

            return RedirectToPage("Index");
        }
    }
}
