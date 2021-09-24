using MyMusic.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Entities.Entities
{
   public class Artist:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Music> Musics { get; set; }
    }
}
