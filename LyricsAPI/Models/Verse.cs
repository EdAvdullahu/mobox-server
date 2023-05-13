using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LyricsAPI.Models
{
    public class Verse
    {
        [Key]
        public Guid VerseId { get; set; }
        public bool Annotated { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public Guid LyricId { get; set; }
        public Lyric Lyric { get; set; }

        [ForeignKey("Annotation")]
        public Guid AnnotationId { get; set; }
        public Annotation Annotation { get; set; }
    }
}
