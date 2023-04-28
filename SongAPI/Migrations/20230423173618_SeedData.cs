using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269480/Artists/02-the-weeknd-press-2019-cr-Nabil-Elderkin-billboard-1548_fycfoa.jpg", "The Weeknd" },
                    { 2, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269732/Artists/ab67706c0000da84c3e6fe76812ed7962f227ef5_cubxpd.jpg", "Taylor Swift" },
                    { 3, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269761/Artists/ab6761610000e5eb9e690225ad4445530612ccc9_xlkvve.jpg", "Ed Sheeran" },
                    { 4, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269803/Artists/ab67616d00001e0258039b5147731b6e52202e46_uykiyz.jpg", "Miley Cyrus" },
                    { 5, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269822/Artists/93e6b100a00437a05f57aa66ce41208811296fc8_kdrzvk.jpg", "Shakira" },
                    { 6, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269842/Artists/1fc2f537d678d701d7d143a8fd4f0c2f29fbde22_din0jd.jpg", "Rihanna" },
                    { 7, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269870/Artists/ab6761610000e5ebcdce7620dc940db079bf4952_gnaodu.jpg", "Ariana Grande" },
                    { 8, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269892/Artists/ab6761610000e5eb8ae7f2aaa9817a704a87ea36_t0xtiu.jpg", "Justin Bieber" },
                    { 9, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269912/Artists/ab6761610000e5eb4293385d324db8558179afd9_n2wmlf.jpg", "Drake" },
                    { 10, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269931/Artists/ab6761610000e5eb75348e1aade2645ad9c58829_zwniut.jpg", "David Guetta" },
                    { 11, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269967/Artists/ab6761610000e5eb7eb7f6371aad8e67e01f0a03_uzxwhw.jpg", "SZA" },
                    { 12, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270017/Artists/ab6761610000e5eba00b11c129b27a88fc72f36b_jcnhb6.jpg", "Eminem" },
                    { 13, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270038/Artists/ab6761610000e5ebf7db7c8ede90a019c54590bb_uxyhzo.jpg", "Harry Styles" },
                    { 14, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270059/Artists/bad-bunny-spotify-record-1669829243_jtdn0r.jpg", "Bad Bunny" },
                    { 15, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270078/Artists/ab6761610000e5eb578905d5539cff25568dc097_xe3tuo.jpg", "Calvin Harris" },
                    { 16, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270096/Artists/ab6761610000e5eb989ed05e1f0570cc4726c2d3_abwerh.jpg", "Coldplay" },
                    { 17, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270113/Artists/ab6761610000e5ebd42a27db3286b58553da8858_otae5z.jpg", "Dua Lipa" },
                    { 18, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270132/Artists/ab67616d00001e02005cd7d0ae87b081601f6cca_uv6bz2.jpg", "Sam Smith" },
                    { 19, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270152/Artists/ab6761610000e5eb920dc1f617550de8388f368e_wngyms.jpg", "Imagine Dragons" },
                    { 20, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270170/Artists/cfd6e47fbe4446750ec209dfa37bc919cb55c86f_ywdkov.jpg", "21 Savage" },
                    { 21, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270197/Artists/ab6761610000e5ebc36dd9eb55fb0db4911f25dd_uwbq2j.jpg", "Bruno Mars" },
                    { 22, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270217/Artists/ab6761610000e5eba5205abffd84341e5bace828_a0bncr.jpg", "Selena Gomez" },
                    { 23, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270233/Artists/ab6761610000e5eb288ac05481cedc5bddb5b11b_zuuqjw.jpg", "Maroon 5" },
                    { 24, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270258/Artists/ab67616d00001e028093238ec0c71ef7c95c8fb1_pdh9d2.jpg", "Lady Gaga" },
                    { 25, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270278/Artists/ab67616d00001e024c65275edad3ab7ddb4ed230_hus4k6.jpg", "Post Malone" },
                    { 26, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270293/Artists/ab6761610000e5eb41e4a3b8c1d45a9e49b6de21_phywup.jpg", "Marshmello" },
                    { 27, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270309/Artists/ab6761610000e5eb6a0594d5bff11a7e0c7ceb1a_ce87cr.jpg", "Karol G" },
                    { 28, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270331/Artists/ab67616d0000b273fd61ea11e50ba0b7eade9466_tq2ae4.jpg", "Kanye West" },
                    { 29, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270354/Artists/Metro-Boomin_olzkw9.jpg", "Metro Boomin" },
                    { 30, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270386/Artists/ab67616d00001e02c42f6b7b41537a5fae06840a_o2m9g9.jpg", "Doja Cat" },
                    { 31, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270401/Artists/ab6761610000e5ebd8b9980db67272cb4d2c3daf_nr6ito.jpg", "Billie Eilish" },
                    { 32, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270420/Artists/ab6761610000e5ebdc9dcb7e4a97b4552e1224d6_foxi3d.jpg", "Katy Perry" },
                    { 33, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270437/Artists/ab6761610000e5eb31072db9da0311ecfabe96bf_ovmdnj.jpg", "Khalid" },
                    { 34, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270454/Artists/ab6761610000e5eb923e85a0eefbab49fd8d4920_tlxd4i.jpg", "Rauw Alejandro" },
                    { 35, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270477/Artists/ab67616d00001e02922a7339d969b5f0262580f5_nfwpzv.jpg", "J Balvin" },
                    { 36, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270493/Artists/ab6761610000e5eb68f6e5892075d7f22615bd17_musdvc.jpg", "Adele" },
                    { 37, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270508/Artists/ab6761610000e5ebe50aa80e0f5869f84f6874d1_u4vvar.jpg", "Chris Brown" },
                    { 38, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270539/Artists/Daddy-Yankee-MSG-July-2016-Billboard-1548_kzutuz.jpg", "Daddy Yankee" },
                    { 39, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270553/Artists/ab6761610000e5eb12e3f20d05a8d6cfde988715_rylfhj.jpg", "Beyoncé" },
                    { 41, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270581/Artists/2a832cd2b8dd5d0deef6d682ca52ea29f5dda859_igzpo8.jpg", "Nicki Minaj" },
                    { 42, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270598/Artists/ab6761610000e5eb77bf00f67e21f514dc44c485_xon2ed.jpg", "OneRepublic" },
                    { 43, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270614/Artists/ab67616d0000b273e0b64c8be3c4e804abcb2696_bwmsno.jpg", "Future" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 44, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270630/Artists/ab6761610000e5eb39ce949d62ff47fc1de1a2d9_pxtyqg.jpg", "Ozuna" },
                    { 46, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270658/Artists/ab6761610000e5ebe707b87e3f65997f6c09bfff_h6ynqo.jpg", "Travis Scott" },
                    { 47, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270677/Artists/af2b8e57f6d7b5d43a616bd1e27ba552cd8bfd42_pojktd.jpg", "Queen" },
                    { 48, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270700/Artists/ab67616d00001e028f072024e0358fc5c62eba41_x6euf6.jpg", "Rosalía" },
                    { 49, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270715/Artists/ab67616d00001e025d199c9f6e6562aafa5aa357_byexkr.jpg", "Sia" },
                    { 50, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270728/Artists/ab6761610000e5ebc692afc666512dc946a7358f_r3muiq.jpg", "Bebe Rexha" },
                    { 51, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270743/Artists/ab6761610000e5ebf0c20db5ef6c6fbe5135d2e4_qjm8hw.jpg", "XXXTENTACION" },
                    { 52, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270760/Artists/ab6761610000e5ebeb63bf6379a9ea8453a30020_tpxgs3.jpg", "Don Toliver" },
                    { 53, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270773/Artists/ab6761610000e5eb876faa285687786c3d314ae0_orb6p0.jpg", "Kid Cudi" },
                    { 54, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270798/Artists/ab67616d0000b273c1968cb5cd60558e0ca42b4b_ophtti.jpg", "Giveon" },
                    { 55, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270815/Artists/ab67706c0000da8465b1230626a7c2f4506f149b_qvqdo9.jpg", "Dave" },
                    { 56, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270833/Artists/mhevc5ptefhzny9zqw8a_do5tpq.jpg", "Baby Keem" },
                    { 57, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270848/Artists/ab6761610000e5ebbd5d3e1b363c3e26710661c3_kzniic.jpg", "Tory Lanez" },
                    { 58, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270864/Artists/ab67616d00001e02a1e8b73748ee972a4c22be16_lzl0jz.jpg", "Stormzy" },
                    { 59, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270879/Artists/ab6761610000e5eb803f228472451496cb2f5b88_osynjw.jpg", "Gunna" },
                    { 60, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270894/Artists/ab6761610000e5eb437b9e2a82505b3d93ff1022_zleojo.jpg", "Kendrick Lamar" },
                    { 61, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270909/Artists/ab6761610000e5eb8278b782cbb5a3963db88ada_x94wcf.jpg", "Tyler, The Creator" },
                    { 62, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270925/Artists/ab6761610000e5ebb99cacf8acd5378206767261_wrbjz4.jpg", "Lana Del Rey" },
                    { 63, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270942/Artists/ab6761610000e5eb4ddb58b186bace4ed7e9f26e_d8tdui.jpg", "Kali Uchis" },
                    { 64, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270966/Artists/ab67616d00001e02617c314e94693fad9a26f798_r2gpty.jpg", "Daniel Caesar" },
                    { 65, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270981/Artists/ab6761610000e5ebf8e7a2d1a01fd98e43ee57dc_odotcz.jpg", "6LACK" },
                    { 66, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270995/Artists/ab6761610000e5ebee452efcf24aa4124fb28d94_un9ioe.jpg", "A$AP Rocky" },
                    { 67, "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682271027/Artists/ab67616d0000b27323c552a7a4fdafac02e08c34_wyepjs.jpg", "Joji" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Acoustic music is a genre that emphasizes the use of acoustic instruments and natural sound, without the use of electronic or electric instruments. It often features a stripped-down, raw sound that highlights the musicality of the performers.", "Acoustic" },
                    { 2, "Afrobeat is a music genre that originated in West Africa, characterized by a fusion of African rhythms and funk and jazz influences. It features complex percussion patterns, brass instrumentation, and call-and-response vocals.", "Afrobeat" },
                    { 3, "Alternative music is a broad term that refers to any music that is not mainstream or commercially popular. It encompasses a wide range of styles and genres, from indie rock and post-punk to electronic and experimental music.", "Alternative" },
                    { 4, "Ambient music is a genre that focuses on creating a mood or atmosphere through soundscapes and textures, often without a traditional melody or rhythm. It is often used in film and TV soundtracks and for relaxation or meditation purposes.", "Ambient" },
                    { 5, "Anime music refers to the soundtracks and theme songs from Japanese animated TV shows and movies. It often features pop and rock influences, as well as orchestral and electronic elements.", "Anime" },
                    { 6, "Blues is a genre of music that originated in African American communities in the United States in the late 19th century. It features a distinctive 12-bar chord progression, call-and-response vocals, and often deals with themes of heartache, loss, and injustice.", "Blues" },
                    { 7, "Bossa nova is a genre of Brazilian music that originated in the late 1950s. It is characterized by its soft, lilting rhythms, gentle melodies, and often features the use of acoustic guitar and piano.", "BossaNova" },
                    { 8, "Breakbeat is a genre of electronic music that originated in the mid-1980s. It is characterized by its heavy use of breaks, which are sampled from other songs and looped. Breakbeat is often used in the context of DJ sets and dance parties, and it is known for its high energy and fast-paced rhythms.", "Breakbeat" },
                    { 9, "Children's music is music that is specifically targeted at children. It includes nursery rhymes, lullabies, and educational songs, among other types of music. Children's music is often designed to be educational and entertaining, and it is an important part of many children's lives.", "Children" },
                    { 10, "Chill music, also known as chillout, is a genre of electronic music that is characterized by its relaxed and mellow sound. It often features slow tempos, atmospheric textures, and ambient soundscapes. Chill music is often used for relaxation, meditation, and background music.", "Chill" },
                    { 11, "Classical music is a genre of music that originated in Europe in the late 18th century. It is characterized by its use of orchestral instruments, complex compositions, and formal structure. Classical music has had a significant impact on music throughout the centuries, and many iconic composers are considered to be among the greatest artists of all time.", "Classical" },
                    { 12, "Club music is a genre of electronic dance music that is specifically designed for clubs and dance parties. It is characterized by its high energy and fast-paced rhythms, and it often incorporates elements of other genres such as techno, house, and trance. Club music is meant to be danced to, and it is popular in clubs around the world.", "Club" },
                    { 13, "Comedy music is a genre of music that is designed to be humorous. It can include parodies, satirical songs, and humorous skits. Some well-known comedy musicians include Weird Al Yankovic and Flight of the Conchords.", "Comedy" },
                    { 14, "Classical music is a genre of music that originated in Europe around the mid-18th century. It is characterized by its formal structure, complex harmonies, and use of instruments such as the violin, piano, and cello. Famous classical composers include Mozart, Beethoven, and Bach.", "Classical" },
                    { 15, "Country music is a genre of music that originated in the southern United States in the early 20th century. It is characterized by its use of stringed instruments such as the guitar and fiddle, as well as its themes of love, heartbreak, and rural life. Famous country musicians include Johnny Cash, Dolly Parton, and Garth Brooks.", "Country" },
                    { 16, "Dance music is a genre of popular music that is designed for dancing. It is characterized by its repetitive beats and synthesized sounds. Popular dance music genres include disco, house, and techno.", "Dance" },
                    { 17, "Deep house is a subgenre of house music that originated in the 1980s. It is characterized by its use of synthesizers, drum machines, and a slower tempo than other house music genres. Deep house is often associated with a more laid-back and relaxed atmosphere than other electronic dance music genres.", "Deep House" },
                    { 18, "Disco is a genre of dance music that emerged in the 1970s and 1980s. It features a repetitive 4/4 beat and synthesized melodies and is known for its association with disco balls, colorful lights, and dancing.", "Disco" },
                    { 19, "Disney music refers to the soundtracks and songs featured in Disney movies and TV shows. It covers a wide range of genres, including pop, rock, musical theater, and orchestral music.", "Disney" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Description", "Name" },
                values: new object[,]
                {
                    { 20, "Drum and Bass is a subgenre of electronic music that emerged in the 1990s. It is characterized by fast breakbeats and heavy basslines, often with a dark or aggressive tone.", "Drum and Bass" },
                    { 21, "Dub is a genre of reggae that emerged in the 1960s. It features remixes of existing songs with emphasis on the drums and bass and the use of effects such as echo and reverb.", "Dub" },
                    { 22, "Dubstep is a genre of electronic dance music that emerged in the early 2000s. It features a syncopated rhythm and heavy basslines, often with a dark or aggressive tone.", "Dubstep" },
                    { 23, "EDM, short for Electronic Dance Music, is an umbrella term for various genres of electronic music designed for dance-based entertainment, such as house, techno, trance, and dubstep.", "EDM" },
                    { 24, "Electro is a genre of electronic dance music that emerged in the 1980s. It features a distinctive robotic sound, often achieved through the use of synthesizers and vocoders.", "Electro" },
                    { 25, "Electronic music is a broad category of music that encompasses a wide range of electronic-based sounds, including synthpop, techno, house, and ambient.", "Electronic" },
                    { 26, "Emo is a subgenre of punk rock that emerged in the 1990s. It features introspective and emotionally-charged lyrics, often dealing with topics such as heartbreak and self-doubt.", "Emo" },
                    { 27, "Folk music is a genre that encompasses a wide range of traditional and contemporary music styles. It features acoustic instruments such as guitar, banjo, and fiddle, and often tells stories or conveys social messages.", "Folk" },
                    { 28, "Funk is a music genre that originated in African American communities in the mid-1960s when musicians created a rhythmic, danceable new form of music through a mixture of soul, jazz, and R&B. Funk emphasizes the bassline and rhythm section and often features extended solos and complex, syncopated rhythms. Some of the most well-known funk artists include James Brown, Parliament-Funkadelic, Sly and the Family Stone, and Prince.", "Funk" },
                    { 29, "Groove is a music genre that originated in the 1970s and is characterized by its infectious, danceable rhythms and funky basslines. It has its roots in funk and soul music and has influenced many other genres, including hip hop, R&B, and electronic music. Some of the most well-known groove artists include Earth, Wind & Fire, Kool & the Gang, and Prince.", "Groove" },
                    { 30, "Guitar music refers to any genre of music that prominently features the guitar. The guitar is a versatile instrument and is used in a wide variety of genres, from classical music to heavy metal. Guitar music is often characterized by its use of intricate melodies and complex chord progressions.", "Guitar" },
                    { 31, "Happy music is any genre of music that is uplifting, cheerful, and positive in tone. It is often characterized by its upbeat tempo and catchy melodies. Happy music is often used in commercials, movies, and other media to evoke a positive emotional response from the listener.", "Happy" },
                    { 32, "Hard rock is a subgenre of rock music that originated in the 1960s and is characterized by its heavy, amplified sound, distorted guitar riffs, and aggressive lyrics. Some of the most famous hard rock bands include AC/DC, Guns N' Roses, and Led Zeppelin.", "Hard Rock" },
                    { 33, "Heavy metal is a genre of rock music that originated in the late 1960s and is characterized by its heavy, distorted guitars, fast tempo, and aggressive lyrics. Heavy metal is often associated with themes of power, rebellion, and anti-authority.", "Heavy Metal" },
                    { 34, "Hip hop is a genre of music that originated in African American and Latinx communities in the United States in the 1970s. It is characterized by its use of rapping, DJing, and sampling, and often features politically and socially conscious lyrics. Hip hop has become one of the most popular genres of music in the world.", "Hip Hop" },
                    { 35, "Holiday music is any genre of music that is associated with a particular holiday or time of year. Examples include Christmas music, Hanukkah music, and Halloween music. Holiday music is often played in stores and on the radio during the holiday season.", "Holidays" },
                    { 36, "House music is a genre of electronic dance music that originated in Chicago in the early 1980s. It is characterized by its repetitive 4/4 beat and synthesized melodies, often accompanied by samples or vocals. House music has since become a global phenomenon and has spawned many sub-genres.", "House" },
                    { 37, "Intelligent dance music (IDM) is a genre of electronic music that emerged in the early 1990s. It is characterized by complex rhythms, intricate melodies, and experimental sound design, often incorporating elements of ambient, techno, and breakbeat. IDM is often associated with artists on the Warp Records label, such as Aphex Twin and Autechre.", "IDM" },
                    { 38, "Indie music is a genre of alternative rock that emerged in the 1980s. It is characterized by its DIY ethos and rejection of mainstream culture, often featuring lo-fi production values and introspective lyrics. Indie music has since expanded to include many sub-genres, such as indie pop and indie folk.", "Indie" },
                    { 39, "Industrial music is a genre of experimental music that emerged in the 1970s. It is characterized by its use of harsh, abrasive sounds, often created through the use of metal percussion and heavily distorted guitar and synth tones. Industrial music has since expanded to include many sub-genres, such as power electronics and rhythmic noise.", "Industrial" },
                    { 40, "Jazz is a genre of music that originated in African American communities during the late 19th and early 20th century. It is characterized by improvisation, syncopated rhythms, and the use of varied harmonic progressions.", "Jazz" },
                    { 41, "K-Pop is a genre of popular music originating in South Korea. It is characterized by a wide variety of audiovisual elements, including colorful visuals, elaborate choreography, and a wide range of musical styles.", "K-Pop" },
                    { 42, "Kids music is specifically targeted to children, with simple lyrics, catchy melodies, and themes related to childhood experiences and learning.", "Kids" },
                    { 43, "Latin music encompasses a wide range of styles and genres from Latin America, including salsa, merengue, bachata, reggaeton, and more. It is characterized by vibrant rhythms, passionate vocals, and rich cultural influences.", "Latin" },
                    { 44, "Metal is a genre of rock music that emerged in the late 1960s and early 1970s. It is characterized by its heavy, distorted guitar sound, thunderous basslines, and powerful vocals.", "Metal" },
                    { 45, "Movie soundtracks are collections of music composed specifically for films. They often feature orchestral arrangements, vocal performances, and songs that are used to help convey the emotional tone and mood of the film.", "Movies" },
                    { 46, "A form of theater in which music has a leading role and the parts are taken by singers, typically in costumes and with minimal sets.", "Opera" },
                    { 47, "A genre of music that is typically upbeat and played at parties or celebrations.", "Party" },
                    { 48, "A genre of music that features the piano as the primary instrument.", "Piano" },
                    { 49, "A genre of popular music that originated in the 1950s and is characterized by catchy melodies and a strong rhythmic beat.", "Pop" },
                    { 50, "A genre of rock music that emerged in the mid-1970s and is characterized by fast, hard-edged music and often politically charged lyrics.", "Punk" },
                    { 51, "A genre of popular African-American music that originated in the 1940s and is characterized by a strong rhythm and blues influence.", "R&B" },
                    { 52, "A genre of music that is relaxing and suitable for a rainy day.", "Rainy Day" },
                    { 53, "Reggae is a music genre that originated in Jamaica in the late 1960s. It is characterized by its off-beat rhythms, prominent basslines, and use of Jamaican Patois.", "Reggae" },
                    { 54, "Reggaeton is a music genre that originated in Puerto Rico in the early 1990s. It blends elements of reggae, hip-hop, and Latin American music styles such as salsa and merengue.", "Reggaeton" },
                    { 55, "Road Trip music is a genre of music that is often associated with driving, adventure and travel. It typically features upbeat and catchy songs that are perfect for long car rides or exploring new destinations.", "Road Trip" },
                    { 56, "Rock music is a genre of popular music that originated as 'rock and roll' in the United States in the 1950s, and developed into a range of different styles in the 1960s and later.", "Rock" },
                    { 57, "Rock 'n' roll is a genre of popular music that originated in the United States in the 1950s. It is characterized by its heavy use of electric guitars, bass guitar, and drums, and often features simple, catchy melodies and lyrics about teenage life and romance.", "Rock 'n' Roll" },
                    { 58, "Romance music is a genre of music that is often associated with love, passion, and sensuality. It typically features slow, melodic songs with romantic lyrics and lush orchestration.", "Romance" },
                    { 59, "Sad music is a genre of music that is often associated with sadness, heartbreak, and emotional pain. It typically features slow, melancholic songs with sad lyrics and sparse instrumentation.", "Sad" },
                    { 60, "Salsa is a music genre that originated in Cuba in the 1920s and 1930s. It is characterized by its lively, upbeat rhythms, use of brass instruments, and prominent percussion section.", "Salsa" },
                    { 61, "Samba is a music genre that originated in Brazil in the early 20th century. It is characterized by its fast, syncopated rhythms, use of percussion instruments, and lively, upbeat melodies.", "Samba" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Description", "Name" },
                values: new object[,]
                {
                    { 62, "Sleep music is a genre of music that is designed to promote relaxation and help listeners fall asleep. This type of music typically features slow, calming melodies and minimal instrumentation, and may include sounds such as white noise or nature sounds.", "Sleep" },
                    { 63, "Soul is a genre of music that originated in the United States in the 1950s and 1960s. It is characterized by its strong vocal performances and emphasis on rhythm and blues. Soul music often features a strong backbeat and horn section.", "Soul" },
                    { 64, "Soundtracks refer to the music that is featured in movies, TV shows, and video games. This music is often specifically composed for the production, and can include a wide variety of styles and genres.", "Soundtracks" },
                    { 65, "Study music is a genre of music that is designed to help students focus and concentrate while studying or working. This type of music typically features instrumental arrangements with minimal lyrics and a calming, repetitive melody.", "Study" },
                    { 66, "Summer music is a genre of music that is associated with warm weather, outdoor activities, and relaxation. This type of music often features upbeat, tropical rhythms and lyrics that celebrate the joys of summer.", "Summer" },
                    { 67, "Tango is a musical genre and dance that originated in the working-class port neighborhoods of Buenos Aires and Montevideo in the late 19th century, with influences from Italian, Spanish, and African music.", "Tango" },
                    { 68, "Techno is a genre of electronic dance music that emerged in Detroit, Michigan, in the United States during the mid-to-late 1980s.", "Techno" },
                    { 69, "Trance is a genre of electronic dance music that developed in the 1990s, characterized by a tempo of between 125 and 150 beats per minute, repetitive melodic phrases, and a musical form that builds up and breaks down throughout a track.", "Trance" },
                    { 70, "Workout music is a genre of music that is specifically designed to be played during exercise or fitness routines, often featuring upbeat tempos and motivating lyrics to encourage physical activity.", "Workout" },
                    { 71, "World music is a genre of music that encompasses traditional music from various cultures around the world, as well as contemporary fusion and crossover styles that incorporate elements of traditional music from different regions.", "World Music" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Artists");
        }
    }
}
