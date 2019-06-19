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
    public class AddPostModel : PageModel
    {
        [BindProperty]
        public Post Post { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            try
            {
                PostRepository repo = new PostRepository();

                repo.NewPost(Post);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Redirect("Index");
        }
    }
}