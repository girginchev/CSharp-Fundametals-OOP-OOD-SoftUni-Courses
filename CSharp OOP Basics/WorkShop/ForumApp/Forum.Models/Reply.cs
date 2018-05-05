using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Reply
    {
        public Reply(int id, string content, int authorId, int postId)
        {
            this.Id = id;
            this.Content = content;
            this.Author = authorId;
            this.Post = postId;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public int Author { get; set; }

        public int Post { get; set; }
    }
}
