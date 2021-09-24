using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Business.Interfaces;
using MyMusic.Entities.Entities;
using MyMusic.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.WebAPI.Controllers
{

    public class MusicController : BaseApiController
    {

        private readonly IMusicService _musicService;
        public MusicController(IMusicService musicService, IMapper mapper) : base(mapper)
        {
            _musicService = musicService;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<List<Music>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllAsync();
            return Ok(_mapper.Map<List<MusicDTO>>(musics));
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Music>> GetMusicById(int id)
        {
            var music = await _musicService.GetByIdAsync(id);
            return Ok(music);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Music>> AddNewMusic([FromBody] AddMusicDTO model)
        {
            await _musicService.CreateAsync(_mapper.Map(model, new Music()));
            return Ok();
        }

        [HttpPost("edit/{id}")]
        public async Task<ActionResult<Music>> EditMusic([FromBody] MusicDTO model)
        {
            var toBeUpdated = await _musicService.GetByIdAsync(model.Id);
            toBeUpdated.ArtistId = model.ArtistId;
            toBeUpdated.Name = model.Name;
            await _musicService.UpdateAsync(toBeUpdated);
            return Ok(model);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Music>> DeleteMusic(int id)
        {
            await _musicService.DeleteAsync(await _musicService.GetByIdAsync(id));
            if(await _musicService.GetByIdAsync(id) == null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
