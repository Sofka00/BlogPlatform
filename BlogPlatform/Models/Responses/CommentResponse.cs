﻿namespace BlogPlatform.Models.Responses
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
