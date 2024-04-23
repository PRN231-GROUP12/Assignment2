using System;
using System.Collections.Generic;
using PRN231_Group12.Assignment2.Repo.Entity;

namespace PRN231_Group12.Assignment2.Repo
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? PublisherId { get; set; }
        public decimal Price { get; set; }
        public decimal? Advance { get; set; }
        public decimal? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PublishedDate { get; set; }

        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
