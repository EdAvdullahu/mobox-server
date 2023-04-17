namespace SongAPI.Models.Dto
{
    public class ReleasePostRequest
    {
        public ReleasePutPost Release { get; set; }
        public List <SongPostRequest> Songs { get; set; }
    }
}
