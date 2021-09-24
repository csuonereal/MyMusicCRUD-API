using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.Configs
{
    public class MusicConfig : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
            builder.HasOne(m => m.Artist).WithMany(m => m.Musics).HasForeignKey(m => m.ArtistId).OnDelete(DeleteBehavior.Cascade);
         
            

        }
    }
}
