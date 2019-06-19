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
    public class PostModel : PageModel
    {
        public Post Post { get; set; }
        public void OnGet(int id)
        {
            PostRepository postRepository = new PostRepository();
            Post = postRepository.GetPostBy(id);
        }
    }
}