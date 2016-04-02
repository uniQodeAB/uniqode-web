using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Common.Extensions;
using UniQode.Entities.Data.Core;

namespace UniQode.Entities.Data
{
    [Table("NewsArticles")]
    public class NewsArticle : Entity<long>
    {
        private string _title;

        [Required, MaxLength(100)]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SearchableTitle = _title.SanitizeTitle();
            }
        }

        [Index(IsUnique = true)]
        [Required, MaxLength(100)]
        public string SearchableTitle { get; private set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}