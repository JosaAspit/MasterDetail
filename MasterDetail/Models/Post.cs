using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetail.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public string Body { get; set; }
        public string BodyShort
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                    return "...";

                int length = 15;

                if (Body.Length > length)
                {
                    return Body.Substring(0, length) + "...";
                }
                else
                {
                    return Body;
                }
            }
        }

        public override string ToString()
        {
            return $"{Author}|{Body}|{Id}|{Title}|{PostDate}";
        }
    }
}
