using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class Post
    {
        [Newtonsoft.Json.JsonProperty("userId")]
        public int UserId { get; set; }
        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }
        [Newtonsoft.Json.JsonProperty("body")]
        public string Body { get; set; }


        public override string ToString()
        {
            return $@"
            userId = {UserId}
            id = {Id}
            title = {Title}
            body = {Body}
            ";
        }

    }
}
