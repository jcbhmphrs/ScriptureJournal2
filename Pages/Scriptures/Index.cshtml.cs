using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal2.Data;
using ScriptureJournal2.Models;

namespace ScriptureJournal2.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal2.Data.ScriptureJournal2Context _context;

        public IndexModel(ScriptureJournal2.Data.ScriptureJournal2Context context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;


        [BindProperty(SupportsGet = true)]
        public string? SearchBook { get; set; }



        [BindProperty(SupportsGet = true)]
        public string? SearchNote { get; set; }



        [BindProperty(SupportsGet = true)]
        public DateTime? SearchDate { get; set; }



        public SelectList? Books { get; set; }
       
        public SelectList? Dates { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from s in _context.Scripture orderby s.Book select s.Book;           
            IQueryable<DateTime> dateQuery = from s in _context.Scripture orderby s.DateAdded.Date select s.DateAdded.Date;
            var scriptures = from m in _context.Scripture select m;

            if (!string.IsNullOrEmpty(SearchBook))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(SearchBook));
            }
            if (!string.IsNullOrEmpty(SearchNote))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(SearchNote));
            }
            if(SearchDate != null)
            {
                scriptures = scriptures.Where(s => s.DateAdded == SearchDate);
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());           
            Dates = new SelectList(await dateQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
    }
}
