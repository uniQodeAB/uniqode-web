﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UniQode.Common.Extensions;
using UniQode.Entities.Data;
using UniQode.Entities.Enums;

namespace UniQode.Models.Shared
{
    public class NewsArticleModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        //[Required]
        public long Id { get; set; }

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
        
        [Required, MaxLength(100)]
        public string SearchableTitle { get; private set; }

        [Required, MaxLength(32)]
        public string Category { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public State State { get; set; }

        [Bindable(false)]
        public AdminAction Action { get; set; }

        public static NewsArticleModel FromDto(NewsArticle dto)
        {
            if (dto == null)
                return null;

            return new NewsArticleModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Category = dto.Category,
                Body = dto.Body,
                Created = dto.Created,
                Modified = dto.Modified
            };
        }

        public NewsArticle ToDto()
        {
            return new NewsArticle
            {
                Id = this.Id,
                Title = this.Title,
                SearchableTitle = this.SearchableTitle,
                Category = this.Category,
                Body = this.Body,
                Created = this.Created,
                Modified = this.Modified
            };
        }
    }
}