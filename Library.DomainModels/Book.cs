    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

// domain model should be mirror of the DB
// everything you'll use, though some may be null at times

namespace Library.DomainModels
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(150)]
        public string Title { get; set; }

        [NotNull]
        public bool IsAvailable { get; set; }

        [NotNull]
        public DateTime CreatedOn { get; set; }

        [NotNull]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [NotNull]
        public Uri ImageUrl { get; set; }
    }
}
