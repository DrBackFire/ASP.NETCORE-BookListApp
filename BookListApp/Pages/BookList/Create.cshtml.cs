using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListApp.Pages.BookList
{
    public class CreateModel : PageModel
    {
        // Using DI to access the Db
        private readonly ApplicationDbContext _db;

        // Extracting ApplicationDbContext inside DI Container and injecting it into this page
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // Display method to display Book details
        public Book Book { get; set; }
        public void OnGet()
        {

        }
    }
}