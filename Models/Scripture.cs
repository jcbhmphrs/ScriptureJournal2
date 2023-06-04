using System.ComponentModel.DataAnnotations;

namespace ScriptureJournal2.Models
{
    public class Scripture
    {
        public int Id { get; set; }
        public string? Book { get; set; }
        public string? Chapter { get; set; }
        public string? Verse { get; set; }
        public string? Note { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
