namespace Web
{
    public static class SD
    {
        public static string SongApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public static string SessionToken = "JWTToken";
    }
}
