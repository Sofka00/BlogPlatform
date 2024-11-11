namespace BlogPlatform.Models.Responses
{
    public class SubscriptionResponse  //podpiska
    {
        public Guid Id { get; set; }
        public int SubscriberId { get; set; }
        public int SubscribedId { get; set; }
    }
}
