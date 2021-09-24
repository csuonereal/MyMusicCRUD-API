using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.WebAPI.Models
{
    public class AddMusicDTO
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }
    }
}
