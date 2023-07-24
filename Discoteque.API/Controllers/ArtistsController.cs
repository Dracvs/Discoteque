using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;

namespace Discoteque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistsService _artistsService;

        public ArtistsController(IArtistsService artistsService)
        {
            _artistsService = artistsService;
        }

        [HttpGet]
        [Route("GetAllArtistsAsync")]
        public async Task<IActionResult> GetAllArtistsAsync()
        {
            var artists = await _artistsService.GetArtistsAsync();
            return Ok(artists);
        }


        [HttpPost]
        [Route("CreateArtistAsync")]
        public async Task<IActionResult> CreateArtistAsync(Artist artist)
        {
            var result = await _artistsService.CreateArtist(artist);
            return Ok(result);
        }

        [HttpPatch]
        [Route("UpdateArtistAsync")]
        public async Task<IActionResult> UpdateArtistAsync(Artist artist)
        {
            return Ok();
        }
    }
}
