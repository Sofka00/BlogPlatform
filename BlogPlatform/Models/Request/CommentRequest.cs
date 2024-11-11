namespace BlogPlatform.Models.Request
{
    public class CommentRequest
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }


    }
}
