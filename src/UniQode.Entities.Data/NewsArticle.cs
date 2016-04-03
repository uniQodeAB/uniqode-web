using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Entities.Data.Core;

namespace UniQode.Entities.Data
{
    [Table("NewsArticles")]
    public class NewsArticle : Entity<long>
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Index(IsUnique = true)]
        [Required, MaxLength(100)]
        public string SearchableTitle { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}