using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListApp.Pages.BookList
{
    public class IndexModel : PageModel
    {
        // Using DI to access the Db
        private readonly ApplicationDbContext _db;

        // Extracting ApplicationDbContext inside DI Container and injecting it into this page
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // Returning a list of Books
        public IEnumerable<Book> Books { get; set; }

        // Using async await to handel req
        public async Task OnGet()
        {
            // Calling Db & getting all books and storing it into Books
            Books = await _db.Book.ToListAsync();
        }
    }
}
