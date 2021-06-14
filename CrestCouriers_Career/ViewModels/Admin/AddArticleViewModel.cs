using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career.ViewModels.Admin
{
    public class AddArticleViewModel
    {

        public string Title { get; set; }

        public string ShortBody { get; set; }

        public string Body { get; set; }

        public string[] Tags { get; set; }

        public IFormFile ArticleImage { get; set; }

        public IEnumerable<IFormFile> Slides { get; set; }

        public string AuthorName { get; set; }

    }
}
