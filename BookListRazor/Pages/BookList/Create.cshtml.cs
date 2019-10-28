using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book book { get; set; }

        public void OnGet(int id)
        {
            book = _db.Books.Where(x => x.Id == id).FirstOrDefault();
            
        }

        public async Task<IActionResult> OnPost(int id=0)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if(id == 0)
                {
                    _db.Books.Add(book);
                }
                else
                {
                    book.Id = id;
                    _db.Entry(book).State = EntityState.Modified;
                }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            

        }
    }
}