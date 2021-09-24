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

    public class ArtistController : BaseApiController
    {
        private readonly IArtistService _artistService;
        public ArtistController(IArtistService artistService,IMapper mapper) : base(mapper) 
        { 
            _artistService = artistService; 
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<Artist>>> GetAllArtists()
        {
            return await _artistService.GetAllAsync();
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Artist>> GetById(int id)
        {
            return await _artistService.GetByIdAsync(id);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Artist>> AddNewArtist(AddArtistDTO model)
        {
            await _artistService.CreateAsync(_mapper.Map<Artist>(model));
           return Ok();
        }

        [HttpPost("edit/{id}")]
        public async Task<ActionResult<Artist>> EditArtist(ArtistDTO model)
        {
            var toBeUpdated = await _artistService.GetByIdAsync(model.Id);
            toBeUpdated.Name = model.Name;
            await _artistService.UpdateAsync(toBeUpdated);
            if(toBeUpdated.Name == model.Name)
            {
                return Ok(toBeUpdated);
            }
            return BadRequest();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(ArtistDTO model)
        {
            var toBeDeleted = await _artistService.GetByIdAsync(model.Id);
            await _artistService.DeleteAsync(toBeDeleted);

            if (toBeDeleted == null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
