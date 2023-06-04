using Microsoft.EntityFrameworkCore;
using ScriptureJournal2.Data;
using ScriptureJournal2.Models;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ScriptureJournal2Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<ScriptureJournal2Context>>()))
        {
            if (context == null || context.Scripture == null)
            {
                throw new ArgumentNullException("Null ScriptureJournal2Context");
            }

            // Look for any Scriptures.
            if (context.Scripture.Any())
            {
                return;   // DB has been seeded
            }

            context.Scripture.AddRange(
                new Scripture
                {
                    Book = "Alma",
                    Chapter = "Five",
                    Verse = "Four",
                    Note = "Red Blue Hot",
                    DateAdded = DateTime.Parse("1949-2-1"),
                },

                new Scripture
                {
                    Book = "Moroni",
                    Chapter = "Three",
                    Verse = "Two",
                    Note = "Yellow Green Cold",
                    DateAdded = DateTime.Parse("1954-3-2"),
                },

                new Scripture
                {
                    Book = "Enos",
                    Chapter = "One",
                    Verse = "Twelve",
                    Note = "Red Green Hot",
                    DateAdded = DateTime.Parse("1958-6-4"),
                },

                new Scripture
                {
                    Book = "Mosiah",
                    Chapter = "Three",
                    Verse = "Ten",
                    Note = "Yellow Black Hot",
                    DateAdded = DateTime.Parse("1958-6-4"),
                },

                new Scripture
                {
                    Book = "3 Nephi",
                    Chapter = "Four",
                    Verse = "Two",
                    Note = "Blue White Cold",
                    DateAdded = DateTime.Parse("1967-1-11"),
                },

                new Scripture
                {
                    Book = "Enos",
                    Chapter = "One",
                    Verse = "Thirteen",
                    Note = "Black White Hot",
                    DateAdded = DateTime.Parse("1973-7-12"),
                },

                new Scripture
                {
                    Book = "3 Nephi",
                    Chapter = "Seven",
                    Verse = "Eight",
                    Note = "White Green Cold",
                    DateAdded = DateTime.Parse("1973-7-12"),
                }
            );
            context.SaveChanges();
        }
    }
}