using Microsoft.AspNetCore.Mvc;
using Mission11_Zein.Models;
using Mission11_Zein.Models.ViewModels;
using System.Linq;

namespace Mission11_Zein.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepo;

        public HomeController(IBookRepository temp)
        {
            _bookRepo = temp;
        }

        public IActionResult Index(int pageNum = 1, string category = null)
        {
            int pageSize = 10;

            IQueryable<Book> bookQuery = _bookRepo.Books;
            if (!string.IsNullOrEmpty(category))
            {
                bookQuery = bookQuery.Where(b => b.Category == category);
            }

            var blah = new BookListViewModels
            {
                Books = bookQuery
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = bookQuery.Count()
                },

                Categories = _bookRepo.Books
                    .Select(b => b.Category)
                    .Distinct()
                    .OrderBy(c => c)
            };

            return View(blah);
        }
    }
}
