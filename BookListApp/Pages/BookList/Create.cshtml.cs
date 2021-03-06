﻿using System;
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

        // The bind proberty is used so that no need for paramters to be passed on post req.
        [BindProperty]
        // Display method to display Book details
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        // Post Handeler
        public async Task<IActionResult> OnPost() // IActionResult is to redirect to a new page
        {
            if (ModelState.IsValid) // Validating user input on server-side
            {
                // Getting new book ready to be added to Db
                await _db.Book.AddAsync(Book);

                // Saving changes to Db
                await _db.SaveChangesAsync();

                // Redirect to booklist page
                return RedirectToPage("Index");
            }else
            {
                // If no user input then return the same page
                return Page();
            }
        }
    }
}