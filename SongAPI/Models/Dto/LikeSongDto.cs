namespace SongAPI.Models.Dto
{
    public class LikeSongDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public DateTime LikeDateTime { get; set; }
    }
    public class LikeSongPutPost
    {
        public int UserId { get; set; }
        public int SongId { get; set; }
        public DateTime LikeDateTime { get; set; }
    }
}
