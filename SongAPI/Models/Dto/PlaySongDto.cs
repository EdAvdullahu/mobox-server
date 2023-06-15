namespace SongAPI.Models.Dto
{
    public class PlaySongDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public DateTime ListenDateTime { get; set; }
    }
    public class PlaySongCreateDto
    {
        public int UserId { get; set; }
        public int SongId { get; set; }
    }
}
