using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrestCouriers_Career.Models;
using System.ComponentModel.DataAnnotations;

namespace CrestCouriers_Career.ViewModels.Admin
{
    public class AddArticleViewModel
    {
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string ShortBody { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Body { get; set; }

        public IEnumerable<string> Tags { get; set; }

        [Required]
        public IFormFile ArticleImage { get; set; }

        [MinLength(1)]
        public IEnumerable<IFormFile> Slides { get; set; }

        [Required]
        [MaxLength(50)]
        public string AuthorName { get; set; }



    }
}
