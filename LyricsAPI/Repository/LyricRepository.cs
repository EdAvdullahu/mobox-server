using AutoMapper;
using LyricsAPI.DbContexts;
using LyricsAPI.Models;
using LyricsAPI.Models.Dto;
using LyricsAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LyricsAPI.Repository
{
    public class LyricRepository : ILyricRespository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public LyricRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LyricDto> CreateUpdateSong(LyricPut songPut)
        {
            Lyric lyric = new Lyric()
            {
                SongId = songPut.SongId,
            };
            _context.Lyrics.Add(lyric);
            await _context.SaveChangesAsync();
            await addVerses(songPut.Verses, lyric.LyricId);
            return _mapper.Map<LyricDto>(lyric);
        }

        private async Task addVerses(IList<VersePost> verses, Guid lyricsId)
        {
            foreach (VersePost versePost in verses)
            {
                Verse newVerse = new Verse()
                {
                    LyricId = lyricsId,
                    Annotated = !string.IsNullOrEmpty(versePost.Annotation),
                    Order = versePost.Order,
                    Text = versePost.Text,
                };

                await _context.Verses.AddAsync(newVerse);
                await _context.SaveChangesAsync();

                if (!string.IsNullOrEmpty(versePost.Annotation))
                {
                    Annotation newAnnotation = new Annotation()
                    {
                        AnnotationText = versePost.Annotation,
                        VerseId = newVerse.VerseId,
                    };

                    await _context.Annotations.AddAsync(newAnnotation);
                    await _context.SaveChangesAsync();

                    newVerse.AnnotationId = newAnnotation.AnnotationId;
                    await _context.SaveChangesAsync();
                }
            }
        }



        public async Task<IEnumerable<LyricDto>> GetLyrics()
        {
            IEnumerable<Lyric> list = await _context.Lyrics.ToListAsync();
            return _mapper.Map<List<LyricDto>>(list);
        }

        public async Task<LyricDto> GetLyricsById(Guid LyricsId)
        {
            Lyric lyrics = await _context.Lyrics.Include(x => x.Verses).ThenInclude(x => x.Annotation).FirstOrDefaultAsync(x => x.LyricId == LyricsId);
            LyricDto lyricsDto = _mapper.Map<LyricDto>(lyrics);
            return lyricsDto;
        }

        public async Task<LyricDto> GetLyricsBySongApiId(int SongId)
        {
            Lyric lyrics = await _context.Lyrics.Include(x => x.Verses).ThenInclude(x => x.Annotation).FirstOrDefaultAsync(x => x.Song.SongApiId == SongId);
            LyricDto lyricsDto = _mapper.Map<LyricDto>(lyrics);
            return lyricsDto;
        }

        public async Task<LyricDto> GetLyricsBySongId(Guid SongId)
        {
            Lyric lyrics = await _context.Lyrics.Include(x=>x.Verses).ThenInclude(x=>x.Annotation).FirstOrDefaultAsync(x => x.SongId == SongId);
            LyricDto lyricsDto = _mapper.Map<LyricDto>(lyrics);
            return lyricsDto;
        }

        public async Task<bool> DeleteLyric(Guid lyricId)
        {
            try
            {
                Verse[] verses = await _context.Verses
                    .Where(v => v.LyricId == lyricId)
                    .Include(v => v.Annotation)
                    .ToArrayAsync();

                foreach (Verse verse in verses)
                {
                    if (verse.Annotation != null)
                    {
                        _context.Annotations.Remove(verse.Annotation);
                    }
                }

                _context.Verses.RemoveRange(verses);
                Lyric lyric = await _context.Lyrics.Where(x => x.LyricId == lyricId).FirstOrDefaultAsync();
                if (lyric == null)
                {
                    return false;
                }
                _context.Lyrics.Remove(lyric);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
