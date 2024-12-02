using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL.DTOs
{
    public class Comment
    {
        public Guid Id { get; set; }               
        public Guid PostId { get; set; }            
        public string UserId { get; set; }       
        public string Content { get; set; }  
        public Post Post { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }      
    }
}
