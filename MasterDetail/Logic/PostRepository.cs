using MasterDetail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetail.Logic
{
    public class PostRepository
    {
        private string path = "C:/Output/";
        private string fileName = "Posts.txt";
        private string seperator = "|";

        public List<Post> GetAllPosts()
        {
            string fullPath = path + fileName;
            var output = new List<Post>();

            if (!File.Exists(fullPath))
                return new List<Post>() {
                    new Post
                    {
                        Author = "Jens-Ole",
                        Body = "Velkommen til min hjemmeside",
                        Id = -1,
                        PostDate = DateTime.Now,
                        Title = "Første Post!!"
                    },
                    new Post
                    {
                        Author = "Mikkel B",
                        Body = "Razor pages er super sejt!!!",
                        Id = -2,
                        PostDate = DateTime.Now.AddDays(1),
                        Title = "JEG POSTER FRA FREMTIDEN"
                    }
                };

            using(StreamReader reader = new StreamReader(fullPath))
            {
                string line = null;
                while((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(seperator);
                    output.Add(new Post()
                    {
                        Author = values[0],
                        Body = values[1],
                        Id = int.Parse(values[2]),
                        Title = values[3],
                        PostDate = DateTime.Parse(values[4])
                    });
                }
            }

            return output;
        }

        public Post GetPostBy(int Id)
        {
            var posts = GetAllPosts();

            foreach (var item in posts)
            {
                if (item.Id == Id)
                {
                    return item;
                }
            }

            return null;
        }

        public void NewPost(Post post)
        {
            string fullPath = path + fileName;

            int newId = GetAllPosts().Count;

            using(StreamWriter writer = new StreamWriter(fullPath, true))
            {
                string line = $"{post.Author}|{post.Body}|{newId}|{post.Title}|{DateTime.Now.ToString()}";

                writer.WriteLine(line);
            }
        }

        public void DeletePost(int id)
        {
            string fullPath = path + fileName;
            var posts = GetAllPosts();

            //find the post to remove
            var postToRemove = posts.Where(x => x.Id == id).FirstOrDefault();

            posts.Remove(postToRemove);

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                for (int i = 0; i < posts.Count; i++)
                {
                    posts[i].Id = i + 1;
                    writer.WriteLine(posts[i]);
                }
            }
        }

        public IEnumerable<Post> GetPostBy(Func<Post, bool> pred)
        {
            var posts = GetAllPosts();

            foreach (var item in posts)
                if (pred(item))
                    yield return item;
        }
    }
}
