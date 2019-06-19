using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterDetail.Logic;
using MasterDetail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterDetail.Pages
{
    public class IndexModel : PageModel
    {
        public List<Post> Posts{ get; set; }
        public void OnGet()
        {
            var repo = new PostRepository();
            Posts = repo.GetAllPosts();
        }
    }
}