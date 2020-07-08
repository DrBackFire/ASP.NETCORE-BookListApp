using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListApp.Pages.BookList
{
    public class EditModel : PageModel
    {
        // Using DI to access the Db
        private readonly ApplicationDbContext _db;

        // Extracting ApplicationDbContext inside DI Container and injecting it into this page
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        // Display method to display Book details
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            // Making a get req to Db to get the requested book using id
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost() // IActionResult is to redirect to a new page
        {
            if (ModelState.IsValid) // Validating user input on server-side
            {
                // Getting Book from Db
                var BookFromDb = await _db.Book.FindAsync(Book.Id);

                // Setting the user input to the retrived book
                BookFromDb.Title = Book.Title;
                BookFromDb.Author = Book.Author;
                BookFromDb.ISBN = Book.ISBN;

                // Saving changes to Db
                await _db.SaveChangesAsync();

                // Redirect to booklist page
                return RedirectToPage("Index");
            }
            else
            {
                // If no user input then return the same page
                return RedirectToPage();
            }
        }
    }
}