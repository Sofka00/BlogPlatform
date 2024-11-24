﻿using System;
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
        public string AuthorId { get; set; }       
        public string Content { get; set; }         
        public DateTime CreatedAt { get; set; }      
    }
}
