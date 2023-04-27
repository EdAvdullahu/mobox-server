namespace Web.Models.Dto
{
    public class GenreDto
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
