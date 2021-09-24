using AutoMapper;
using MyMusic.Entities.Entities;
using MyMusic.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.WebAPI
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Music, MusicDTO>();
            CreateMap<MusicDTO, Music>();

            CreateMap<Artist, ArtistDTO>();
            CreateMap<ArtistDTO, Artist>();

            CreateMap<Music, AddMusicDTO>();
            CreateMap<AddMusicDTO, Music>();


            CreateMap<Artist, AddArtistDTO>();
            CreateMap<AddArtistDTO, Artist>();
        }
       
    }
}
