using System.ComponentModel.DataAnnotations;

namespace LyricsAPI.Models.Dto
{
    public class SongDto
    {
        public Guid SongId { get; set; }
        public int SongApiId { get; set; }
        public string SongName { get; set; }
    }
    public class SongPut
    {
        public int SongApiId { get; set; }
        public string SongName { get; set; }
    }
}
