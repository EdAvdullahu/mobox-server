namespace PodcastAPI.Models.Dto
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int OwnerId { get; set; }
        //public ICollection<Collaboration> Collaborations { get; set; }
        public ICollection<PlaylistPodcast> Podcasts { get; set; }
        public int LikesCount { get; set; }
    }
    public class PlaylistPutPost
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int OwnerId { get; set; }
    }
    public class PodcastPlaylistPutPost
    {
        public Guid Id { get; set; }
        public int PodcastId { get; set; }
    }
    public class PodcastPlaylistDto
    {
        public int Id { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }

}
