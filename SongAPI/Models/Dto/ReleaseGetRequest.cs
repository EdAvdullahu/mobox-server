namespace SongAPI.Models.Dto
{
    public class ReleaseGetRequest
    {
        public ReleaseDto Release { get; set; }
        public List<SongGetRequest> Songs { get; set; }
    }
}
