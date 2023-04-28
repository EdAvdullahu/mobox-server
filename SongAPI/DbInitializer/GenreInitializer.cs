using Microsoft.EntityFrameworkCore;
using SongAPI.Models;

namespace SongAPI.DbInitializer
{
    public class GenreInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public GenreInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    GenreId = 1,
                    Name = "Acoustic",
                    Description = "Acoustic music is a genre that emphasizes the use of acoustic instruments and natural sound, without the use of electronic or electric instruments. It often features a stripped-down, raw sound that highlights the musicality of the performers.",
                },
                new Genre()
                {
                    GenreId = 2,
                    Name = "Afrobeat",
                    Description = "Afrobeat is a music genre that originated in West Africa, characterized by a fusion of African rhythms and funk and jazz influences. It features complex percussion patterns, brass instrumentation, and call-and-response vocals.",
                },
                new Genre()
                {
                    GenreId = 3,
                    Name = "Alternative",
                    Description = "Alternative music is a broad term that refers to any music that is not mainstream or commercially popular. It encompasses a wide range of styles and genres, from indie rock and post-punk to electronic and experimental music.",
                },
                new Genre()
                {
                    GenreId = 4,
                    Name = "Ambient",
                    Description = "Ambient music is a genre that focuses on creating a mood or atmosphere through soundscapes and textures, often without a traditional melody or rhythm. It is often used in film and TV soundtracks and for relaxation or meditation purposes.",
                },
                new Genre()
                {
                    GenreId = 5,
                    Name = "Anime",
                    Description = "Anime music refers to the soundtracks and theme songs from Japanese animated TV shows and movies. It often features pop and rock influences, as well as orchestral and electronic elements.",
                },
                new Genre()
                {
                    GenreId = 6,
                    Name = "Blues",
                    Description = "Blues is a genre of music that originated in African American communities in the United States in the late 19th century. It features a distinctive 12-bar chord progression, call-and-response vocals, and often deals with themes of heartache, loss, and injustice.",
                },
                new Genre()
                {
                    GenreId = 7,
                    Name = "BossaNova",
                    Description = "Bossa nova is a genre of Brazilian music that originated in the late 1950s. It is characterized by its soft, lilting rhythms, gentle melodies, and often features the use of acoustic guitar and piano.",
                },
                new Genre()
                {
                    GenreId = 8,
                    Name = "Breakbeat",
                    Description = "Breakbeat is a genre of electronic music that originated in the mid-1980s. It is characterized by its heavy use of breaks, which are sampled from other songs and looped. Breakbeat is often used in the context of DJ sets and dance parties, and it is known for its high energy and fast-paced rhythms.",
                },
                new Genre()
                {
                    GenreId = 9,
                    Name = "Children",
                    Description = "Children's music is music that is specifically targeted at children. It includes nursery rhymes, lullabies, and educational songs, among other types of music. Children's music is often designed to be educational and entertaining, and it is an important part of many children's lives.",
                },
                new Genre()
                {
                    GenreId = 10,
                    Name = "Chill",
                    Description = "Chill music, also known as chillout, is a genre of electronic music that is characterized by its relaxed and mellow sound. It often features slow tempos, atmospheric textures, and ambient soundscapes. Chill music is often used for relaxation, meditation, and background music.",
                },
                new Genre()
                {
                    GenreId = 11,
                    Name = "Classical",
                    Description = "Classical music is a genre of music that originated in Europe in the late 18th century. It is characterized by its use of orchestral instruments, complex compositions, and formal structure. Classical music has had a significant impact on music throughout the centuries, and many iconic composers are considered to be among the greatest artists of all time.",
                },
                new Genre()
                {
                    GenreId = 12,
                    Name = "Club",
                    Description = "Club music is a genre of electronic dance music that is specifically designed for clubs and dance parties. It is characterized by its high energy and fast-paced rhythms, and it often incorporates elements of other genres such as techno, house, and trance. Club music is meant to be danced to, and it is popular in clubs around the world.",
                },
                new Genre()
                {
                    GenreId = 13,
                    Name = "Comedy",
                    Description = "Comedy music is a genre of music that is designed to be humorous. It can include parodies, satirical songs, and humorous skits. Some well-known comedy musicians include Weird Al Yankovic and Flight of the Conchords.",
                },
                new Genre()
                {
                    GenreId = 14,
                    Name = "Classical",
                    Description = "Classical music is a genre of music that originated in Europe around the mid-18th century. It is characterized by its formal structure, complex harmonies, and use of instruments such as the violin, piano, and cello. Famous classical composers include Mozart, Beethoven, and Bach.",
                },
                new Genre()
                {
                    GenreId = 15,
                    Name = "Country",
                    Description = "Country music is a genre of music that originated in the southern United States in the early 20th century. It is characterized by its use of stringed instruments such as the guitar and fiddle, as well as its themes of love, heartbreak, and rural life. Famous country musicians include Johnny Cash, Dolly Parton, and Garth Brooks.",
                },
                new Genre()
                {
                    GenreId = 16,
                    Name = "Dance",
                    Description = "Dance music is a genre of popular music that is designed for dancing. It is characterized by its repetitive beats and synthesized sounds. Popular dance music genres include disco, house, and techno.",
                },
                new Genre()
                {
                    GenreId = 17,
                    Name = "Deep House",
                    Description = "Deep house is a subgenre of house music that originated in the 1980s. It is characterized by its use of synthesizers, drum machines, and a slower tempo than other house music genres. Deep house is often associated with a more laid-back and relaxed atmosphere than other electronic dance music genres.",
                },
                new Genre()
                {
                    GenreId = 18,
                    Name = "Disco",
                    Description = "Disco is a genre of dance music that emerged in the 1970s and 1980s. It features a repetitive 4/4 beat and synthesized melodies and is known for its association with disco balls, colorful lights, and dancing.",
                },
                new Genre()
                {
                    GenreId = 19,
                    Name = "Disney",
                    Description = "Disney music refers to the soundtracks and songs featured in Disney movies and TV shows. It covers a wide range of genres, including pop, rock, musical theater, and orchestral music.",
                },
                new Genre()
                {
                    GenreId = 20,
                    Name = "Drum and Bass",
                    Description = "Drum and Bass is a subgenre of electronic music that emerged in the 1990s. It is characterized by fast breakbeats and heavy basslines, often with a dark or aggressive tone.",
                },
                new Genre()
                {
                    GenreId = 21,
                    Name = "Dub",
                    Description = "Dub is a genre of reggae that emerged in the 1960s. It features remixes of existing songs with emphasis on the drums and bass and the use of effects such as echo and reverb.",
                },
                new Genre()
                {
                    GenreId = 22,
                    Name = "Dubstep",
                    Description = "Dubstep is a genre of electronic dance music that emerged in the early 2000s. It features a syncopated rhythm and heavy basslines, often with a dark or aggressive tone.",
                },
                new Genre()
                {
                    GenreId = 23,
                    Name = "EDM",
                    Description = "EDM, short for Electronic Dance Music, is an umbrella term for various genres of electronic music designed for dance-based entertainment, such as house, techno, trance, and dubstep.",
                },
                new Genre()
                {
                    GenreId = 24,
                    Name = "Electro",
                    Description = "Electro is a genre of electronic dance music that emerged in the 1980s. It features a distinctive robotic sound, often achieved through the use of synthesizers and vocoders.",
                },
                new Genre()
                {
                    GenreId = 25,
                    Name = "Electronic",
                    Description = "Electronic music is a broad category of music that encompasses a wide range of electronic-based sounds, including synthpop, techno, house, and ambient.",
                },
                new Genre()
                {
                    GenreId = 26,
                    Name = "Emo",
                    Description = "Emo is a subgenre of punk rock that emerged in the 1990s. It features introspective and emotionally-charged lyrics, often dealing with topics such as heartbreak and self-doubt.",
                },
                new Genre()
                {
                    GenreId = 27,
                    Name = "Folk",
                    Description = "Folk music is a genre that encompasses a wide range of traditional and contemporary music styles. It features acoustic instruments such as guitar, banjo, and fiddle, and often tells stories or conveys social messages.",
                },
                new Genre()
                {
                    GenreId = 28,
                    Name = "Funk",
                    Description = "Funk is a music genre that originated in African American communities in the mid-1960s when musicians created a rhythmic, danceable new form of music through a mixture of soul, jazz, and R&B. Funk emphasizes the bassline and rhythm section and often features extended solos and complex, syncopated rhythms. Some of the most well-known funk artists include James Brown, Parliament-Funkadelic, Sly and the Family Stone, and Prince.",
                },
                new Genre()
                {
                    GenreId = 29,
                    Name = "Groove",
                    Description = "Groove is a music genre that originated in the 1970s and is characterized by its infectious, danceable rhythms and funky basslines. It has its roots in funk and soul music and has influenced many other genres, including hip hop, R&B, and electronic music. Some of the most well-known groove artists include Earth, Wind & Fire, Kool & the Gang, and Prince.",
                },
                new Genre()
                {
                    GenreId = 30,
                    Name = "Guitar",
                    Description = "Guitar music refers to any genre of music that prominently features the guitar. The guitar is a versatile instrument and is used in a wide variety of genres, from classical music to heavy metal. Guitar music is often characterized by its use of intricate melodies and complex chord progressions.",
                },
                new Genre()
                {
                    GenreId = 31,
                    Name = "Happy",
                    Description = "Happy music is any genre of music that is uplifting, cheerful, and positive in tone. It is often characterized by its upbeat tempo and catchy melodies. Happy music is often used in commercials, movies, and other media to evoke a positive emotional response from the listener.",
                },
                new Genre()
                {
                    GenreId = 32,
                    Name = "Hard Rock",
                    Description = "Hard rock is a subgenre of rock music that originated in the 1960s and is characterized by its heavy, amplified sound, distorted guitar riffs, and aggressive lyrics. Some of the most famous hard rock bands include AC/DC, Guns N' Roses, and Led Zeppelin.",
                },
                new Genre()
                {
                    GenreId = 33,
                    Name = "Heavy Metal",
                    Description = "Heavy metal is a genre of rock music that originated in the late 1960s and is characterized by its heavy, distorted guitars, fast tempo, and aggressive lyrics. Heavy metal is often associated with themes of power, rebellion, and anti-authority.",
                },
                new Genre()
                {
                    GenreId = 34,
                    Name = "Hip Hop",
                    Description = "Hip hop is a genre of music that originated in African American and Latinx communities in the United States in the 1970s. It is characterized by its use of rapping, DJing, and sampling, and often features politically and socially conscious lyrics. Hip hop has become one of the most popular genres of music in the world.",
                },
                new Genre()
                {
                    GenreId = 35,
                    Name = "Holidays",
                    Description = "Holiday music is any genre of music that is associated with a particular holiday or time of year. Examples include Christmas music, Hanukkah music, and Halloween music. Holiday music is often played in stores and on the radio during the holiday season.",
                },
                new Genre()
                {
                    GenreId = 36,
                    Name = "House",
                    Description = "House music is a genre of electronic dance music that originated in Chicago in the early 1980s. It is characterized by its repetitive 4/4 beat and synthesized melodies, often accompanied by samples or vocals. House music has since become a global phenomenon and has spawned many sub-genres.",
                },
                new Genre()
                {
                    GenreId = 37,
                    Name = "IDM",
                    Description = "Intelligent dance music (IDM) is a genre of electronic music that emerged in the early 1990s. It is characterized by complex rhythms, intricate melodies, and experimental sound design, often incorporating elements of ambient, techno, and breakbeat. IDM is often associated with artists on the Warp Records label, such as Aphex Twin and Autechre.",
                },
                new Genre()
                {
                    GenreId = 38,
                    Name = "Indie",
                    Description = "Indie music is a genre of alternative rock that emerged in the 1980s. It is characterized by its DIY ethos and rejection of mainstream culture, often featuring lo-fi production values and introspective lyrics. Indie music has since expanded to include many sub-genres, such as indie pop and indie folk.",
                },
                new Genre()
                {
                    GenreId = 39,
                    Name = "Industrial",
                    Description = "Industrial music is a genre of experimental music that emerged in the 1970s. It is characterized by its use of harsh, abrasive sounds, often created through the use of metal percussion and heavily distorted guitar and synth tones. Industrial music has since expanded to include many sub-genres, such as power electronics and rhythmic noise.",
                },
                new Genre()
                {
                    GenreId = 40,
                    Name = "Jazz",
                    Description = "Jazz is a genre of music that originated in African American communities during the late 19th and early 20th century. It is characterized by improvisation, syncopated rhythms, and the use of varied harmonic progressions.",
                },
                new Genre()
                {
                    GenreId = 41,
                    Name = "K-Pop",
                    Description = "K-Pop is a genre of popular music originating in South Korea. It is characterized by a wide variety of audiovisual elements, including colorful visuals, elaborate choreography, and a wide range of musical styles.",
                },
                new Genre()
                {
                    GenreId = 42,
                    Name = "Kids",
                    Description = "Kids music is specifically targeted to children, with simple lyrics, catchy melodies, and themes related to childhood experiences and learning.",
                },
                new Genre()
                {
                    GenreId = 43,
                    Name = "Latin",
                    Description = "Latin music encompasses a wide range of styles and genres from Latin America, including salsa, merengue, bachata, reggaeton, and more. It is characterized by vibrant rhythms, passionate vocals, and rich cultural influences.",
                },
                new Genre()
                {
                    GenreId = 44,
                    Name = "Metal",
                    Description = "Metal is a genre of rock music that emerged in the late 1960s and early 1970s. It is characterized by its heavy, distorted guitar sound, thunderous basslines, and powerful vocals.",
                },
                new Genre()
                {
                    GenreId = 45,
                    Name = "Movies",
                    Description = "Movie soundtracks are collections of music composed specifically for films. They often feature orchestral arrangements, vocal performances, and songs that are used to help convey the emotional tone and mood of the film.",
                },
                new Genre()
                {
                    GenreId = 46,
                    Name = "Opera",
                    Description = "A form of theater in which music has a leading role and the parts are taken by singers, typically in costumes and with minimal sets.",
                },
                new Genre()
                {
                    GenreId = 47,
                    Name = "Party",
                    Description = "A genre of music that is typically upbeat and played at parties or celebrations.",
                },
                new Genre()
                {
                    GenreId = 48,
                    Name = "Piano",
                    Description = "A genre of music that features the piano as the primary instrument.",
                },
                new Genre()
                {
                    GenreId = 49,
                    Name = "Pop",
                    Description = "A genre of popular music that originated in the 1950s and is characterized by catchy melodies and a strong rhythmic beat.",
                },
                new Genre()
                {
                    GenreId = 50,
                    Name = "Punk",
                    Description = "A genre of rock music that emerged in the mid-1970s and is characterized by fast, hard-edged music and often politically charged lyrics.",
                },
                new Genre()
                {
                    GenreId = 51,
                    Name = "R&B",
                    Description = "A genre of popular African-American music that originated in the 1940s and is characterized by a strong rhythm and blues influence.",
                },
                new Genre()
                {
                    GenreId = 52,
                    Name = "Rainy Day",
                    Description = "A genre of music that is relaxing and suitable for a rainy day.",
                },
                new Genre()
                {
                    GenreId = 53,
                    Name = "Reggae",
                    Description = "Reggae is a music genre that originated in Jamaica in the late 1960s. It is characterized by its off-beat rhythms, prominent basslines, and use of Jamaican Patois.",
                },
                new Genre()
                {
                    GenreId = 54,
                    Name = "Reggaeton",
                    Description = "Reggaeton is a music genre that originated in Puerto Rico in the early 1990s. It blends elements of reggae, hip-hop, and Latin American music styles such as salsa and merengue.",
                },
                new Genre()
                {
                    GenreId = 55,
                    Name = "Road Trip",
                    Description = "Road Trip music is a genre of music that is often associated with driving, adventure and travel. It typically features upbeat and catchy songs that are perfect for long car rides or exploring new destinations.",
                },
                new Genre()
                {
                    GenreId = 56,
                    Name = "Rock",
                    Description = "Rock music is a genre of popular music that originated as 'rock and roll' in the United States in the 1950s, and developed into a range of different styles in the 1960s and later.",
                },
                new Genre()
                {
                    GenreId = 57,
                    Name = "Rock 'n' Roll",
                    Description = "Rock 'n' roll is a genre of popular music that originated in the United States in the 1950s. It is characterized by its heavy use of electric guitars, bass guitar, and drums, and often features simple, catchy melodies and lyrics about teenage life and romance.",
                },
                new Genre()
                {
                    GenreId = 58,
                    Name = "Romance",
                    Description = "Romance music is a genre of music that is often associated with love, passion, and sensuality. It typically features slow, melodic songs with romantic lyrics and lush orchestration.",
                },
                new Genre()
                {
                    GenreId = 59,
                    Name = "Sad",
                    Description = "Sad music is a genre of music that is often associated with sadness, heartbreak, and emotional pain. It typically features slow, melancholic songs with sad lyrics and sparse instrumentation.",
                },
                new Genre()
                {
                    GenreId = 60,
                    Name = "Salsa",
                    Description = "Salsa is a music genre that originated in Cuba in the 1920s and 1930s. It is characterized by its lively, upbeat rhythms, use of brass instruments, and prominent percussion section.",
                },
                new Genre()
                {
                    GenreId = 61,
                    Name = "Samba",
                    Description = "Samba is a music genre that originated in Brazil in the early 20th century. It is characterized by its fast, syncopated rhythms, use of percussion instruments, and lively, upbeat melodies.",
                },
                new Genre()
                {
                    GenreId = 62,
                    Name = "Sleep",
                    Description = "Sleep music is a genre of music that is designed to promote relaxation and help listeners fall asleep. This type of music typically features slow, calming melodies and minimal instrumentation, and may include sounds such as white noise or nature sounds."
                },
                new Genre()
                {
                    GenreId = 63,
                    Name = "Soul",
                    Description = "Soul is a genre of music that originated in the United States in the 1950s and 1960s. It is characterized by its strong vocal performances and emphasis on rhythm and blues. Soul music often features a strong backbeat and horn section."
                },
                new Genre()
                {
                    GenreId = 64,
                    Name = "Soundtracks",
                    Description = "Soundtracks refer to the music that is featured in movies, TV shows, and video games. This music is often specifically composed for the production, and can include a wide variety of styles and genres."
                },
                new Genre()
                {
                    GenreId = 65,
                    Name = "Study",
                    Description = "Study music is a genre of music that is designed to help students focus and concentrate while studying or working. This type of music typically features instrumental arrangements with minimal lyrics and a calming, repetitive melody."
                },
                new Genre()
                {
                    GenreId = 66,
                    Name = "Summer",
                    Description = "Summer music is a genre of music that is associated with warm weather, outdoor activities, and relaxation. This type of music often features upbeat, tropical rhythms and lyrics that celebrate the joys of summer."
                },
                new Genre()
                {
                    GenreId = 67,
                    Name = "Tango",
                    Description = "Tango is a musical genre and dance that originated in the working-class port neighborhoods of Buenos Aires and Montevideo in the late 19th century, with influences from Italian, Spanish, and African music.",
                },
                new Genre()
                {
                    GenreId = 68,
                    Name = "Techno",
                    Description = "Techno is a genre of electronic dance music that emerged in Detroit, Michigan, in the United States during the mid-to-late 1980s.",
                },
                new Genre()
                {
                    GenreId = 69,
                    Name = "Trance",
                    Description = "Trance is a genre of electronic dance music that developed in the 1990s, characterized by a tempo of between 125 and 150 beats per minute, repetitive melodic phrases, and a musical form that builds up and breaks down throughout a track.",
                },
                new Genre()
                {
                    GenreId = 70,
                    Name = "Workout",
                    Description = "Workout music is a genre of music that is specifically designed to be played during exercise or fitness routines, often featuring upbeat tempos and motivating lyrics to encourage physical activity.",
                },
                new Genre()
                {
                    GenreId = 71,
                    Name = "World Music",
                    Description = "World music is a genre of music that encompasses traditional music from various cultures around the world, as well as contemporary fusion and crossover styles that incorporate elements of traditional music from different regions.",
                }
            );
        }
    }
}
