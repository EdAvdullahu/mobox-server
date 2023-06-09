﻿namespace SongAPI.Models
{
    public class SongLike
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public DateTime LikeDateTime { get; set; }
    }
}
