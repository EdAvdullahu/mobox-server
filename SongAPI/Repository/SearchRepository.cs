using AutoMapper.Features;
using SongAPI.DbContexts;
using SongAPI.Models;
using SongAPI.Repository.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Gma.DataStructures.StringSearch;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SongAPI.Models.Dto;
using AutoMapper;
using System.Threading.Tasks;

namespace SongAPI.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SearchRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public object SearchByName(string[] name)
        {
            var searchTerms = name.Select(k => k.Split(' ')).ToArray();
            var query = (from artist in _context.Artists
                         join release in _context.Releases on artist.ArtistId equals release.ArtistId
                         join song in _context.Songs on release.ReleaseId equals song.ReleaseId
                         select new
                         {
                             ArtistId = artist.ArtistId,
                             Name = artist.Name,
                             ImageUrl = artist.ImageUrl,
                             Song = new
                             {
                                 SongId = song.SongId,
                                 Name = song.Name,
                                 ReleaseDate = song.ReleaseDate,
                                 Length = song.Length,
                                 Path = song.Path,
                                 ImageUrl = song.ImageUrl,
                                 ReleaseId = song.ReleaseId,
                                 IsExplicite = song.IsExplicite,
                                 Features = _context.Features.Where(f => f.SongId == song.SongId).ToList()
                             }
                         }).AsEnumerable()
                         .Where(item => searchTerms.All(search => search.Any(term => (item.Song.Name + " " + item.Name).ToLower().Contains(term.ToLower()))));
            var results = query.ToList<object>();
            var artistsQuery = _context.Artists.AsEnumerable()
                .Where(item => searchTerms.All(search => search.Any(term => item.Name.ToLower().Contains(term.ToLower()))))
                .Select(x => new
                {
                    ArtistId = x.ArtistId,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                });
            var releasesQuery = _context.Releases.AsEnumerable()
            .Where(item => searchTerms.All(search => search.Any(term => item.Title.ToLower().Contains(term.ToLower()))))
                .Select(x => new
                {
                    ReleaseId = x.ReleaseId,
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                    ImageUrl = x.ImageUrl,
                    ReleaseType = x.ReleaseType,
                    Description = x.Description,
                });
            var returnObj = new
            {
                Artists = artistsQuery.ToList<object>(),
                Advanced = results,
                Releases = releasesQuery.ToList<object>()
            };
            return returnObj;


            // Create a Trie and add search terms
            // Split the search term into individual keywords
            /*var trie = new Trie<string>();
            foreach (var term in searchTerms.SelectMany(x => x))
            {
                trie.Add(term.ToLower(), term.ToLower());
            }

            // Get all songs, releases, and artists that match the search terms
            var results = new List<ArtistReturn>();
            foreach (var artist in _context.Artists.Include(x=>x.Releases).ThenInclude(y=>y.Songs))
            {
                foreach (var release in artist.Releases)
                {
                    foreach (var song in release.Songs)
                    {
                        if (song != null && artist != null) // check if song and artist are not null
                        {
                            var artistSongName = $"{song.Name} {artist.Name}".ToLower();
                            var matches = trie.Retrieve(artistSongName);

                            if (matches.Any())
                            {
                                var result = new ArtistReturn
                                {
                                    ArtistId = artist.ArtistId,
                                    Name = artist.Name,
                                    ImageUrl = artist.ImageUrl,
                                    Song = new SongArtisGet
                                    {
                                        SongId = song.SongId,
                                        Name = song.Name,
                                        ReleaseDate = song.ReleaseDate,
                                        Length = song.Length,
                                        Path = song.Path,
                                        ImageUrl = song.ImageUrl,
                                        Features = _context.Features.Where(f => f.SongId == song.SongId).ToList()
                                    }
                                };
                                results.Add(result);
                            }
                        }
                    }
                }
            }


            // Order the results based on the number of search term matches

            var orderedResults = results.OrderByDescending((x) =>
            {
                var artistSongName = $"{x.Song.Name} {x.Name}".ToLower();
                var matches = trie.Retrieve(artistSongName);
                return new
                {
                    Item = x,
                    MatchCount = matches.Count()
                };
            }).ToList();



            return new
            {
                result = orderedResults,
                unordered = results
            };*/


        }

        public async Task<List<object>> SearchSongByGenreAsync(int[] genres)
        {
            var songsWithGenres = await _context.Songs
                .Include(s => s.Genres)
                .ThenInclude(gs => gs.Genre)
                .Where(s => s.Genres.Any(gs => genres.Contains(gs.GenreId)))
                .Select(x => new
                {
                    SongId = x.SongId,
                    Name = x.Name,
                    ReleaseDate = x.ReleaseDate,
                    Length = x.Length,
                    Path = x.Path,
                    ImageUrl = x.ImageUrl,
                    Features = _context.Features.Where(f => f.SongId == x.SongId).ToList(),
                    Genres = x.Genres.Select(g => new
                    {
                        GenreId = g.GenreId,
                        Name = g.Genre.Name
                    }).ToList()
                })
                .ToListAsync();
            return songsWithGenres.Select(x => (object)x).ToList();
        }

        public async Task<IEnumerable<dynamic>> FilterByGere(string genres)
        {
            var result = await _context.Songs.FromSqlRaw($"FilterByGenre {genres}").ToListAsync();
            return result;
        }
        private class ArtistReturn
        {
            public int ArtistId { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public SongArtisGet Song { get; set; }
        }
        private class SongArtisGet
        {
            public int SongId { get; set ;}
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            public TimeSpan Length { get; set; }
            public string Path { get; set; }
            public string ImageUrl { get; set; }
            public List<Feature> Features { get; set; }
        }
    }
}
