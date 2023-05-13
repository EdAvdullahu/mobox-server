using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LyricsAPI.Models
{
    public class Annotation
    {
        [Key]
        public Guid AnnotationId { get; set; }
        public string AnnotationText { get; set; }

        [ForeignKey("Verse")]
        public Guid VerseId { get; set; }
        public Verse Verse { get; set; }
    }
}
