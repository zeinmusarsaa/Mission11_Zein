using Microsoft.AspNetCore.Mvc;
using Mission11_Zein.Models;
using Mission11_Zein.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Zein.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepo;

        public HomeController(IBookRepository temp)
        {
            _bookRepo = temp;
        }

        public IActionResult Index(int pageNum)
        {

            int pageSize = 10;

            var categories = _bookRepo.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(c => c);

            var blah = new BookListViewModels
            {
                Books = _bookRepo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepo.Books.Count()
                },

                Categories = categories
            };
            return View(blah);
        }
    }
}