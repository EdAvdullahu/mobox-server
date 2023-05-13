using System.ComponentModel.DataAnnotations.Schema;

namespace LyricsAPI.Models.Dto
{
    public class VerseDto
    {
        public Guid VerseId { get; set; }
        public bool Annotated { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public Guid LyricId { get; set; }
        public Lyric Lyric { get; set; }
        public Guid AnnotationId { get; set; }
        public Annotation Annotation { get; set; }
    }
    public class VersePut
    {
        public Guid VerseId { get; set; }
        public bool Annotated { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public Guid LyricId { get; set; }
        public Guid AnnotationId { get; set; }
        public string Annotation { get; set; }
    }
    public class VersePost
    {
        public string Text { get; set; }
        public int Order { get; set; }
        public string Annotation { get; set; }
    }
}
