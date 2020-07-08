using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookListApp.Controllers
{
    // Adding a rounte to making API calls
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        // Using DI to access the Db
        private readonly ApplicationDbContext _db;

        // Extracting ApplicationDbContext inside DI Container and injecting it into this page
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Making a get req
        [HttpGet]
        public IActionResult GetAll()
        {
            // Making an API Call
            return Json(new { data = _db.Book.ToList() });
        }
    }
}
