using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Net;

namespace RazorManyToMany.Pages
{
    public class AuthorBookModel : PageModel
    {
        private readonly RazorManyToMany.Data.RazorManyToManyContext _context;

        public AuthorBookModel(RazorManyToMany.Data.RazorManyToManyContext context)
        {
            _context = context;
        }
        public IList<Book> Books { get; set; } = default!;
        public IList<Author> Authors { get; set; } = default!;
        [BindProperty]
        public Book Book { get; set; } = default!;
        [BindProperty]
        public Author Author { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Books = await _context.Book.Include(e => e.authors).ToListAsync();
            }
            if (_context.Author != null)
            {
                Authors = await _context.Author.Include(e => e.books).ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                int authorId = Convert.ToInt32(Request.Form["authors"]);
                int bookId = Convert.ToInt32(Request.Form["books"]);

                // find author and book from database AuthorBook
                var author = await _context.Author.Include(x => x.books).FirstOrDefaultAsync(y => y.id == authorId);
                if (author == null)
                {
                    return NotFound();
                }
                Author = author;
                var book = await _context.Book.Include(x => x.authors).FirstOrDefaultAsync(y => y.id == bookId);
                if (book == null)
                {
                    return NotFound();
                }
                Book = book;

                if (Author.books.Contains(Book) && Book.authors.Contains(Author))
                {
                    Author.books.Remove(Book);
                    _context.Attach(Author).State = EntityState.Modified;

                    Book.authors.Remove(Author);
                    _context.Attach(Book).State = EntityState.Modified;
                }
                else if (!Author.books.Contains(Book))
                {
                    Author.books.Add(Book);
                    _context.Attach(Author).State = EntityState.Modified;
                } else if (!Book.authors.Contains(Author))
                {
                    Book.authors.Add(Author);
                    _context.Attach(Book).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync();
            }
            return RedirectToPage("/AuthorBook");
        }
    }
}
