using CrestCouriers_Career.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.ViewModels.Admin
{
    public class EditArticleViewModel
    {

        public Article ForEditArticle { get; set; }

        public IFormFile ArticleImage { get; set; }

        public IEnumerable<Image> ForEditSlideImages { get; set; }

        public IEnumerable<IFormFile> EditedSlides { get; set; }

        public IEnumerable<string> Tags { get; set; }


    }
}
