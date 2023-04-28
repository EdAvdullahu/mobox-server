using Microsoft.EntityFrameworkCore;
using SongAPI.Models;

namespace SongAPI.DbInitializer
{
    public class ArtistInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public ArtistInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist() { ArtistId = 1, Name = "The Weeknd", ImageUrl= "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269480/Artists/02-the-weeknd-press-2019-cr-Nabil-Elderkin-billboard-1548_fycfoa.jpg" },
                new Artist() { ArtistId = 2, Name = "Taylor Swift", ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269732/Artists/ab67706c0000da84c3e6fe76812ed7962f227ef5_cubxpd.jpg" },
                new Artist() { ArtistId = 3, Name = "Ed Sheeran", ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269761/Artists/ab6761610000e5eb9e690225ad4445530612ccc9_xlkvve.jpg" },
                new Artist() { ArtistId = 4, Name = "Miley Cyrus", ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269803/Artists/ab67616d00001e0258039b5147731b6e52202e46_uykiyz.jpg" },
                new Artist() { ArtistId = 5, Name = "Shakira", ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269822/Artists/93e6b100a00437a05f57aa66ce41208811296fc8_kdrzvk.jpg" },
                new Artist() { ArtistId = 6, Name = "Rihanna", ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269842/Artists/1fc2f537d678d701d7d143a8fd4f0c2f29fbde22_din0jd.jpg" },
                new Artist() { ArtistId = 7, Name = "Ariana Grande" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269870/Artists/ab6761610000e5ebcdce7620dc940db079bf4952_gnaodu.jpg" },
                new Artist() { ArtistId = 8, Name = "Justin Bieber" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269892/Artists/ab6761610000e5eb8ae7f2aaa9817a704a87ea36_t0xtiu.jpg" },
                new Artist() { ArtistId = 9, Name = "Drake" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269912/Artists/ab6761610000e5eb4293385d324db8558179afd9_n2wmlf.jpg" },
                new Artist() { ArtistId = 10, Name = "David Guetta" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269931/Artists/ab6761610000e5eb75348e1aade2645ad9c58829_zwniut.jpg" },
                new Artist() { ArtistId = 11, Name = "SZA" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682269967/Artists/ab6761610000e5eb7eb7f6371aad8e67e01f0a03_uzxwhw.jpg" },
                new Artist() { ArtistId = 12, Name = "Eminem" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270017/Artists/ab6761610000e5eba00b11c129b27a88fc72f36b_jcnhb6.jpg" },
                new Artist() { ArtistId = 13, Name = "Harry Styles" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270038/Artists/ab6761610000e5ebf7db7c8ede90a019c54590bb_uxyhzo.jpg" },
                new Artist() { ArtistId = 14, Name = "Bad Bunny" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270059/Artists/bad-bunny-spotify-record-1669829243_jtdn0r.jpg" },
                new Artist() { ArtistId = 15, Name = "Calvin Harris" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270078/Artists/ab6761610000e5eb578905d5539cff25568dc097_xe3tuo.jpg" },
                new Artist() { ArtistId = 16, Name = "Coldplay" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270096/Artists/ab6761610000e5eb989ed05e1f0570cc4726c2d3_abwerh.jpg" },
                new Artist() { ArtistId = 17, Name = "Dua Lipa" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270113/Artists/ab6761610000e5ebd42a27db3286b58553da8858_otae5z.jpg" },
                new Artist() { ArtistId = 18, Name = "Sam Smith" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270132/Artists/ab67616d00001e02005cd7d0ae87b081601f6cca_uv6bz2.jpg" },
                new Artist() { ArtistId = 19, Name = "Imagine Dragons" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270152/Artists/ab6761610000e5eb920dc1f617550de8388f368e_wngyms.jpg" },
                new Artist() { ArtistId = 20, Name = "21 Savage" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270170/Artists/cfd6e47fbe4446750ec209dfa37bc919cb55c86f_ywdkov.jpg" },
                new Artist() { ArtistId = 21, Name = "Bruno Mars" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270197/Artists/ab6761610000e5ebc36dd9eb55fb0db4911f25dd_uwbq2j.jpg" },
                new Artist() { ArtistId = 22, Name = "Selena Gomez" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270217/Artists/ab6761610000e5eba5205abffd84341e5bace828_a0bncr.jpg" },
                new Artist() { ArtistId = 23, Name = "Maroon 5" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270233/Artists/ab6761610000e5eb288ac05481cedc5bddb5b11b_zuuqjw.jpg" },
                new Artist() { ArtistId = 24, Name = "Lady Gaga" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270258/Artists/ab67616d00001e028093238ec0c71ef7c95c8fb1_pdh9d2.jpg" },
                new Artist() { ArtistId = 25, Name = "Post Malone" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270278/Artists/ab67616d00001e024c65275edad3ab7ddb4ed230_hus4k6.jpg" },
                new Artist() { ArtistId = 26, Name = "Marshmello" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270293/Artists/ab6761610000e5eb41e4a3b8c1d45a9e49b6de21_phywup.jpg" },
                new Artist() { ArtistId = 27, Name = "Karol G" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270309/Artists/ab6761610000e5eb6a0594d5bff11a7e0c7ceb1a_ce87cr.jpg" },
                new Artist() { ArtistId = 28, Name = "Kanye West" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270331/Artists/ab67616d0000b273fd61ea11e50ba0b7eade9466_tq2ae4.jpg" },
                new Artist() { ArtistId = 29, Name = "Metro Boomin" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270354/Artists/Metro-Boomin_olzkw9.jpg" },
                new Artist() { ArtistId = 30, Name = "Doja Cat" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270386/Artists/ab67616d00001e02c42f6b7b41537a5fae06840a_o2m9g9.jpg" },
                new Artist() { ArtistId = 31, Name = "Billie Eilish" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270401/Artists/ab6761610000e5ebd8b9980db67272cb4d2c3daf_nr6ito.jpg" },
                new Artist() { ArtistId = 32, Name = "Katy Perry" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270420/Artists/ab6761610000e5ebdc9dcb7e4a97b4552e1224d6_foxi3d.jpg" },
                new Artist() { ArtistId = 33, Name = "Khalid" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270437/Artists/ab6761610000e5eb31072db9da0311ecfabe96bf_ovmdnj.jpg" },
                new Artist() { ArtistId = 34, Name = "Rauw Alejandro" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270454/Artists/ab6761610000e5eb923e85a0eefbab49fd8d4920_tlxd4i.jpg" },
                new Artist() { ArtistId = 35, Name = "J Balvin" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270477/Artists/ab67616d00001e02922a7339d969b5f0262580f5_nfwpzv.jpg" },
                new Artist() { ArtistId = 36, Name = "Adele" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270493/Artists/ab6761610000e5eb68f6e5892075d7f22615bd17_musdvc.jpg" },
                new Artist() { ArtistId = 37, Name = "Chris Brown" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270508/Artists/ab6761610000e5ebe50aa80e0f5869f84f6874d1_u4vvar.jpg" },
                new Artist() { ArtistId = 38, Name = "Daddy Yankee" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270539/Artists/Daddy-Yankee-MSG-July-2016-Billboard-1548_kzutuz.jpg" },
                new Artist() { ArtistId = 39, Name = "Beyoncé" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270553/Artists/ab6761610000e5eb12e3f20d05a8d6cfde988715_rylfhj.jpg" },
                new Artist() { ArtistId = 41, Name = "Nicki Minaj" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270581/Artists/2a832cd2b8dd5d0deef6d682ca52ea29f5dda859_igzpo8.jpg" },
                new Artist() { ArtistId = 42, Name = "OneRepublic" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270598/Artists/ab6761610000e5eb77bf00f67e21f514dc44c485_xon2ed.jpg" },
                new Artist() { ArtistId = 43, Name = "Future" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270614/Artists/ab67616d0000b273e0b64c8be3c4e804abcb2696_bwmsno.jpg" },
                new Artist() { ArtistId = 44, Name = "Ozuna" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270630/Artists/ab6761610000e5eb39ce949d62ff47fc1de1a2d9_pxtyqg.jpg" },
                new Artist() { ArtistId = 46, Name = "Travis Scott" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270658/Artists/ab6761610000e5ebe707b87e3f65997f6c09bfff_h6ynqo.jpg" },
                new Artist() { ArtistId = 47, Name = "Queen" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270677/Artists/af2b8e57f6d7b5d43a616bd1e27ba552cd8bfd42_pojktd.jpg" },
                new Artist() { ArtistId = 48, Name = "Rosalía" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270700/Artists/ab67616d00001e028f072024e0358fc5c62eba41_x6euf6.jpg" },
                new Artist() { ArtistId = 49, Name = "Sia" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270715/Artists/ab67616d00001e025d199c9f6e6562aafa5aa357_byexkr.jpg" },
                new Artist() { ArtistId = 50, Name = "Bebe Rexha" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270728/Artists/ab6761610000e5ebc692afc666512dc946a7358f_r3muiq.jpg" },
                new Artist() { ArtistId = 51, Name = "XXXTENTACION" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270743/Artists/ab6761610000e5ebf0c20db5ef6c6fbe5135d2e4_qjm8hw.jpg" },
                new Artist() { ArtistId = 52, Name = "Don Toliver" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270760/Artists/ab6761610000e5ebeb63bf6379a9ea8453a30020_tpxgs3.jpg" },
                new Artist() { ArtistId = 53, Name = "Kid Cudi" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270773/Artists/ab6761610000e5eb876faa285687786c3d314ae0_orb6p0.jpg" },
                new Artist() { ArtistId = 54, Name = "Giveon" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270798/Artists/ab67616d0000b273c1968cb5cd60558e0ca42b4b_ophtti.jpg" },
                new Artist() { ArtistId = 55, Name = "Dave" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270815/Artists/ab67706c0000da8465b1230626a7c2f4506f149b_qvqdo9.jpg" },
                new Artist() { ArtistId = 56, Name = "Baby Keem" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270833/Artists/mhevc5ptefhzny9zqw8a_do5tpq.jpg" },
                new Artist() { ArtistId = 57, Name = "Tory Lanez" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270848/Artists/ab6761610000e5ebbd5d3e1b363c3e26710661c3_kzniic.jpg" },
                new Artist() { ArtistId = 58, Name = "Stormzy" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270864/Artists/ab67616d00001e02a1e8b73748ee972a4c22be16_lzl0jz.jpg" },
                new Artist() { ArtistId = 59, Name = "Gunna" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270879/Artists/ab6761610000e5eb803f228472451496cb2f5b88_osynjw.jpg" },
                new Artist() { ArtistId = 60, Name = "Kendrick Lamar" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270894/Artists/ab6761610000e5eb437b9e2a82505b3d93ff1022_zleojo.jpg" },
                new Artist() { ArtistId = 61, Name = "Tyler, The Creator" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270909/Artists/ab6761610000e5eb8278b782cbb5a3963db88ada_x94wcf.jpg" },
                new Artist() { ArtistId = 62, Name = "Lana Del Rey" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270925/Artists/ab6761610000e5ebb99cacf8acd5378206767261_wrbjz4.jpg" },
                new Artist() { ArtistId = 63, Name = "Kali Uchis" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270942/Artists/ab6761610000e5eb4ddb58b186bace4ed7e9f26e_d8tdui.jpg" },
                new Artist() { ArtistId = 64, Name = "Daniel Caesar" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270966/Artists/ab67616d00001e02617c314e94693fad9a26f798_r2gpty.jpg" },
                new Artist() { ArtistId = 65, Name = "6LACK" , ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270981/Artists/ab6761610000e5ebf8e7a2d1a01fd98e43ee57dc_odotcz.jpg" },
                new Artist() { ArtistId = 66, Name = "A$AP Rocky", ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682270995/Artists/ab6761610000e5ebee452efcf24aa4124fb28d94_un9ioe.jpg" },
                new Artist() { ArtistId = 67, Name = "Joji", ImageUrl = "https://res.cloudinary.com/ddd8z6szf/image/upload/v1682271027/Artists/ab67616d0000b27323c552a7a4fdafac02e08c34_wyepjs.jpg" }

                );
        }
    }
}
