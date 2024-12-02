using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL.DTOs
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; } // eto for bll
        public User User { get; set; } // shob ef core ponimal
        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }
        public ICollection <Comment> Comment { get; set; }
        public int CommentsCount { get; set; }
        public int LikeCount { get; set; }

    }
}
