namespace PodcastAPI.Models.Dto
{
    public class PodcastLikeDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
        public DateTime LikeDateTime { get; set; }
    }
    public class PodcastLikePutPost
    {
        public int UserId { get; set; }
        public int PodcastId { get; set; }
        public DateTime LikeDateTime { get; set; }
    }

}
